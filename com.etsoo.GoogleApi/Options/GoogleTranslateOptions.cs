using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Translate API options
    /// 翻译接口参数
    /// </summary>
    public record GoogleTranslateOptions : GoogleCloudOptions
    {
        /// <summary>
        /// Translate project id
        /// 翻译项目编号
        /// https://cloud.google.com/translate/docs/setup
        /// </summary>
        [Required]
        public required string TranslateProjectId { get; set; }
    }

    [OptionsValidator]
    public partial class ValidateGoogleTranslateOptions : IValidateOptions<GoogleTranslateOptions>
    {
    }
}
