using com.etsoo.GoogleApiModel.Maps.RQ;
using com.etsoo.Utils.String;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Find place request
    /// </summary>
    public record GetDetailsRequest : BaseRequest
    {
        public GetDetailsRequest(string key, GetDetailsRQ rq) : base(key, rq)
        {
            Parameters["place_id"] = rq.PlaceId;

            if (rq.Fields.HasValue) Parameters["fields"] = PlaceUtils.FormatFields(rq.Fields.Value);

            if (!string.IsNullOrEmpty(rq.Region)) Parameters["region"] = rq.Region;

            if (rq.ReviewsNoTranslations.HasValue) Parameters["reviews_no_translations"] = rq.ReviewsNoTranslations.ToJson();

            if (rq.ReviewsSort.HasValue) Parameters["reviews_sort"] = rq.ReviewsSort.Value.ToString().ToSnakeCase().ToString();

            if (!string.IsNullOrEmpty(rq.SessionToken)) Parameters["sessiontoken"] = rq.SessionToken;
        }
    }
}