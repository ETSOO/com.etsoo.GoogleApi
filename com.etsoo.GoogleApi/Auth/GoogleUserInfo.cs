namespace com.etsoo.GoogleApi.Auth
{
    /// <summary>
    /// Google OAuth2 user information
    /// https://developers.google.com/identity/openid-connect/openid-connect#python
    /// 谷歌 OAuth2 用户信息
    /// </summary>
    public record GoogleUserInfo
    {
        /// <summary>
        /// An identifier for the user, unique among all Google accounts and never reused
        /// </summary>
        public required string Sub { get; init; }

        /// <summary>
        /// The user's full name, in a displayable form
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// The user's given name(s) or first name(s)
        /// </summary>
        public string? GivenName { get; init; }

        /// <summary>
        /// The user's surname(s) or last name(s)
        /// </summary>
        public string? FamilyName { get; init; }

        /// <summary>
        /// The URL of the user's profile picture
        /// </summary>
        public string? Picture { get; init; }

        /// <summary>
        /// The user's email address
        /// </summary>
        public required string Email { get; init; }

        /// <summary>
        /// True if the user's e-mail address has been verified
        /// </summary>
        public required bool EmailVerified { get; init; }
    }
}
