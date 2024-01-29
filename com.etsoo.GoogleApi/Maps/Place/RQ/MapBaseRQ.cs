using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.WebUtils.Attributes;
using System.Text.Json.Serialization;

namespace com.etsoo.GoogleApi.Maps.Place.RQ
{
    /// <summary>
    /// Map base request data
    /// 地图基础请求数据
    /// </summary>
    [JsonDerivedType(typeof(AutocompleteRQ))]
    [JsonDerivedType(typeof(FindPlaceRQ))]
    [JsonDerivedType(typeof(GetDetailsRQ))]
    [JsonDerivedType(typeof(SearchPlaceRQ))]
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
