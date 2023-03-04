namespace com.etsoo.GoogleApiModel.Maps.RQ
{
    /// <summary>
    /// Reviews sort method
    /// </summary>
    public enum ReviewsSort : byte
    {
        MostRelevant,
        Newest
    }

    /// <summary>
    /// Get place details request data
    /// </summary>
    public record GetDetailsRQ : MapBaseRQ
    {
        /// <summary>
        /// Place id
        /// 地点编号
        /// </summary>
        public required string PlaceId { get; init; }

        /// <summary>
        /// Use the fields parameter to specify a comma-separated list of place data types to return
        /// 使用 fields 参数指定要返回的以逗号分隔的位置数据类型列表
        /// </summary>
        public PlaceField? Fields { get; init; }

        /// <summary>
        /// Two-character region code, like CN
        /// </summary>
        public string? Region { get; init; }

        /// <summary>
        /// Reviews without translations
        /// </summary>
        public bool? ReviewsNoTranslations { get; init; }

        /// <summary>
        /// The sorting method to use when returning reviews. Can be set to most_relevant (default) or newest
        /// </summary>
        public ReviewsSort? ReviewsSort { get; init; }

        /// <summary>
        /// A random string which identifies an autocomplete session for billing purposes
        /// </summary>
        public string? SessionToken { get; init; }

        /// <summary>
        /// Create an unique key for cache
        /// </summary>
        /// <returns>Result</returns>
        public string CreateKey()
        {
            return $"{Language}, {PlaceId}, {Fields}, {Region}, {ReviewsNoTranslations}, {ReviewsSort}";
        }
    }
}
