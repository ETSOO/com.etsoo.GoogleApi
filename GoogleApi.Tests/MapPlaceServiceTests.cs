using com.etsoo.GoogleApi.Maps;
using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.GoogleApi.Options;

namespace GoogleApi.Tests
{
    [TestClass]
    public class MapPlaceServiceTests
    {
        readonly GoogleMapService service;

        public MapPlaceServiceTests()
        {
            service = new GoogleMapService(new GoogleMapsOptions
            {
                ApiKey = File.ReadAllText("C:\\api\\GoogleMaps.txt")
            }, new HttpClient());
        }

        [TestMethod]
        public async Task FindPlaceAsyncTest()
        {
            var response = await service.FindPlaceAsync(new FindPlaceRQ
            {
                Input = "12A Cranbrook Place, Glendowie, Auckland 1071",
                Fields = PlaceField.Basic,
                Language = "en-NZ"
            });
            Assert.AreEqual("12a Cranbrook Place", response?.Candidates.First().Name);
        }

        [TestMethod]
        public async Task GetDetailsAsyncTest()
        {
            // Teletrac Navman
            var place = (await service.GetPlaceDetailsAsync(new GetDetailsRQ { PlaceId = "ChIJSwRvUEU4DW0R07BlrYJGHZc" }))?.Result;
            Assert.IsNotNull(place);

            Assert.AreEqual("Teletrac Navman NZ", place.Name);
        }

        [TestMethod]
        public async Task SearchPlaceAsyncTest()
        {
            var response = await service.SearchPlaceAsync(new SearchPlaceRQ
            {
                Query = "12A Cranbrook Place, Glendowie, Auckland 1071"
            });

            var first = response?.Results.First();
            Assert.AreEqual("12a Cranbrook Place", first?.Name);

            Assert.IsNotNull(first?.PlaceId);

            var place = (await service.GetPlaceDetailsAsync(new GetDetailsRQ { PlaceId = first.PlaceId }))?.Result;
            Assert.AreEqual("Glendowie", place?.Vicinity);
            Assert.IsTrue(place?.AddressComponents?.Any(ac => ac.Types.Contains("postal_code") && ac.LongName.Equals("1071")));
        }

        [TestMethod]
        public async Task SearchCommonPlaceAsyncTest()
        {
            var results = await service.SearchCommonPlaceAsync(new SearchPlaceRQ
            {
                Query = "12A Cranbrook Place, Glendowie, Auckland 1071"
            });

            var first = results?.FirstOrDefault();
            Assert.IsNotNull(first);

            Assert.AreEqual("1071", first.PostalCode);
            Assert.AreEqual("NZ", first.Region);
            Assert.AreEqual("Auckland", first.State);
            Assert.AreEqual("Auckland", first.City);
            Assert.AreEqual("Glendowie", first.District);
            Assert.AreEqual("Cranbrook Place", first.Route);
            Assert.AreEqual("12a", first.Street);
            Assert.AreEqual("12a Cranbrook Place, Glendowie, Auckland 1071, New Zealand", first.FormattedAddress);
        }

        [TestMethod]
        public async Task SearchCommonPlaceAsyncChinaAddressTest()
        {
            var results = await service.SearchCommonPlaceAsync(new SearchPlaceRQ
            {
                Region = "CN",
                Query = "青岛市玫瑰庭院",
                Language = "zh-CN"
            });

            var first = results?.FirstOrDefault();
            Assert.IsNotNull(first);

            Assert.AreEqual("CN", first.Region);
            Assert.AreEqual("山东省", first.State);
            Assert.AreEqual("山东省青岛市崂山区清溪路玫瑰庭院", first.FormattedAddress);
        }

        [TestMethod]
        public async Task SearchCommonPlaceAsyncChinaAddressFullTest()
        {
            var results = await service.SearchCommonPlaceAsync(new SearchPlaceRQ
            {
                Region = "CN",
                Query = "北京海淀中关村大街59号中国人民大学崇德东楼402室"
            });

            var first = results?.FirstOrDefault();
            Assert.IsNotNull(first);

            Assert.AreEqual("CN", first.Region);
            Assert.AreEqual("北京市", first.State);
            Assert.AreEqual("北京市海淀区中关村大街59号中国人民大学崇德东楼402室", first.FormattedAddress);
        }

        [TestMethod]
        public async Task AutocompleteAsyncTest()
        {
            var sessionToken = Guid.NewGuid().ToString();
            var response = await service.AutoCompleteAsync(new AutocompleteRQ
            {
                Input = "12a Cranbrook Place",
                Region = "NZ",
                SessionToken = sessionToken
            });

            Assert.IsTrue(response?.Predictions.Count() > 3);

            var first = response?.Predictions.First();
            Assert.IsNotNull(first?.PlaceId);

            var place = (await service.GetPlaceDetailsAsync(new GetDetailsRQ { PlaceId = first.PlaceId, SessionToken = sessionToken }))?.Result;
            Assert.AreEqual("Glendowie", place?.Vicinity);
            Assert.IsTrue(place?.AddressComponents?.Any(ac => ac.Types.Contains("postal_code") && ac.LongName.Equals("1071")));
        }
    }
}
