﻿using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.RQ.Maps;

namespace com.etsoo.GoogleApi.Maps.Place.RQ
{
    /// <summary>
    /// Search place request data
    /// https://developers.google.com/maps/documentation/places/web-service/search-text
    /// </summary>
    public record SearchPlaceRQ : MapBaseRQ
    {
        /// <summary>
        /// Create from common query request data
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public static SearchPlaceRQ CreateFrom(PlaceQueryRQ rq)
        {
            return new SearchPlaceRQ
            {
                Output = rq.Output,
                Query = rq.Query,
                Location= rq.Location,
                Radius = rq.Radius,
                Region = rq.Region,
                Language = rq.Language
            };
        }

        /// <summary>
        /// Query text
        /// 查询文本
        /// </summary>
        public required string Query { get; set; }

        /// <summary>
        /// Defines the distance (in meters) within which to return place results
        /// </summary>
        public int? Radius { get; init; }

        /// <summary>
        /// The point around which to retrieve place information
        /// </summary>
        public Location? Location { get; init; }

        /// <summary>
        /// Restricts results to only those places within the specified range
        /// </summary>
        public PriceLevel? MaxPrice { get; init; }

        /// <summary>
        /// Restricts results to only those places within the specified range
        /// </summary>
        public PriceLevel? MinPrice { get; init; }

        /// <summary>
        /// Is open now or not
        /// </summary>
        public bool? OpenNow { get; init; }

        /// <summary>
        /// Setting a pagetoken parameter will execute a search with the same parameters used previously
        /// </summary>
        public string? Pagetoken { get; init; }

        /// <summary>
        /// Two-character region code, like CN
        /// </summary>
        public string? Region { get; init; }

        /// <summary>
        /// Restricts the results to places matching the specified type
        /// </summary>
        public string? Type { get; init; }
    }
}
