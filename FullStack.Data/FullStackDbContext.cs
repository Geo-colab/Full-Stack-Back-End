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
        public DbSet<Seller> Sellers{ get; set;}
        public DbSet<PriceInterval> PriceIntervals { get; set; }

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

            //Populate PriceInterval Table
            modelBuilder.Entity<PriceInterval>().HasData(
               new PriceInterval()
               {
                   Id = 1,
                   PriceIntervalValue = 10000m,
                   PriceIntervalDisplay = "R10,000 - R4,999,999"
               }
          ) ;

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 2,
                  PriceIntervalValue = 5000000m,
                  PriceIntervalDisplay = "R5,000,000 - R9,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 3,
                  PriceIntervalValue = 10000000m,
                  PriceIntervalDisplay = "R10,000,000 - R14,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 4,
                  PriceIntervalValue = 15000000m,
                  PriceIntervalDisplay = "R15,000,000 - R19,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 5,
                  PriceIntervalValue = 20000000m,
                  PriceIntervalDisplay = "R20,000,000 - R24,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 6,
                  PriceIntervalValue = 25000000m,
                  PriceIntervalDisplay = "R25,000,000 - R29,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 7,
                  PriceIntervalValue = 30000000m,
                  PriceIntervalDisplay = "R30,000,000 - R34,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 8,
                  PriceIntervalValue = 35000000m,
                  PriceIntervalDisplay = "R35,000,000 - R39,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
             new PriceInterval()
             {
                 Id = 9,
                 PriceIntervalValue = 40000000m,
                 PriceIntervalDisplay = "R40,000,000 - R44,999,999"
             }
        );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 10,
                  PriceIntervalValue = 45000000m,
                  PriceIntervalDisplay = "R45,000,000 - R49,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 11,
                  PriceIntervalValue = 50000000m,
                  PriceIntervalDisplay = "R50,000,000 - R54,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 12,
                  PriceIntervalValue = 55000000m,
                  PriceIntervalDisplay = "R55,000,000 - R59,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 13,
                  PriceIntervalValue = 60000000m,
                  PriceIntervalDisplay = "R60,000,000 - R64,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 14,
                  PriceIntervalValue = 65000000m,
                  PriceIntervalDisplay = "R65,000,000 - R69,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
            new PriceInterval()
            {
                Id = 15,
                PriceIntervalValue = 70000000m,
                PriceIntervalDisplay = "R70,000,000 - R74,999,999"
            }
       );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 16,
                  PriceIntervalValue = 75000000m,
                  PriceIntervalDisplay = "R75,000,000 - R79,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 17,
                  PriceIntervalValue = 80000000m,
                  PriceIntervalDisplay = "R80,000,000 - R84,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 18,
                  PriceIntervalValue = 85000000m,
                  PriceIntervalDisplay = "R85,000,000 - R89,999,999"
              }
         );

            modelBuilder.Entity<PriceInterval>().HasData(
             new PriceInterval()
             {
                 Id = 19,
                 PriceIntervalValue = 90000000m,
                 PriceIntervalDisplay = "R90,000,000 - R94,999,999"
             }
        );

            modelBuilder.Entity<PriceInterval>().HasData(
              new PriceInterval()
              {
                  Id = 20,
                  PriceIntervalValue = 95000000m,
                  PriceIntervalDisplay = "R95,000,000 - R100,000,000"
              }
         );

        }
    }
}
