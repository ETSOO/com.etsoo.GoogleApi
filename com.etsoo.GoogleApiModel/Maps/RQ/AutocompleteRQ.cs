using com.etsoo.ApiModel.Dto.Maps;

namespace com.etsoo.GoogleApiModel.Maps.RQ
{
    /// <summary>
    /// Place autocomplete reqeust data
    /// </summary>
    public record AutocompleteRQ : MapBaseRQ
    {
        /// <summary>
        /// Query text
        /// 查询文本
        /// </summary>
        public required string Input { get; init; }

        /// <summary>
        /// Defines the distance (in meters) within which to return place results
        /// </summary>
        public int? Radius { get; init; }

        /// <summary>
        /// The point around which to retrieve place information
        /// </summary>
        public Location? Location { get; init; }

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

        /// <summary>
        /// Circular location restriction
        /// </summary>
        public LocationCircularBias? LocationrestrictionCircular { get; init; }

        /// <summary>
        /// Rectangular location restriction
        /// </summary>
        public LocationRectangularBias? LocationrestrictionRectangular { get; init; }

        /// <summary>
        /// The position, in the input term, of the last character that the service uses to match predictions
        /// </summary>
        public uint? Offset { get; init; }

        /// <summary>
        /// The origin point from which to calculate straight-line distance to the destination
        /// </summary>
        public Location? Origin { get; init; }

        /// <summary>
        /// Two-character region code, like CN
        /// </summary>
        public string? Region { get; init; }

        /// <summary>
        /// A random string which identifies an autocomplete session for billing purposes
        /// </summary>
        public string? SessionToken { get; init; }

        /// <summary>
        /// Returns only those places that are strictly within the region defined by location and radius
        /// </summary>
        public bool? Strictbounds { get; init; }

        /// <summary>
        /// Restricts the results to places matching the specified types
        /// </summary>
        public IEnumerable<string>? Types { get; init; }
    }
}
