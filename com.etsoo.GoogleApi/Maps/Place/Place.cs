using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.GoogleApiModel.Maps.RQ;
using System.Text.Json.Serialization;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Address component
    /// </summary>
    public record AddressComponent
    {
        public required string LongName { get; init; }
        public required string ShortName { get; init; }
        public required IEnumerable<string> Types { get; init; }
    }

    /// <summary>
    /// Business status
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BusinessStatus : byte
    {
        OPERATIONAL,
        CLOSED_TEMPORARILY,
        CLOSED_PERMANENTLY
    }

    /// <summary>
    /// Place openning hours period
    /// </summary>
    public record PlaceOpeningHoursPeriod
    {
        public required PlaceOpeningHoursPeriodDetail Open { get; init; }
        public PlaceOpeningHoursPeriodDetail? Close { get; init; }
    }

    /// <summary>
    /// Place openning hours period detail
    /// </summary>
    public record PlaceOpeningHoursPeriodDetail
    {
        public required DayOfWeek Day { get; init; }
        public required string Time { get; init; }
        public string? Date { get; init; }
        public bool? Truncated { get; init; }
    }

    /// <summary>
    /// Place special day
    /// </summary>
    public record PlaceSpecialDay
    {
        public string? Date { get; init; }
        public bool? ExceptionalHours { get; init; }
    }

    /// <summary>
    /// Place opening hours
    /// </summary>
    public record PlaceOpeningHours
    {
        public bool? OpenNow { get; init; }

        public IEnumerable<PlaceOpeningHoursPeriod>? Periods { get; init; }

        public IEnumerable<PlaceSpecialDay>? SpecialDays { get; init; }

        public string? Type { get; init; }

        public IEnumerable<string>? WeekdayText { get; init; }
    }

    /// <summary>
    /// Place editorial summary
    /// </summary>
    public record PlaceEditorialSummary
    {
        public string? Language { get; init; }
        public string? Overview { get; init; }
    }

    /// <summary>
    /// Place geometry bounds
    /// </summary>
    public record Bounds
    {
        public required Location Northeast { get; init; }
        public required Location Southwest { get; init; }
    }

    /// <summary>
    /// Place geometry
    /// </summary>
    public record Geometry
    {
        public required Location Location { get; init; }
        public required Bounds Viewport { get; init; }
    }

    /// <summary>
    /// Place photo
    /// </summary>
    public record PlacePhoto
    {
        public required int Height { get; init; }
        public required IEnumerable<string> HtmlAttributions { get; init; }
        public required string PhotoReference { get; init; }
        public required int Width { get; init; }
    }

    /// <summary>
    /// Place plus code
    /// </summary>
    public record PlusCode
    {
        public required string GlobalCode { get; init; }
        public string? CompoundCode { get; init; }
    }

    /// <summary>
    /// Place review
    /// </summary>
    public record PlaceReview
    {
        public required string AuthorName { get; init; }
        public required byte Rating { get; init; }
        public required string RelativeTimeDescription { get; init; }
        public required int Time { get; init; }
        public string? AuthorUrl { get; init; }
        public string? Language { get; init; }
        public string? OriginalLanguage { get; init; }
        public string? ProfilePhotoUrl { get; init; }
        public string? Text { get; init; }
        public bool? Translated { get; init; }
    }

    /// <summary>
    /// Place
    /// 地点
    /// </summary>
    public record Place
    {
        public IEnumerable<AddressComponent>? AddressComponents { get; init; }

        public string? AdrAddress { get; init; }

        public BusinessStatus? BusinessStatus { get; init; }

        public bool? CurbsidePickup { get; init; }

        public PlaceOpeningHours? CurrentOpeningHours { get; init; }

        public bool? Delivery { get; init; }

        public bool? DineIn { get; init; }

        public PlaceEditorialSummary? EditorialSummary { get; init; }

        public string? FormattedAddress { get; init; }

        public string? FormattedPhoneNumber { get; init; }

        public Geometry? Geometry { get; init; }

        public string? Icon { get; init; }

        public string? IconBackgroundColor { get; init; }

        public string? IconMaskBaseUri { get; init; }

        public string? InternationalPhoneNumber { get; init; }

        public string? Name { get; init; }

        public PlaceOpeningHours? OpeningHours { get; init; }

        public IEnumerable<PlacePhoto>? Photos { get; init; }

        public string? PlaceId { get; init; }

        public PlusCode? PlusCode { get; init; }

        public PriceLevel? PriceLevel { get; init; }

        // Average rating
        public decimal? Rating { get; init; }

        public bool? Reservable { get; init; }

        public IEnumerable<PlaceReview>? Reviews { get; init; }

        public PlaceOpeningHours? SecondaryOpeningHours { get; init; }

        public bool? ServesBeer { get; init; }

        public bool? ServesBreakfast { get; init; }

        public bool? ServesBrunch { get; init; }

        public bool? ServesDinner { get; init; }

        public bool? ServesLunch { get; init; }

        public bool? ServesVegetarianFood { get; init; }

        public bool? ServesWine { get; init; }

        public bool? Takeout { get; init; }

        public IEnumerable<string>? Types { get; init; }

        public string? Url { get; init; }

        public int? UserRatingsTotal { get; init; }

        public short? UtcOffset { get; init; }

        public string? Vicinity { get; init; }

        public string? Website { get; init; }

        public bool? WheelchairAccessibleEntrance { get; init; }
    }
}
