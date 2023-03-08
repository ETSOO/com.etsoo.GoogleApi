using com.etsoo.GoogleApi.Maps.Place;
using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.GoogleApi.Options;
using CommonPlace = com.etsoo.ApiModel.Dto.Maps.Place;

namespace com.etsoo.GoogleApi.Maps
{
    /// <summary>
    /// Map place service interface
    /// 地图地址服务接口
    /// </summary>
    public interface IMapPlaceService
    {
        /// <summary>
        /// Options
        /// 配置参数
        /// </summary>
        MapsOptions Options { get; }

        /// <summary>
        /// Async autocomplete
        /// 异步自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq, CancellationToken token = default);

        /// <summary>
        /// Async find place
        /// 异步查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        Task<FindPlaceResponse?> FindPlaceAsync(FindPlaceRQ rq, CancellationToken token = default);

        /// <summary>
        /// Async get place details
        /// 异步获取地点细节
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        Task<GetDetailsResponse?> GetPlaceDetailsAsync(GetDetailsRQ rq, CancellationToken token = default);

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq, CancellationToken token = default);

        /// <summary>
        /// Async search common place
        /// 异步查询通用地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        ValueTask<IEnumerable<CommonPlace>?> SearchCommonPlaceAsync(SearchPlaceRQ rq, CancellationToken token = default);
    }
}