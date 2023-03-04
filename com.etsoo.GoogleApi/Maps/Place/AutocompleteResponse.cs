namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Place autocomplete matched substring
    /// </summary>
    public record PlaceAutocompleteMatchedSubstring
    {
        public required int Length { get; init; }
        public required int Offset { get; init; }
    }

    /// <summary>
    /// Place autocomplete structured format
    /// </summary>
    public record PlaceAutocompleteStructuredFormat
    {
        public required string MainText { get; init; }
        public required IEnumerable<PlaceAutocompleteMatchedSubstring> MainTextMatchedSubstrings { get; init; }
        public string? SecondaryText { get; init; }
        public IEnumerable<PlaceAutocompleteMatchedSubstring>? SecondaryTextMatchedSubstrings { get; init; }
    }

    /// <summary>
    /// Place autocomplete term
    /// </summary>
    public record PlaceAutocompleteTerm
    {
        public required int Offset { get; init; }
        public required string Value { get; init; }
    }

    /// <summary>
    /// Place autocomplete prediction
    /// </summary>
    public record PlaceAutocompletePrediction
    {
        public required string Description { get; init; }
        public required IEnumerable<PlaceAutocompleteMatchedSubstring> MatchedSubstrings { get; init; }
        public required PlaceAutocompleteStructuredFormat StructuredFormatting { get; init; }
        public required IEnumerable<PlaceAutocompleteTerm> Terms { get; init; }
        public int? DistanceMeters { get; init; }
        public string? PlaceId { get; init; }
        public IEnumerable<string>? Types { get; init; }
    }

    /// <summary>
    /// Autocomplete response
    /// 自动完成响应
    /// https://developers.google.com/maps/documentation/places/web-service/autocomplete
    /// </summary>
    public record AutocompleteResponse : BaseResponse
    {
        /// <summary>
        /// Predictions
        /// </summary>
        public required IEnumerable<PlaceAutocompletePrediction> Predictions { get; init; }
    }
}
