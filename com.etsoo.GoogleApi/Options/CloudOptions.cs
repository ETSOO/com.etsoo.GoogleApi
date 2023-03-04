namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Cloud API options
    /// 云接口参数
    /// </summary>
    public record CloudOptions
    {
        /// <summary>
        /// The path to the credentials file to use
        /// 要使用的凭据文件的路径
        /// https://developers.google.com/workspace/guides/create-credentials
        /// </summary>
        public required string CredentialsPath { get; init; }
    }
}
