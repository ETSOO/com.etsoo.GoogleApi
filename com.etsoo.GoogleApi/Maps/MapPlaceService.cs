using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.GoogleApi.Maps.Place;
using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.GoogleApi.Options;
using com.etsoo.Utils.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

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
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq, CancellationToken token = default)
        {
            var request = new AutocompleteRequest(options.ApiKey, rq);

            var api = $"place/autocomplete/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync(api, GoogleApiCallJsonSerializerContext.Default.AutocompleteResponse, token);
        }

        /// <summary>
        /// Async find place
        /// 异步查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<FindPlaceResponse?> FindPlaceAsync(FindPlaceRQ rq, CancellationToken token = default)
        {
            var request = new FindPlaceRequest(options.ApiKey, rq);

            var api = $"place/findplacefromtext/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync(api, GoogleApiCallJsonSerializerContext.Default.FindPlaceResponse, token);
        }

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq, CancellationToken token = default)
        {
            var request = new SearchPlaceRequest(options.ApiKey, rq);

            var api = $"place/textsearch/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync(api, GoogleApiCallJsonSerializerContext.Default.SearchPlaceResponse, token);
        }

        /// <summary>
        /// Async search common place
        /// 异步查询通用地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async ValueTask<IEnumerable<PlaceCommon>?> SearchCommonPlaceAsync(SearchPlaceRQ rq, CancellationToken token = default)
        {
            var response = await SearchPlaceAsync(rq, token);
            var results = response?.Results;
            if (results == null) return null;

            await Parallel.ForEachAsync(results, new ParallelOptions { MaxDegreeOfParallelism = 5, CancellationToken = token }, async (item, cancellationToken) =>
            {
                if (item.PlaceId == null) return;

                var details = await GetPlaceDetailsAsync(new GetDetailsRQ { PlaceId = item.PlaceId, Language = rq.Language, Region = rq.Region, Fields = PlaceField.Address_Components }, cancellationToken);
                var components = details?.Result.AddressComponents;
                if (components is not null) item.AddressComponents = components;
            });

            return results.Select(item => item.CreateCommon()).WhereNotNull();
        }

        /// <summary>
        /// Async get place details
        /// 异步获取地点细节
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<GetDetailsResponse?> GetPlaceDetailsAsync(GetDetailsRQ rq, CancellationToken token = default)
        {
            var request = new GetDetailsRequest(options.ApiKey, rq);

            var api = $"place/details/{GetOutput(rq.Output)}?{request.ToQuery()}";

            return await client.GetFromJsonAsync<GetDetailsResponse>(api, GoogleApiCallJsonSerializerContext.Default.GetDetailsResponse, token);
        }
    }
}
