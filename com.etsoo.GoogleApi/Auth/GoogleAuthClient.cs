using com.etsoo.ApiModel.Auth;
using com.etsoo.GoogleApi.Options;
using com.etsoo.Utils;
using com.etsoo.Utils.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Web;

namespace com.etsoo.GoogleApi.Auth
{
    /// <summary>
    /// Google Auth client
    /// 谷歌认证客户端
    /// </summary>
    public class GoogleAuthClient : IGoogleAuthClient
    {
        private readonly HttpClient _client;
        private readonly GoogleAuthOptions _options;

        public GoogleAuthClient(HttpClient client, GoogleAuthOptions options)
        {
            _client = client;
            _options = options;
        }

        [ActivatorUtilitiesConstructor]
        public GoogleAuthClient(HttpClient client, IOptions<GoogleAuthOptions> options) : this(client, options.Value)
        {

        }

        /// <summary>
        /// Get server auth URL, for back-end processing
        /// 获取服务器授权URL，用于后端处理
        /// </summary>
        /// <param name="state">Specifies any string value that your application uses to maintain state between your authorization request and the authorization server's response</param>
        /// <param name="scope">A space-delimited list of scopes that identify the resources that your application could access on the user's behalf</param>
        /// <param name="offline">Set to true if your application needs to refresh access tokens when the user is not present at the browser</param>
        /// <param name="loginHint">Set the parameter value to an email address or sub identifier, which is equivalent to the user's Google ID</param>
        /// <returns>URL</returns>
        public string GetServerAuthUrl(string state, string scope, bool offline = false, string? loginHint = null)
        {
            var url = GetAuthUrl(_options.ServerRedirectUrl, "code", scope, state, loginHint);
            if (offline)
            {
                url += "&access_type=offline";
            }
            return url;
        }

        /// <summary>
        /// Get script auth URL, for front-end page
        /// 获取脚本授权URL，用于前端页面
        /// </summary>
        /// <param name="state">Specifies any string value that your application uses to maintain state between your authorization request and the authorization server's response</param>
        /// <param name="scope">A space-delimited list of scopes that identify the resources that your application could access on the user's behalf</param>
        /// <param name="loginHint">Set the parameter value to an email address or sub identifier, which is equivalent to the user's Google ID</param>
        /// <returns>URL</returns>
        public string GetScriptAuthUrl(string state, string scope, string? loginHint = null)
        {
            return GetAuthUrl(_options.ScriptRedirectUrl, "token", scope, state, loginHint);
        }

        /// <summary>
        /// Get auth URL
        /// 获取授权URL
        /// </summary>
        /// <param name="redirectUrl">The value must exactly match one of the authorized redirect URIs for the OAuth 2.0 client, which you configured in your client's API Console</param>
        /// <param name="responseType">Set the parameter value to 'code' for web server applications or 'token' for SPA</param>
        /// <param name="scope">A space-delimited list of scopes that identify the resources that your application could access on the user's behalf</param>
        /// <param name="state">Specifies any string value that your application uses to maintain state between your authorization request and the authorization server's response</param>
        /// <param name="loginHint">Set the parameter value to an email address or sub identifier, which is equivalent to the user's Google ID</param>
        /// <returns>URL</returns>
        /// <exception cref="ArgumentNullException">Parameter 'redirectUrl' is required</exception>
        public string GetAuthUrl(string? redirectUrl, string responseType, string scope, string state, string? loginHint = null)
        {
            if (string.IsNullOrEmpty(redirectUrl))
            {
                throw new ArgumentNullException(nameof(redirectUrl));
            }

            return $"https://accounts.google.com/o/oauth2/v2/auth?scope={HttpUtility.UrlEncode(scope)}&include_granted_scopes=true&response_type={responseType}&state={HttpUtility.UrlEncode(state)}&redirect_uri={HttpUtility.UrlEncode(redirectUrl)}&client_id={_options.ClientId}&login_hint={loginHint}";
        }

