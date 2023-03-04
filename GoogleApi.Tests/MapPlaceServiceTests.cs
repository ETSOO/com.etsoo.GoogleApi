﻿using com.etsoo.GoogleApi.Maps;
using com.etsoo.GoogleApi.Options;
using com.etsoo.GoogleApiModel.Maps.RQ;

namespace GoogleApi.Tests
{
    [TestClass]
    public class MapPlaceServiceTests
    {
        readonly MapPlaceService service;

        public MapPlaceServiceTests()
        {
            service = new MapPlaceService(new MapsOptions
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