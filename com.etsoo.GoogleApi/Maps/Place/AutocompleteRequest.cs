using com.etsoo.GoogleApi.Maps.Place.RQ;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Place autocomplete request
    /// </summary>
    public record AutocompleteRequest : BaseRequest
    {
        public AutocompleteRequest(string key, AutocompleteRQ rq) : base(key, rq)
        {
            Parameters["input"] = rq.Input;

            if (rq.Radius.HasValue) Parameters["radius"] = rq.Radius.Value.ToString();

            if (rq.Location != null) Parameters["location"] = rq.Location.ToString();

            if (rq.LocationIPBias is true) Parameters["locationbias"] = "ipbias";
            else if (rq.LocationCircularBias is not null) Parameters["locationbias"] = rq.LocationCircularBias.ToString();
            else if (rq.LocationRectangularBias is not null) Parameters["locationbias"] = rq.LocationRectangularBias.ToString();

            if (rq.LocationrestrictionCircular is not null) Parameters["locationrestriction"] = rq.LocationrestrictionCircular.ToString();
            else if (rq.LocationrestrictionRectangular is not null) Parameters["locationrestriction"] = rq.LocationrestrictionRectangular.ToString();

            if (rq.Offset.HasValue) Parameters["offset"] = rq.Offset.Value.ToString();

            if (rq.Origin != null) Parameters["origin"] = rq.Origin.ToString();

            if (!string.IsNullOrEmpty(rq.Region)) Parameters["region"] = rq.Region;

            if (!string.IsNullOrEmpty(rq.SessionToken)) Parameters["sessiontoken"] = rq.SessionToken;

            if (rq.Strictbounds is true) Parameters["strictbounds"] = "true";

            if (rq.Types != null) Parameters["types"] = string.Join("|", rq.Types);
        }
    }
}
