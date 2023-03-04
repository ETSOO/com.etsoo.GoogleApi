namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Get place details response
    /// 获取地点细节响应
    /// https://developers.google.com/maps/documentation/places/web-service/details
    /// </summary>
    public record GetDetailsResponse : BaseResponse
    {
        /// <summary>
        /// May contain a set of attributions about this listing which must be displayed to the user
        /// </summary>
        public required IEnumerable<string> HtmlAttributions { get; init; }

        /// <summary>
        /// Result
        /// 结果
        /// </summary>
        public required Place Result { get; init; }
    }
}
