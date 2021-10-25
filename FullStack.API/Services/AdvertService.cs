using FullStack.API.Helpers;
using FullStack.Data;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Services
{
    public interface IAdvertService
    {
        IEnumerable<AdvertModel> GetAllAdverts();
        AdvertModel GetById(int id);
        IEnumerable<AdvertModel> GetAdvertsByUserId(int id);
        CreateAdvertModel CreateAdvert(CreateAdvertModel advert);
        void Update(AdvertModel userParam);

        IEnumerable<ProvinceModel> GetAllProvinces();
        IEnumerable<CityModel> GetCitiesByProvinceId(int id);

        //PriceInterval Methods
        public IEnumerable<PriceIntervalModel> GetAllPriceIntervals();

        //Search Adverts
        IEnumerable<AdvertModel> SearchAdverts(AdvertSearchModel advertSearchModel);

    }
    public class AdvertService : IAdvertService
    {
        private IFullStackRepository _repo;

        public AdvertService(IFullStackRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<AdvertModel> GetAllAdverts()
        {
            var advertList = _repo.GetAdverts();
            return advertList.Select(u => MapAdvertModel(u));
        }

        public AdvertModel GetById(int id)
        {
            var advertEntity = _repo.GetAdvert(id);
            if (advertEntity == null) return null;

            return MapAdvertModel(advertEntity);
        }

        public IEnumerable<AdvertModel> GetAdvertsByUserId(int id)
        {
            var advertList = _repo.GetAdvertsByUserId(id);
            return advertList.Select(u => MapAdvertModel(u));
        }

        public IEnumerable<ProvinceModel> GetAllProvinces()
        {
            var provinceList = _repo.GetProvinces();
            return provinceList.Select(u => MapProvinceModel(u));
        }

        public IEnumerable<CityModel> GetCitiesByProvinceId(int id)
        {
            var cityList = _repo.GetCitiesByProvinceId(id);
            return cityList.Select(u => MapCityModel(u));
        }

        public CreateAdvertModel CreateAdvert(CreateAdvertModel advert)
        {

            var advertEntity = _repo.CreateAdvert(MapCreateAdvertModel(advert));

            return MapCreateAdvertModel(advertEntity);
        }

        public void Update(AdvertModel userParam)
        {
            var advert = _repo.GetAdverts().Find(x => x.Id == userParam.Id);

            if (advert == null)
                throw new AppException("Advert Not Found");

            advert.Id = userParam.Id;

            if (!string.IsNullOrWhiteSpace(userParam.AdvertHead))
                advert.AdvertHead = userParam.AdvertHead;

            if (!string.IsNullOrWhiteSpace(userParam.AdvertDetails))
                advert.AdvertDetails = userParam.AdvertDetails;
 
            advert.Price = userParam.Price;
            advert.ProvinceId = userParam.ProvinceId;
            advert.CityId = userParam.CityId;
            advert.AdvertState = userParam.AdvertState;


            _repo.UpdateAdvert(advert);

        }

        //PriceInterval methods
        public IEnumerable<PriceIntervalModel> GetAllPriceIntervals()
        {
            var priceIntervals = _repo.GetPriceIntervals();
            return priceIntervals.Select(u => MapPriceIntervalModel(u));
        }

        //SearchAdvert methods
        public IEnumerable<AdvertModel> SearchAdverts(AdvertSearchModel advertSearchModel)
        {
            var searchedAdverts = _repo.SearchAdverts(MapAdvertSearchModel(advertSearchModel));
            List<Advert> sortedSearchedAdverts = searchedAdverts.OrderByDescending(o => o.Price).ToList();
            return sortedSearchedAdverts.Select(u => MapAdvertModel(u));
        }


        //Map Methods
        public Advert MapAdvertModel(AdvertModel advertModel)
        {
            return new Advert
            {
                Id = advertModel.Id,
                AdvertHead = advertModel.AdvertHead,
                AdvertDetails = advertModel.AdvertDetails,
                Price = advertModel.Price,
                AdvertState = advertModel.AdvertState,
                ProvinceId = advertModel.ProvinceId,
                CityId = advertModel.CityId,
                UserId = advertModel.UserId
            };
        }

        public AdvertModel MapAdvertModel(Advert advert)
        {
            var provinceEntity = _repo.GetProvinceById(advert.ProvinceId);
            var provinceModel = MapProvinceModel(provinceEntity);

            var cityEntity = _repo.GetCityById(advert.CityId);
            var cityModel = MapCityModel(cityEntity);

            return new AdvertModel
            {
                Id = advert.Id,
                AdvertHead = advert.AdvertHead,
                AdvertDetails = advert.AdvertDetails,
                Price = advert.Price,
                AdvertState = advert.AdvertState,
                ProvinceId = advert.ProvinceId,
                CityId = advert.CityId,
                UserId = advert.UserId,
                Province = provinceModel,
                City = cityModel

            };
        }

        //Map Province and City to ProvinceModel and CityModel 
        public ProvinceModel MapProvinceModel(Province province)
        {
            return new ProvinceModel
            {

            Id = province.Id,
            Name = province.Name,

            };
        }

        public CityModel MapCityModel(City city)
        {
            return new CityModel
            {
                Id = city.Id,
                Name = city.Name,
                ProvinceId = city.ProvinceId
            };
        }

        public Advert MapCreateAdvertModel( CreateAdvertModel createAdvertModel)
        {
            return new Advert
            {
                AdvertHead = createAdvertModel.AdvertHead,
                AdvertDetails = createAdvertModel.AdvertDetails,
                Price = createAdvertModel.Price,
                AdvertState = createAdvertModel.AdvertState,
                ProvinceId = createAdvertModel.ProvinceId,
                CityId = createAdvertModel.CityId,
                UserId = createAdvertModel.UserId
            };
        }

        public CreateAdvertModel MapCreateAdvertModel(Advert advert)
        {
            return new CreateAdvertModel
            {
                AdvertHead = advert.AdvertHead,
                AdvertDetails = advert.AdvertDetails,
                Price = advert.Price,
                AdvertState = advert.AdvertState,
                ProvinceId = advert.ProvinceId,
                CityId = advert.CityId,
                UserId = advert.UserId
            };
        }

        //Map PriceInterval
        public PriceIntervalModel MapPriceIntervalModel(PriceInterval priceInterval)
        {
            return new PriceIntervalModel
            {
                Id = priceInterval.Id,
                PriceIntervalValue = priceInterval.PriceIntervalValue,
                PriceIntervalDisplay = priceInterval.PriceIntervalDisplay
            };
        }

        public PriceInterval MapPriceIntervalModel(PriceIntervalModel priceIntervalModel)
        {
            return new PriceInterval
            {
                Id = priceIntervalModel.Id,
                PriceIntervalValue = priceIntervalModel.PriceIntervalValue,
                PriceIntervalDisplay = priceIntervalModel.PriceIntervalDisplay
            };
        }

        public AdvertSearch MapAdvertSearchModel(AdvertSearchModel advertSearchModel)
        {
            return new AdvertSearch
            {
               ProvinceId = advertSearchModel.ProvinceId,
               CityId = advertSearchModel.CityId,
               MinPrice = advertSearchModel.MinPrice,
               MaxPrice = advertSearchModel.MaxPrice,
               Keyword = advertSearchModel.Keyword
            };
        }
    }
}
