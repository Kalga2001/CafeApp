﻿// <auto-generated />
using System;
using CafeApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeApp.Migrations
{
    [DbContext(typeof(CafeAppDbContext))]
    partial class CafeAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CafeApp.DAL.Entity.Cooks", b =>
                {
                    b.Property<Guid>("CooksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DishesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderCount")
                        .HasColumnType("int");

                    b.HasKey("CooksId");

                    b.HasIndex("DishesId");

                    b.ToTable("Cooks");
                });

            modelBuilder.Entity("CafeApp.DAL.Entity.Dishes", b =>
                {
                    b.Property<Guid>("DishesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("cookingTime")
                        .HasColumnType("int");

                    b.HasKey("DishesId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("CafeApp.DAL.Entity.Ingredients", b =>
                {
                    b.Property<Guid>("IngredientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DishesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IngredientsId");

                    b.HasIndex("DishesId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CafeApp.DAL.Entity.Cooks", b =>
                {
                    b.HasOne("CafeApp.DAL.Entity.Dishes", "Dishes")
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("CafeApp.DAL.Entity.Ingredients", b =>
                {
                    b.HasOne("CafeApp.DAL.Entity.Dishes", "Dishes")
                        .WithMany("Ingredients")
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("CafeApp.DAL.Entity.Dishes", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
