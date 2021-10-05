using System.Collections.Generic;
using System.Linq;
using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Data
{
    public interface IFullStackRepository
    {
        User GetUser(int id);
        List<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);

        //Advert methods
        List<Advert> GetAdverts();
        Advert GetAdvert(int id);
        List<Advert> GetAdvertsByUserId(int id);
        Advert CreateAdvert(Advert advert);
        Advert UpdateAdvert(Advert advert);


        //Province Methods
        List<Province> GetProvinces();
    }
    public class FullStackRepository : IFullStackRepository
    {
        private FullStackDbContext _context;
        public FullStackRepository(FullStackDbContext context)
        {
            _context = context;
        }


        public List<User> GetUsers()
        {

            return _context.Users.Include(x => x.Adverts).ToList();
        }

        public User GetUser(int id)
        {
            var user = _context.Users
                .Include(x => x.Adverts)
                .Single(x => x.Id == id);
            
            return user;
           
            //return _context.Users.Find(id);
        }

        public User CreateUser(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {

            var existing = _context.Users.SingleOrDefault(em => em.Id == user.Id);
            if (existing == null) return null;

            _context.Entry(existing).State = EntityState.Detached;
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var entity = _context.Users.Find(id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        //Advert methods

        public List<Advert> GetAdverts()
        {

            return _context.Adverts.ToList();
        }

        public Advert GetAdvert(int id)
        { 
            return _context.Adverts.Find(id);
        }

        public List<Advert> GetAdvertsByUserId(int id)
        {

            List<Advert> userAdverts = _context.Adverts
                 .Include(u => u.User)
                 .Where(u => u.UserId == id)
                 .ToList();

            return userAdverts;
        }

        public Advert CreateAdvert(Advert advert)
        {

            _context.Adverts.Add(advert);
            _context.SaveChanges();
            return advert;
        }

        public Advert UpdateAdvert(Advert advert)
        {

            var existing = _context.Adverts.SingleOrDefault(em => em.Id == advert.Id);
            if (existing == null) return null;

            _context.Entry(existing).State = EntityState.Detached;
            _context.Adverts.Attach(advert);
            _context.Entry(advert).State = EntityState.Modified;
            _context.SaveChanges();
            return advert;
        }

        //Province Methods
        public List<Province> GetProvinces()
        {

            return _context.Provinces.Include(x => x.Cities).ToList();
        }

    }

}

