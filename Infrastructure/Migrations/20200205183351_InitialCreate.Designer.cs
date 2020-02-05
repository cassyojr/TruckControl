﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200205183351_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Entities.Truck", b =>
                {
                    b.Property<int>("TruckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int>("TruckModelId")
                        .HasColumnType("int");

                    b.HasKey("TruckId");

                    b.HasIndex("TruckModelId");

                    b.ToTable("Truck");

                    b.HasData(
                        new
                        {
                            TruckId = 1,
                            CreationDate = new DateTime(2020, 2, 5, 15, 33, 50, 999, DateTimeKind.Local).AddTicks(6047),
                            ModelYear = 2021,
                            Name = "Volvo FH16",
                            ProductionYear = 2020,
                            TruckModelId = 1
                        },
                        new
                        {
                            TruckId = 2,
                            CreationDate = new DateTime(2020, 2, 5, 15, 33, 51, 0, DateTimeKind.Local).AddTicks(750),
                            ModelYear = 2021,
                            Name = "Volvo FH",
                            ProductionYear = 2020,
                            TruckModelId = 1
                        },
                        new
                        {
                            TruckId = 3,
                            CreationDate = new DateTime(2020, 2, 5, 15, 33, 51, 0, DateTimeKind.Local).AddTicks(772),
                            ModelYear = 2021,
                            Name = "Volvo FM",
                            ProductionYear = 2020,
                            TruckModelId = 2
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.TruckModel", b =>
                {
                    b.Property<int>("TruckModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TruckModelId");

                    b.ToTable("TruckModel");

                    b.HasData(
                        new
                        {
                            TruckModelId = 1,
                            Name = "FH"
                        },
                        new
                        {
                            TruckModelId = 2,
                            Name = "FM"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Truck", b =>
                {
                    b.HasOne("Infrastructure.Entities.TruckModel", "TruckModel")
                        .WithMany("Trucks")
                        .HasForeignKey("TruckModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
