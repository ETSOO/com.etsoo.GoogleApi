using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.WebUtils.Attributes;

namespace com.etsoo.GoogleApi.Maps.Place.RQ
{
    /// <summary>
    /// Map base request data
    /// 地图基础请求数据
    /// </summary>
    public abstract record MapBaseRQ
    {
        /// <summary>
        /// Output format
        /// 输出格式
        /// </summary>
        public ApiOutput Output { get; init; } = ApiOutput.JSON;

        /// <summary>
        /// Language
        /// 语言
        /// </summary>
        [LanguageCode]
        public string? Language { get; init; }
    }
}
