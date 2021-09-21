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

        //Do the same for all the other entities, Invoices, Invoice Items, etc

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

            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {

            return _context.Users.Find(id);
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



    }

}

