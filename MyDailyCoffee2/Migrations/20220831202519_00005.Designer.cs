﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDailyCoffee2.Model;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220831202519_00005")]
    partial class _00005
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyDailyCoffee2.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MyDailyCoffee2.Model.CustomerPhoneNumber", b =>
                {
                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerId", "PhoneNumber");

                    b.ToTable("CustomerPhoneNumbers");
                });

            modelBuilder.Entity("MyDailyCoffee2.Model.CustomerPhoneNumber", b =>
                {
                    b.HasOne("MyDailyCoffee2.Model.Customer", "Customer")
                        .WithMany("CustomerPhoneNumbers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyDailyCoffee2.Model.Customer", b =>
                {
                    b.Navigation("CustomerPhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
