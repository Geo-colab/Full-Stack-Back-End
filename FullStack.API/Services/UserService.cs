using System.Collections.Generic;
using System.Linq;
using FullStack.API.Helpers;
using FullStack.Data.Entities;
using FullStack.Data;
using FullStack.ViewModels;
using Microsoft.Extensions.Options;

namespace FullStack.API.Services
{
    public interface IUserService
    {
            UserModel Authenticate(string username, string password);
            IEnumerable<UserModel> GetAll();
            UserModel GetById(int id);
            UserModel Create(RegisterModel user, string password);
            UserModel CreateUser(RegisterModel user, string password);
            void Update(UpdateModel user, string password = null);
            void Delete(int id);

             //seller methods
            SellerModel GetSellerByUserId(int id);
            SellerModel CreateSeller(SellerModel seller);
            void UpdateSeller(SellerModel userParam);
        }

        public class UserService : IUserService
        {
            private IFullStackRepository _repo;

        public UserService(IFullStackRepository repo)
            {
                _repo = repo;
        }

            public UserModel Authenticate(string username, string password)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return null;

            var user = _repo.GetUsers().SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null) return null;

            //map from DB entity to UserModel for the front-end
            var userModel = MapUserModel(user);

            // authentication successful
            return userModel;
            }

            public IEnumerable<UserModel> GetAll()
            {
            var userList = _repo.GetUsers();
            return userList.Select(u => MapUserModel(u));
            }

            public UserModel GetById(int id)
            {
            var userEntity = _repo.GetUser(id);
            if (userEntity == null) return null;

            return MapUserModel(userEntity);
        }

            public UserModel Create(RegisterModel user, string password)
            {
                // validation
                if (string.IsNullOrWhiteSpace(password))
                    throw new AppException("Password is required");

                if (_repo.GetUsers().Any(x => x.Username == user.Username))
                    throw new AppException("Username \"" + user.Username + "\" is already taken");

                user.Password = password;
               
                var userEntity = _repo.CreateUser(MapRegisterModelToUser(user)); 

                return MapUserModel(userEntity);
            }

        public UserModel CreateUser(RegisterModel user, string password)
        {

            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_repo.GetUsers().Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            user.Password = password;

            var userEntity = _repo.CreateUser(MapRegisterModelToUser(user));

            return MapUserModel(userEntity);
        }

        public void Update(UpdateModel userParam, string password = null)
            {
                var user = _repo.GetUsers().Find(x => x.Username == userParam.Username);

                if (user == null)
                    throw new AppException("User not found");

                // update username if it has changed
                if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
                {
                    // throw error if the new username is already taken
                    if (_repo.GetUsers().Any(x => x.Username == userParam.Username))
                        throw new AppException("Username " + userParam.Username + " is already taken");

                    user.Username = userParam.Username;
                }

            
            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                if (user.Password != password)
                    throw new AppException("Old password does not correspond with password in database");
                
                user.Password = userParam.NewPassword;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                    user.FirstName = userParam.FirstName;

                if (!string.IsNullOrWhiteSpace(userParam.LastName))
                    user.LastName = userParam.LastName;

               

                _repo.UpdateUser(user);
                
            }

        public void Delete(int id)
            {
                _repo.DeleteUser(id);

            }

        //Seller methods
        public SellerModel GetSellerByUserId(int id)
        {
            var seller = _repo.GetSellers().Find(x => x.UserId == id);
           
            if (seller == null) return null;

            return MapSellerModelToSeller(seller);
        }

        public SellerModel CreateSeller(SellerModel seller)
        {

            var sellerEntity = _repo.CreateSeller(MapSellerModelToSeller(seller));

            return MapSellerModelToSeller(sellerEntity);
        }

        public void UpdateSeller(SellerModel userParam)
        {
            var seller = _repo.GetSellers().Find(x => x.Id == userParam.Id);

            if (seller == null)
                throw new AppException("Seller Not Found");

            seller.Id = userParam.Id;

            if (!string.IsNullOrWhiteSpace(userParam.Email))
                seller.Email = userParam.Email;

            if (!string.IsNullOrWhiteSpace(userParam.Phone))
                seller.Phone = userParam.Phone;

            seller.UserId = userParam.UserId;

            _repo.UpdateSeller(seller);
        }

        // Map Methods
        public UserModel MapUserModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Role = user.Role,
            };
        }

        public User MapUserModel(UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.Username,
                Role = userModel.Role,
            };
        }

        public RegisterModel MapRegisterModelToUser(User user)
        {
            return new RegisterModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };
        }

        public User MapRegisterModelToUser(RegisterModel registerModel)
        {
            return new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Username = registerModel.Username,
                Password = registerModel.Password,
                Role = registerModel.Role
            };
        }

        public SellerModel MapSellerModelToSeller(Seller seller)
        {
            return new SellerModel
            {
                Id = seller.Id,
                Email = seller.Email,
                Phone = seller.Phone,
                UserId = seller.UserId
            };
        }

        public Seller MapSellerModelToSeller(SellerModel sellerModel)
        {
            return new Seller
            {
                Id = sellerModel.Id,
                Email = sellerModel.Email,
                Phone = sellerModel.Phone,
                UserId = sellerModel.UserId
            };
        }


    }
}
