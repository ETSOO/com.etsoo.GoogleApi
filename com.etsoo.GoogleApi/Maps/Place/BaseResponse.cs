using System.Text.Json.Serialization;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Base response
    /// 基本响应
    /// </summary>
    [JsonDerivedType(typeof(AutocompleteResponse))]
    [JsonDerivedType(typeof(FindPlaceResponse))]
    [JsonDerivedType(typeof(GetDetailsResponse))]
    [JsonDerivedType(typeof(SearchPlaceResponse))]
    public record BaseResponse
    {
        /// <summary>
        /// Status
        /// </summary>
        public required string Status { get; init; }

        /// <summary>
        /// Option error message when Status other than 'OK'
        /// </summary>
        public string? ErrorMessage { get; init; }

        /// <summary>
        /// This field is only returned for successful requests
        /// </summary>
        public IEnumerable<string>? InfoMessages { get; init; }
    }
}
