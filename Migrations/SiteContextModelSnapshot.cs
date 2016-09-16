using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PentiaExcercise.Context;

namespace PentiaEcercise.Migrations
{
    [DbContext(typeof(SiteContext))]
    partial class SiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("PentiaExcercise.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StreetName");

                    b.Property<int>("StreetNumber");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PentiaExcercise.Model.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Extras");

                    b.Property<string>("Model");

                    b.Property<decimal>("RecommendedPrice");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("PentiaExcercise.Model.CarPurchase", b =>
                {
                    b.Property<int>("CarPurchaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<decimal>("PricePaid");

                    b.Property<int>("SalesPersonId");

                    b.HasKey("CarPurchaseId");

                    b.HasIndex("CarId");

                    b.HasIndex("SalesPersonId");

                    b.ToTable("CarPurchases");
                });

            modelBuilder.Entity("PentiaExcercise.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<int>("Age");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("CustomerId");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PentiaExcercise.Model.SalesPerson", b =>
                {
                    b.Property<int>("SalesPersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Salary");

                    b.HasKey("SalesPersonId");

                    b.HasIndex("AddressId");

                    b.ToTable("SalesPersons");
                });

            modelBuilder.Entity("PentiaExcercise.Model.CarPurchase", b =>
                {
                    b.HasOne("PentiaExcercise.Model.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PentiaExcercise.Model.SalesPerson", "SalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PentiaExcercise.Model.Customer", b =>
                {
                    b.HasOne("PentiaExcercise.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PentiaExcercise.Model.SalesPerson", b =>
                {
                    b.HasOne("PentiaExcercise.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
