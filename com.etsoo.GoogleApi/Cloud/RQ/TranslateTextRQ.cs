using com.etsoo.WebUtils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.GoogleApi.Cloud.RQ
{
    /// <summary>
    /// Translate text request data
    /// 翻译文本请求数据
    /// </summary>
    public class TranslateTextRQ
    {
        /// <summary>
        /// Short text to translate, shorter than 512 characters
        /// 要翻译的短文本，短于512个字符
        /// </summary>
        [Required]
        [StringLength(512, MinimumLength = 1)]
        public required string Text { get; init; }

        /// <summary>
        /// Target language code, like en-US
        /// 目标语言代码
        /// </summary>
        [Required]
        [LanguageCode]
        public string TargetLanguageCode { get; init; } = "en";

        /// <summary>
        /// Source language code, like zh-CN, zh-Hans-CN
        /// 原语言代码
        /// </summary>
        [Required]
        [LanguageCode]
        public string SourceLanguageCode { get; init; } = "zh";
    }
}
