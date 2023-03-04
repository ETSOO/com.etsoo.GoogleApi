﻿using com.etsoo.GoogleApi.Options;
using com.etsoo.GoogleApiModel.Cloud.RQ;
using Google.Cloud.Translate.V3;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace com.etsoo.GoogleApi.Cloud
{
    /// <summary>
    /// Translate service
    /// 翻译服务
    /// </summary>
    public class TranslateService : ITranslateService
    {
        private readonly TranslateOptions options;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        public TranslateService(TranslateOptions options)
        {
            this.options = options;
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        [ActivatorUtilitiesConstructor]
        public TranslateService(IOptions<TranslateOptions> options)
            : this(options.Value)
        {

        }

        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Translated text</returns>
        public async Task<string> TranslateTextAsync(TranslateTextRQ rq)
        {
            var builder = new TranslationServiceClientBuilder
            {
                CredentialsPath = options.CredentialsPath
            };

            var client = await builder.BuildAsync();

            var request = new TranslateTextRequest
            {
                Contents = { rq.Text },
                SourceLanguageCode = rq.SourceLanguageCode,
                TargetLanguageCode = rq.TargetLanguageCode,
                Parent = options.TranslateProjectId
            };

            var response = await client.TranslateTextAsync(request);
            var translation = response.Translations[0];

            return translation.TranslatedText;
        }
    }
}
