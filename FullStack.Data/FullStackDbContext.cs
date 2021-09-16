using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data
{
    public class FullStackDbContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public FullStackDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("FullStackDataConnex"));
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Bernard",
                    LastName = "Strauss",
                    Username = "bernards@welcomehome.co.za",
                    Password = "Bernard123",
                    Role = Role.Admin
                }
           );
        }
    }
}
