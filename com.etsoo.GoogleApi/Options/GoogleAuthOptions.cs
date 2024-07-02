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
        public string ClientId { get; set; } = string.Empty!;

        /// <summary>
        /// Client secret
        /// </summary>
        public string ClientSecret { get; set; } = string.Empty!;

        /// <summary>
        /// Authorized redirect URIs for the server side application
        /// </summary>
        public string? ServerRedirectUrl { get; set; }

        /// <summary>
        /// Authorized redirect URIs for the script side application
        /// </summary>
        public string? ScriptRedirectUrl { get; set; }
    }
}
