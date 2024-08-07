using com.etsoo.GoogleApi.Cloud;
using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.GoogleApi.Options;

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
                CredentialsPath = "C:\\api\\pelagic-pod-350823-9274363e3d6b.json",
                TranslateProjectId = "projects/454308927445"
            });
        }

        [TestMethod]
        public async Task TranslateTextAsyncTest()
        {
            var result = await service.TranslateTextAsync(new TranslateTextRQ
            {
                Text= "���",
                SourceLanguageCode = "zh",
                TargetLanguageCode = "en"
            });

            Assert.AreEqual("Hello", result);
        }
    }
}