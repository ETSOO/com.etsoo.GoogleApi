using com.etsoo.GoogleApi.Cloud;
using com.etsoo.GoogleApi.Options;
using com.etsoo.GoogleApiModel.Cloud.RQ;

namespace GoogleApi.Tests
{
    [TestClass]
    public class TranslateServiceTests
    {
        readonly TranslateService service;

        public TranslateServiceTests()
        {
            service = new TranslateService(new TranslateOptions
            {
                CredentialsPath = "C:\\api\\pelagic-pod-350823-9274363e3d6b.json",
                TranslateProjectId = "projects/454308927445"
            });
        }

        [TestMethod]
        public async Task TranslateTextAsyncTest()
        {
            var result = await service.TranslateTextAsync(new TranslateTextRQ
            {
                Text= "ÄãºÃ",
                SourceLanguageCode = "zh",
                TargetLanguageCode = "en"
            });

            Assert.AreEqual("Hello", result);
        }
    }
}