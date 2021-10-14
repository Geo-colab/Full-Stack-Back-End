using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Seller> Seller{ get; set;}

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

            modelBuilder.Entity<Advert>().HasData(
                new Advert()
                {
                    Id = 1,
                   AdvertHead = "Palace in Verce",
                   AdvertDetails = "A large house with 3 bedrooms",
                   Price = 800000.00m,
                   AdvertState = AdvertState.Live,
                   UserId = 2,
                   ProvinceId = 2,
                   CityId = 3
                }
           );

            //Populate Provinces Table
            modelBuilder.Entity<Province>().HasData(
               new Province()
               {
                   Id = 1,
                   Name = "Gauteng"
               }
          );

            modelBuilder.Entity<Province>().HasData(
              new Province()
              {
                  Id = 2,
                  Name = "Free State"
              }
         );

            modelBuilder.Entity<Province>().HasData(
              new Province()
              {
                  Id = 3,
                  Name = "Western Cape"
              }
         );

            modelBuilder.Entity<Province>().HasData(
              new Province()
             {
                  Id = 4,
                  Name = "Kwazulu-Natal"
             }
         );

            modelBuilder.Entity<Province>().HasData(
              new Province()
              {
                  Id = 5,
                  Name = "Limpopo"
              }
         );

            //Populate cities
            modelBuilder.Entity<City>().HasData(
             new City()
             {
                 Id = 1,
                 Name = "Johannesburg",
                 ProvinceId = 1
             }
        );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 2,
                Name = "Pretoria",
                ProvinceId = 1
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 3,
                Name = "Bloemfontein",
                ProvinceId = 2
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 4,
                Name = "Welkom",
                ProvinceId = 2
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 5,
                Name = "Cape Town",
                ProvinceId = 3
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 6,
                Name = "Stellenbosch",
                ProvinceId = 3
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 7,
                Name = "Durban",
                ProvinceId = 4
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 8,
                Name = "Petermaritzburg",
                ProvinceId = 4
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 9,
                Name = "Polokwane",
                ProvinceId = 5
            }
       );

            modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 10,
                Name = "Modimolle",
                ProvinceId = 5
            }
       );

        }
    }
}
