using com.etsoo.GoogleApiModel.Maps.RQ;
using com.etsoo.Utils.String;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Base request
    /// 基本请求
    /// </summary>
    public record BaseRequest
    {
        /// <summary>
        /// Parameters
        /// 参数
        /// </summary>
        protected readonly Dictionary<string, string> Parameters = new();

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="key">API Key</param>
        /// <param name="rq">Base request data</param>
        protected BaseRequest(string key, MapBaseRQ rq)
        {
            Parameters["key"] = key;
            if (!string.IsNullOrEmpty(rq.Language)) Parameters["language"] = rq.Language;
        }

        /// <summary>
        /// To query string
        /// 输出查询字符串
        /// </summary>
        /// <returns>Result</returns>
        public virtual string ToQuery()
        {
            return Parameters.JoinAsQuery().TrimEnd('&');
        }
    }
}
