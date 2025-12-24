using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.Utils.String;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Search place request
    /// </summary>
    public record SearchPlaceRequest : BaseRequest
    {
        public SearchPlaceRequest(string key, SearchPlaceRQ rq) : base(key, rq)
        {
            Parameters["query"] = rq.Query;

            if (rq.Radius.HasValue) Parameters["radius"] = rq.Radius.Value.ToString();

            if (rq.Location != null) Parameters["location"] = rq.Location.ToString();

            if (rq.MaxPrice.HasValue) Parameters["maxprice"] = ((byte)rq.MaxPrice.Value).ToString();
            if (rq.MinPrice.HasValue) Parameters["minprice"] = ((byte)rq.MinPrice.Value).ToString();

            if (rq.OpenNow is not null) Parameters["opennow"] = rq.OpenNow.ToJson();

            if (!string.IsNullOrEmpty(rq.Pagetoken)) Parameters["pageToken"] = rq.Pagetoken;

            if (!string.IsNullOrEmpty(rq.Region)) Parameters["region"] = rq.Region;

            if (!string.IsNullOrEmpty(rq.Type)) Parameters["type"] = rq.Type;

            if (rq.PageSize != null) Parameters["pageSize"] = rq.PageSize.Value.ToString();
        }
    }
}
