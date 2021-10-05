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
        IEnumerable<AdvertModel> GetAll();
        AdvertModel GetById(int id);
        IEnumerable<AdvertModel> GetAdvertsByUserId(int id);
        CreateAdvertModel CreateAdvert(CreateAdvertModel advert);
        void Update(AdvertModel userParam);

        IEnumerable<ProvinceModel> GetAllProvinces();

    }
    public class AdvertService : IAdvertService
    {
        private IFullStackRepository _repo;

        public AdvertService(IFullStackRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<AdvertModel> GetAll()
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
            return new AdvertModel
            {
                Id = advert.Id,
                AdvertHead = advert.AdvertHead,
                AdvertDetails = advert.AdvertDetails,
                Price = advert.Price,
                AdvertState = advert.AdvertState,
                ProvinceId = advert.ProvinceId,
                CityId = advert.CityId,
                UserId = advert.UserId

            };
        }

        //Map Province and City to ProvinceModel and CityModel 
        public ProvinceModel MapProvinceModel(Province province)
        {
            return new ProvinceModel
            {
                Id = province.Id,
                Name = province.Name,
                Cities = province.Cities.Select(x => new CityModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                    .ToList()
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


    }
}
