﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaMenuTest.Models;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240424112832_OrderEntity_LittleUpdate")]
    partial class OrderEntity_LittleUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Ingridient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Ingriddients");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderPizzaOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderPizzaPizzaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WorkerId");

                    b.HasIndex("OrderPizzaOrderId", "OrderPizzaPizzaId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.OrderPizza", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "PizzaId");

                    b.ToTable("MtmOrerPizza");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderPizzaOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderPizzaPizzaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderPizzaOrderId", "OrderPizzaPizzaId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.PizzaIngridient", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("IngridientId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "IngridientId");

                    b.HasIndex("IngridientId");

                    b.ToTable("MtmPizzaIngrindient");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Order", b =>
                {
                    b.HasOne("PizzaMenuTest.Models.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaMenuTest.Models.Entities.Worker", "Worker")
                        .WithMany("Orders")
                        .HasForeignKey("WorkerId");

                    b.HasOne("PizzaMenuTest.Models.Entities.OrderPizza", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderPizzaOrderId", "OrderPizzaPizzaId");

                    b.Navigation("Customer");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Pizza", b =>
                {
                    b.HasOne("PizzaMenuTest.Models.Entities.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId");

                    b.HasOne("PizzaMenuTest.Models.Entities.OrderPizza", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderPizzaOrderId", "OrderPizzaPizzaId");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.PizzaIngridient", b =>
                {
                    b.HasOne("PizzaMenuTest.Models.Entities.Ingridient", "Ingridient")
                        .WithMany()
                        .HasForeignKey("IngridientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaMenuTest.Models.Entities.Pizza", "Pizza")
                        .WithMany("Ingridients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingridient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.OrderPizza", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Pizza", b =>
                {
                    b.Navigation("Ingridients");
                });

            modelBuilder.Entity("PizzaMenuTest.Models.Entities.Worker", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
