using com.etsoo.GoogleApi.Cloud.RQ;

namespace com.etsoo.GoogleApi.Cloud
{
    /// <summary>
    /// Translate service interface
    /// 翻译服务接口
    /// </summary>
    public interface IGoogleTranslateService
    {
        /// <summary>
        /// Detect the language of the given text
        /// 检测文本的语言
        /// </summary>
        /// <param name="text">Text to detect</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Detected language code</returns>
        Task<string?> DetectLanguageAsync(string text, CancellationToken cancellationToken = default);

        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Translated text</returns>
        Task<string> TranslateTextAsync(TranslateTextRQ rq, CancellationToken token = default);
    }
}