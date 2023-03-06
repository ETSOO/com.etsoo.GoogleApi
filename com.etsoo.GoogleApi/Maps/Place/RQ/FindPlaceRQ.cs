using com.etsoo.ApiModel.Dto.Maps;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.GoogleApi.Maps.Place.RQ
{
    /// <summary>
    /// Find place input type
    /// 查找地址输入类型
    /// </summary>
    public enum FindPlaceInputType
    {
        TextQuery,
        PhoneNumber
    }

    /// <summary>
    /// Rectangular location bias
    /// </summary>
    /// <param name="SouthWest">east/west values are wrapped to the range -180, 180</param>
    /// <param name="NothEast">north/south values are clamped to the range -90, 90</param>
    public record LocationRectangularBias(Location SouthWest, Location NorthEast)
    {
        public override string ToString()
        {
            return $"rectangle:{SouthWest}|{NorthEast}";
        }
    }

    /// <summary>
    /// Circular location bias
    /// </summary>
    /// <param name="Point">Center point location</param>
    /// <param name="Radius">Radius in meters</param>
    public record LocationCircularBias(Location Point, float Radius)
    {
        public override string ToString()
        {
            return $"circle:{Radius}@{Point}";
        }
    }

    /// <summary>
    /// Find place request data
    /// 查找地址请求数据
    /// </summary>
    public record FindPlaceRQ : MapBaseRQ
    {
        /// <summary>
        /// Input
        /// 输入
        /// </summary>
        [Required]
        [StringLength(128, MinimumLength = 3)]
        public required string Input { get; init; }

        /// <summary>
        /// Input type
        /// 输入类型
        /// </summary>
        public FindPlaceInputType InputType { get; init; } = FindPlaceInputType.TextQuery;

        /// <summary>
        /// Use the fields parameter to specify a comma-separated list of place data types to return
        /// 使用 fields 参数指定要返回的以逗号分隔的位置数据类型列表
        /// </summary>
        public PlaceField? Fields { get; init; }

        /// <summary>
        /// IP bias: Instructs the API to use IP address biasing
        /// </summary>
        public bool? LocationIPBias { get; init; }

        /// <summary>
        /// Circular location bias
        /// </summary>
        public LocationCircularBias? LocationCircularBias { get; init; }

        /// <summary>
        /// Rectangular location bias
        /// </summary>
        public LocationRectangularBias? LocationRectangularBias { get; init; }
    }
}