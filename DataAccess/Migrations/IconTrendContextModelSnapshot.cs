﻿// <auto-generated />
using System;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(IconTrendContext))]
    partial class IconTrendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnnounceContent")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("AnnounceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("AnnounceStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("AnnounceTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Entities.Concrete.Congress", b =>
                {
                    b.Property<int>("CongressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CongressAbout")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CongressCity")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CongressDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CongressName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CongressPlace")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CongressPresidentId")
                        .HasColumnType("int");

                    b.Property<bool>("CongressStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CongressId");

                    b.ToTable("Congresses");
                });

            modelBuilder.Entity("Entities.Concrete.CongressImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CongressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("CongressImages");
                });

            modelBuilder.Entity("Entities.Concrete.CongressPresident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CongressId")
                        .HasColumnType("int");

                    b.Property<string>("CongressPresidentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("CongressPresidents");
                });

            modelBuilder.Entity("Entities.Concrete.RegulatoryBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CongressId")
                        .HasColumnType("int");

                    b.Property<string>("RegulatoryBoardMemberName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Univercity")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("RegulatoryBoards");
                });

            modelBuilder.Entity("Entities.Concrete.ScienceBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CongressId")
                        .HasColumnType("int");

                    b.Property<string>("ScienceBoardMemberName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Univercity")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ScienceBoards");
                });

            modelBuilder.Entity("Entities.Concrete.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CongressId")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Entities.Concrete.TransportLayover", b =>
                {
                    b.Property<int>("TransportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MinDemand")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("TransportId");

                    b.ToTable("TransportLayovers");
                });

            modelBuilder.Entity("Entities.Concrete.TransportLayoverImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TransportLayoverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TransportLayoverImages");
                });
#pragma warning restore 612, 618
        }
    }
}
