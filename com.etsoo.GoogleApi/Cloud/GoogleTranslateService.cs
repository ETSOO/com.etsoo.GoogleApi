using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.GoogleApi.Options;
using Google.Api.Gax.Grpc.Rest;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translate.V3;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace com.etsoo.GoogleApi.Cloud
{
    /// <summary>
    /// Translate service
    /// 翻译服务
    /// </summary>
    public class GoogleTranslateService : IGoogleTranslateService
    {
        private readonly GoogleTranslateOptions options;
        private readonly Lazy<Task<TranslationServiceClient>> _client;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        public GoogleTranslateService(GoogleTranslateOptions options)
        {
            this.options = options;

            _client = new Lazy<Task<TranslationServiceClient>>(async () =>
            {
                var credential = CredentialFactory.FromFile<ServiceAccountCredential>(options.CredentialsPath);
                credential.Scopes = ["https://www.googleapis.com/auth/cloud-platform"];

                var builder = new TranslationServiceClientBuilder
                {
                    Credential = credential,
                    GrpcAdapter = options.IsREST is true
                        ? RestGrpcAdapter.Default
                        : null
                };

                return await builder.BuildAsync();
            });
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        [ActivatorUtilitiesConstructor]
        public GoogleTranslateService(IOptions<GoogleTranslateOptions> options)
            : this(options.Value)
        {

        }

        /// <summary>
        /// Detect language of the text
        /// 探测文本的语言
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Detected language code</returns>
        public async Task<string?> DetectLanguageAsync(string text, CancellationToken cancellationToken = default)
        {
            var client = await _client.Value;

            var response = await client.DetectLanguageAsync(new DetectLanguageRequest
            {
                Parent = options.TranslateProjectId,
                Content = text
            }, cancellationToken);

            return response.Languages.OrderByDescending(l => l.Confidence).Select(l => l.LanguageCode).FirstOrDefault();
        }

        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Translated text</returns>
        public async Task<string> TranslateTextAsync(TranslateTextRQ rq, CancellationToken cancellationToken = default)
        {
            var client = await _client.Value;

            var request = new TranslateTextRequest
            {
                Contents = { rq.Text },
                SourceLanguageCode = rq.SourceLanguageCode,
                TargetLanguageCode = rq.TargetLanguageCode,
                Parent = options.TranslateProjectId
            };

            var response = await client.TranslateTextAsync(request, cancellationToken);
            var translation = response.Translations[0];

            return translation.TranslatedText;
        }
    }
}
