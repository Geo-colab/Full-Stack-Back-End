﻿// <auto-generated />
using FullStack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStack.Data.Migrations
{
    [DbContext(typeof(FullStackDbContext))]
    [Migration("20211018070506_clone-update")]
    partial class cloneupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FullStack.Data.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdvertDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdvertHead")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdvertState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("FullStack.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Johannesburg",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pretoria",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bloemfontein",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Welkom",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cape Town",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Stellenbosch",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Durban",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Petermaritzburg",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Polokwane",
                            ProvinceId = 5
                        },
                        new
                        {
                            Id = 10,
                            Name = "Modimolle",
                            ProvinceId = 5
                        });
                });

            modelBuilder.Entity("FullStack.Data.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gauteng"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Free State"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Western Cape"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kwazulu-Natal"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Limpopo"
                        });
                });

            modelBuilder.Entity("FullStack.Data.Entities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("FullStack.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Bernard",
                            LastName = "Strauss",
                            Password = "Bernard123",
                            Role = "Admin",
                            Username = "bernards@welcomehome.co.za"
                        });
                });

            modelBuilder.Entity("FullStack.Data.Entities.Advert", b =>
                {
                    b.HasOne("FullStack.Data.Entities.User", "User")
                        .WithMany("Adverts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStack.Data.Entities.City", b =>
                {
                    b.HasOne("FullStack.Data.Entities.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStack.Data.Entities.Seller", b =>
                {
                    b.HasOne("FullStack.Data.Entities.User", null)
                        .WithOne("Seller")
                        .HasForeignKey("FullStack.Data.Entities.Seller", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
