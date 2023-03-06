using com.etsoo.GoogleApi.Maps.Place.RQ;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Find place request
    /// </summary>
    public record FindPlaceRequest : BaseRequest
    {
        public FindPlaceRequest(string key, FindPlaceRQ rq) : base(key, rq)
        {
            Parameters["input"] = rq.Input;
            Parameters["inputtype"] = rq.InputType.ToString().ToLower();

            if (rq.Fields.HasValue) Parameters["fields"] = PlaceUtils.FormatFields(rq.Fields.Value);

            if (rq.LocationIPBias is true) Parameters["locationbias"] = "ipbias";
            else if (rq.LocationCircularBias is not null) Parameters["locationbias"] = rq.LocationCircularBias.ToString();
            else if (rq.LocationRectangularBias is not null) Parameters["locationbias"] = rq.LocationRectangularBias.ToString();
        }
    }
}
