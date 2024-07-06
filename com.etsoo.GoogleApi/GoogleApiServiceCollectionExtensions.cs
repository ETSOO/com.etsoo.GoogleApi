using com.etsoo.GoogleApi.Auth;
using com.etsoo.GoogleApi.Cloud;
using com.etsoo.GoogleApi.Maps;
using com.etsoo.GoogleApi.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace com.etsoo.GoogleApi
{
    /// <summary>
    /// Google API service collection extensions
    /// 谷歌API服务集合扩展
    /// </summary>
    public static class GoogleApiServiceCollectionExtensions
    {
        /// <summary>
        /// Add Google auth client
        /// 添加谷歌授权客户端
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="configuration">configuration</param>
        /// <returns>Services</returns>
        public static IServiceCollection AddGoogleAuthClient(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton<IValidateOptions<GoogleAuthOptions>, ValidateGoogleAuthOptions>();
            services.AddOptions<GoogleAuthOptions>().Bind(configuration).ValidateOnStart();
            services.AddHttpClient<IGoogleAuthClient, GoogleAuthClient>();
            return services;
        }

        public static IServiceCollection AddGoogleMapsService(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton<IValidateOptions<GoogleMapsOptions>, ValidateGoogleMapsOptions>();
            services.AddOptions<GoogleMapsOptions>().Bind(configuration).ValidateOnStart();
            services.AddHttpClient<IGoogleMapService, GoogleMapService>();
            return services;
        }

        public static IServiceCollection AddGoogleTranslateService(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton<IValidateOptions<GoogleTranslateOptions>, ValidateGoogleTranslateOptions>();
            services.AddOptions<GoogleTranslateOptions>().Bind(configuration).ValidateOnStart();
            services.AddHttpClient<IGoogleTranslateService, GoogleTranslateService>();
            return services;
        }
    }
}