namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Find place response
    /// 查找地址响应
    /// https://developers.google.com/maps/documentation/places/web-service/search-find-place
    /// </summary>
    public record FindPlaceResponse : BaseResponse
    {
        /// <summary>
        /// Candidates
        /// </summary>
        public required IEnumerable<Place> Candidates { get; init; }
    }
}
