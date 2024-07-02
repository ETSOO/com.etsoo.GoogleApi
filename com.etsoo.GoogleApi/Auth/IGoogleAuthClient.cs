using com.etsoo.ApiModel.Auth;
using com.etsoo.Utils.Actions;
using Microsoft.AspNetCore.Http;

namespace com.etsoo.GoogleApi.Auth
{
    /// <summary>
    /// Google Auth client
    /// 谷歌认证客户端
    /// </summary>
    public interface IGoogleAuthClient : IAuthClient
    {
        /// <summary>
        /// Create access token from authorization code
        /// 从授权码创建访问令牌
        /// </summary>
        /// <param name="code">Authorization code</param>
        /// <returns>Token data</returns>
        ValueTask<GoogleTokenData?> CreateTokenAsync(string code);

        /// <summary>
        /// Get user info
        /// 获取用户信息
        /// </summary>
        /// <param name="tokenData">Token data</param>
        /// <returns>Result</returns>
        ValueTask<GoogleUserInfo?> GetUserInfoAsync(GoogleTokenData tokenData);

        /// <summary>
        /// Refresh the access token with refresh token
        /// 用刷新令牌获取访问令牌
        /// </summary>
        /// <param name="refreshToken">Refresh token</param>
        /// <returns>Result</returns>
        Task<GoogleRefreshTokenData?> RefreshTokenAsync(string refreshToken);

        /// <summary>
        /// Validate auth callback
        /// 验证认证回调
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="state">State</param>
        /// <returns>Action result & Token data</returns>
        Task<(IActionResult result, GoogleTokenData? tokenData)> ValidateAuthAsync(HttpRequest request, string state);
    }
}
