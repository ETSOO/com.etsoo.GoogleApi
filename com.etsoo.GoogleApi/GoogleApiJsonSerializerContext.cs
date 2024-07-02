using System.Text.Json.Serialization;

namespace com.etsoo.GoogleApi
{
    /// <summary>
    /// Google API JSON serializer context
    /// 谷歌API JSON序列化上下文
    /// </summary>
    [JsonSourceGenerationOptions(
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonKnownNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    )]
    [JsonSerializable(typeof(Cloud.RQ.TranslateTextRQ))]
    [JsonSerializable(typeof(Maps.Place.RQ.MapBaseRQ))]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    public partial class GoogleApiJsonSerializerContext : JsonSerializerContext
    {
    }

    /// <summary>
    /// Google API call JSON serializer context
    /// 谷歌API调用JSON序列化上下文
    /// </summary>
    [JsonSourceGenerationOptions(
        PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
        DictionaryKeyPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    )]
    [JsonSerializable(typeof(Auth.GoogleRefreshTokenData))]
    [JsonSerializable(typeof(Auth.GoogleTokenData))]
    [JsonSerializable(typeof(Auth.GoogleUserInfo))]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    internal partial class GoogleApiCallJsonSerializerContext : JsonSerializerContext
    {
    }
}