        /// <summary>
        /// Create access token from authorization code
        /// 从授权码创建访问令牌
        /// </summary>
        /// <param name="code">Authorization code</param>
        /// <returns>Token data</returns>
        public async ValueTask<GoogleTokenData?> CreateTokenAsync(string code)
        {
            if (string.IsNullOrEmpty(_options.ServerRedirectUrl))
            {
                return null;
            }

            var response = await _client.PostAsync("https://oauth2.googleapis.com/token", new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["code"] = code,
                ["client_id"] = _options.ClientId,
                ["client_secret"] = _options.ClientSecret,
                ["redirect_uri"] = _options.ServerRedirectUrl,
                ["grant_type"] = "authorization_code"
            }));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(GoogleApiCallJsonSerializerContext.Default.GoogleTokenData);
        }

        /// <summary>
        /// Refresh the access token with refresh token
        /// 用刷新令牌获取访问令牌
        /// </summary>
        /// <param name="refreshToken">Refresh token</param>
        /// <returns>Result</returns>
        public async Task<GoogleRefreshTokenData?> RefreshTokenAsync(string refreshToken)
        {
            var response = await _client.PostAsync("https://oauth2.googleapis.com/token", new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = _options.ClientId,
                ["client_secret"] = _options.ClientSecret,
                ["refresh_token"] = refreshToken,
                ["grant_type"] = "refresh_token"
            }));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(GoogleApiCallJsonSerializerContext.Default.GoogleRefreshTokenData);
        }

        /// <summary>
        /// Get user info
        /// 获取用户信息
        /// </summary>
        /// <param name="tokenData">Token data</param>
        /// <returns>Result</returns>
        public async ValueTask<GoogleUserInfo?> GetUserInfoAsync(GoogleTokenData tokenData)
        {
            if (!string.IsNullOrEmpty(tokenData.IdToken))
            {
                var claims = new JwtSecurityToken(tokenData.IdToken).Claims;
                var sub = claims.GetValue("sub");
                var name = claims.GetValue("name");
                var givenName = claims.GetValue("given_name");
                var familyName = claims.GetValue("family_name");
                var picture = claims.GetValue("picture");
                var email = claims.GetValue("email");
                var emailVerified = claims.GetValue("email_verified") == "true";

                if (!string.IsNullOrEmpty(sub) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
                {
                    return new GoogleUserInfo
                    {
                        Sub = sub,
                        Name = name,
                        GivenName = givenName,
                        FamilyName = familyName,
                        Picture = picture,
                        Email = email,
                        EmailVerified = emailVerified
                    };
                }
            }

            var response = await _client.GetAsync($"https://www.googleapis.com/oauth2/v3/userinfo?access_token={tokenData.AccessToken}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync(GoogleApiCallJsonSerializerContext.Default.GoogleUserInfo);
        }

        /// <summary>
        /// Get user info from callback request
        /// 从回调请求获取用户信息
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="state">Request state</param>
        /// <returns>Action result & user information</returns>
        public async ValueTask<(IActionResult result, AuthUserInfo? userInfo)> GetUserInfoAsync(HttpRequest request, string state)
        {
            var (result, tokenData) = await ValidateAuthAsync(request, state);
            AuthUserInfo? userInfo = null;
            if (result.Ok && tokenData != null)
            {
                var data = await GetUserInfoAsync(tokenData);
                if (data == null)
                {
                    result = new ActionResult
                    {
                        Type = "NoDataReturned",
                        Field = "userinfo"
                    };
                }
                else
                {
                    userInfo = new AuthUserInfo
                    {
                        OpenId = data.Sub,
                        Name = data.Name,
                        GivenName = data.GivenName,
                        FamilyName = data.FamilyName,
                        Picture = data.Picture,
                        Email = data.Email,
                        EmailVerified = data.EmailVerified
                    };
                }
            }

            return (result, userInfo);
        }

        /// <summary>
        /// Validate auth callback
        /// 验证认证回调
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="state">State</param>
        /// <returns>Action result & Token data</returns>
        public async Task<(IActionResult result, GoogleTokenData? tokenData)> ValidateAuthAsync(HttpRequest request, string state)
        {
            IActionResult result;
            GoogleTokenData? tokenData = null;

            if (request.Query.TryGetValue("error", out var error))
            {
                result = new ActionResult
                {
                    Type = "AccessDenied",
                    Field = error
                };
            }
            else if (request.Query.TryGetValue("state", out var actualState) && request.Query.TryGetValue("code", out var codeSource))
            {
                var code = codeSource.ToString();
                if (!actualState.Equals(state))
                {
                    result = new ActionResult
                    {
                        Type = "AccessDenied",
                        Field = state
                    };
                }
                else if (string.IsNullOrEmpty(code))
                {
                    result = new ActionResult
                    {
                        Type = "NoDataReturned",
                        Field = "code"
                    };
                }
                else
                {
                    tokenData = await CreateTokenAsync(code);

                    if (tokenData == null)
                    {
                        result = new ActionResult
                        {
                            Type = "NoDataReturned",
                            Field = "token"
                        };
                    }
                    else
                    {
                        result = ActionResult.Success;
                    }
                }
            }
            else
            {
                result = new ActionResult
                {
                    Type = "NoDataReturned",
                    Field = "state"
                };
            }

            return (result, tokenData);
        }
    }
}
