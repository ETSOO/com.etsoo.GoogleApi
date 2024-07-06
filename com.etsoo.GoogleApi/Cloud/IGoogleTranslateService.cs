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
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Translated text</returns>
        Task<string> TranslateTextAsync(TranslateTextRQ rq, CancellationToken token = default);
    }
}