namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Google Maps API options
    /// 谷歌地图接口参数
    /// </summary>
    public record MapsOptions
    {
        /// <summary>
        /// API key
        /// 接口密钥
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// API base address
        /// 接口基地址
        /// </summary>
        public string BaseAddress { get; set; } = "https://maps.googleapis.com/maps/api/";

        /// <summary>
        /// Cache hours
        /// 缓存小时数
        /// </summary>
        public double CacheHours { get; set; } = 24;
    }
}
