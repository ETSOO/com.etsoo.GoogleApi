using System.ComponentModel.DataAnnotations;

namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Cloud API options
    /// 云接口参数
    /// </summary>
    public record GoogleCloudOptions
    {
        /// <summary>
        /// The path to the credentials file to use
        /// 要使用的凭据文件的路径
        /// https://developers.google.com/workspace/guides/create-credentials
        /// </summary>
        [Required]
        public required string CredentialsPath { get; set; }

        /// <summary>
        /// Whether to use REST API instead of gRPC
        /// 是否使用 REST API 而不是 gRPC
        /// </summary>
        public bool? IsREST { get; set; }
    }
}
