﻿using System.Text.Json.Serialization;

namespace com.etsoo.GoogleApi
{
    /// <summary>
    /// Google API JSON serializer context
    /// 谷歌API JSON序列化上下文
    /// </summary>
    [JsonSerializable(typeof(Cloud.RQ.TranslateTextRQ))]
    [JsonSerializable(typeof(Maps.Place.RQ.MapBaseRQ))]
    public partial class GoogleApiJsonSerializerContext : JsonSerializerContext
    {
    }

    /// <summary>
    /// Google API call JSON serializer context
    /// 谷歌API调用JSON序列化上下文
    /// </summary>
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    public partial class GoogleApiCallJsonSerializerContext : JsonSerializerContext
    {
    }
}
