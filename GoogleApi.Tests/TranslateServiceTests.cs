using com.etsoo.GoogleApi.Cloud;
using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.GoogleApi.Options;
using Google.Api.Gax.ResourceNames;

namespace GoogleApi.Tests
{
    [TestClass]
    public class TranslateServiceTests
    {
        readonly GoogleTranslateService service;

        public TranslateServiceTests()
        {
            service = new GoogleTranslateService(new GoogleTranslateOptions
            {
                // The path to the credentials file to use
                // Sign in Google Cloud Console, BridgeApi, APIs & Services > Credentials, create a service account and download the JSON file
                CredentialsPath = "C:\\api\\pelagic-pod-350823-30afcb4dea3b.json",
                TranslateProjectId = new ProjectName("pelagic-pod-350823").ToString(),
                IsREST = true
            });
        }

        [TestMethod]
        public async Task DetectLanguageAsyncTest()
        {
            var result = await service.DetectLanguageAsync("Hi, ÄãºÃ", TestContext.CancellationToken);

            Assert.AreEqual("zh-CN", result);
        }

        [TestMethod]
        public async Task TranslateTextAsyncTest()
        {
            var result = await service.TranslateTextAsync(new TranslateTextRQ
            {
                Text= "ÄãºÃ",
                SourceLanguageCode = "zh",
                TargetLanguageCode = "en"
            }, TestContext.CancellationToken);

            Assert.AreEqual("Hello", result);
        }

        public TestContext TestContext { get; set; }
    }
}