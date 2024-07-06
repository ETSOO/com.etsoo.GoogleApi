using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Google Maps API options
    /// 谷歌地图接口参数
    /// </summary>
    public record GoogleMapsOptions
    {
        /// <summary>
        /// API key
        /// 接口密钥
        /// </summary>
        [Required]
        public required string ApiKey { get; set; }

        /// <summary>
        /// API base address
        /// 接口基地址
        /// </summary>
        [Url]
        public string BaseAddress { get; set; } = "https://maps.googleapis.com/maps/api/";

        /// <summary>
        /// Cache hours
        /// 缓存小时数
        /// </summary>
        [Range(0, 2400)]
        public double CacheHours { get; set; } = 24;
    }

    [OptionsValidator]
    public partial class ValidateGoogleMapsOptions : IValidateOptions<GoogleMapsOptions>
    {
    }
}
