namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Search place response
    /// 查询地址响应
    /// https://developers.google.com/maps/documentation/places/web-service/search-text
    /// </summary>
    public record SearchPlaceResponse : BaseResponse
    {
        /// <summary>
        /// May contain a set of attributions about this listing which must be displayed to the user
        /// </summary>
        public required IEnumerable<string> HtmlAttributions { get; init; }

        /// <summary>
        /// Results
        /// </summary>
        public required IEnumerable<Place> Results { get; init; }

        /// <summary>
        /// Contains a token that can be used to return up to 20 additional results
        /// </summary>
        public string? NextPageToken { get; init; }
    }
}
