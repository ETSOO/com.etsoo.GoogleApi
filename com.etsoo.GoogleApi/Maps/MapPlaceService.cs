﻿using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.GoogleApi.Maps.Place;
using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.GoogleApi.Options;
using com.etsoo.Utils.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace com.etsoo.GoogleApi.Maps
{
    /// <summary>
    /// Map place service
    /// 地图地址服务
    /// </summary>
    public class MapPlaceService : IMapPlaceService
    {
        private static string GetOutput(ApiOutput output)
        {
            if (output == ApiOutput.XML) return "xml";
            else return "json";
        }

        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive= true,
            PropertyNamingPolicy = new JsonSnakeNamingPolicy()
        };

        private readonly MapsOptions options;
        private readonly HttpClient client;

        /// <summary>
        /// Options
        /// 配置参数
        /// </summary>
        public MapsOptions Options => options;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="httpClient">HTTP client</param>
        public MapPlaceService(MapsOptions options, HttpClient client)
        {
            client.BaseAddress = new Uri(options.BaseAddress);

            this.options = options;
            this.client = client;
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="httpClient">HTTP client</param>
        [ActivatorUtilitiesConstructor]
        public MapPlaceService(IOptions<MapsOptions> options, HttpClient httpClient)
            : this(options.Value, httpClient)
        {
        }

        /// <summary>
        /// Async autocomplete
        /// 异步自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq)
        {
            var request = new AutocompleteRequest(options.ApiKey, rq);

            var api = $"place/autocomplete/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync<AutocompleteResponse>(api, jsonSerializerOptions);
        }

        /// <summary>
        /// Async find place
        /// 异步查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<FindPlaceResponse?> FindPlaceAsync(FindPlaceRQ rq)
        {
            var request = new FindPlaceRequest(options.ApiKey, rq);

            var api = $"place/findplacefromtext/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync<FindPlaceResponse>(api, jsonSerializerOptions);
        }

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq)
        {
            var request = new SearchPlaceRequest(options.ApiKey, rq);

            var api = $"place/textsearch/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync<SearchPlaceResponse>(api, jsonSerializerOptions);
        }

        /// <summary>
        /// Async get place details
        /// 异步获取地点细节
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<GetDetailsResponse?> GetPlaceDetailsAsync(GetDetailsRQ rq)
        {
            var request = new GetDetailsRequest(options.ApiKey, rq);

            var api = $"place/details/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync<GetDetailsResponse>(api, jsonSerializerOptions);
        }
    }
}
