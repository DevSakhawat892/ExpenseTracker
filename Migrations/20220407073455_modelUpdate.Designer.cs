﻿// <auto-generated />
using System;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpenseTracker.Migrations
{
    [DbContext(typeof(ExpenseTrackerContext))]
    [Migration("20220407073455_modelUpdate")]
    partial class modelUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpenseTracker.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Category")
                        .IsUnique();

                    b.ToTable("ExpenseCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "House Rent"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Water Bill"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Electric Bill"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Groceries"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Uber"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Medications"
                        });
                });

            modelBuilder.Entity("ExpenseTracker.Models.ExpenseDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("ExpenseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExpenseDetails");
                });

            modelBuilder.Entity("ExpenseTracker.Models.ExpenseDetails", b =>
                {
                    b.HasOne("ExpenseTracker.Models.ExpenseCategory", "ExpenseCategory")
                        .WithMany("ExpenseDetails")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseCategory");
                });

            modelBuilder.Entity("ExpenseTracker.Models.ExpenseCategory", b =>
                {
                    b.Navigation("ExpenseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
