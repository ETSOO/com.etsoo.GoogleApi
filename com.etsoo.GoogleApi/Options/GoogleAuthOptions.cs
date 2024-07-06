using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Google Auth options
    /// https://developers.google.com/identity/protocols/oauth2
    /// https://console.cloud.google.com/apis/credentials/consent?project=smarterp-2004
    /// 谷歌认证选项
    /// </summary>
    public record GoogleAuthOptions
    {
        /// <summary>
        /// Client ID, like *.apps.googleusercontent.com
        /// </summary>
        [Required]
        public required string ClientId { get; set; }

        /// <summary>
        /// Client secret
        /// </summary>
        [Required]
        public required string ClientSecret { get; set; }

        /// <summary>
        /// Authorized redirect URIs for the server side application
        /// </summary>
        [Url]
        public string? ServerRedirectUrl { get; set; }

        /// <summary>
        /// Authorized redirect URIs for the script side application
        /// </summary>
        [Url]
        public string? ScriptRedirectUrl { get; set; }
    }

    [OptionsValidator]
    public partial class ValidateGoogleAuthOptions : IValidateOptions<GoogleAuthOptions>
    {
    }
}
