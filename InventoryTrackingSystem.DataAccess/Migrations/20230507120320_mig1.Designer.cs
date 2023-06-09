﻿// <auto-generated />
using System;
using InventoryTrackingSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryTrackingSystem.DataAccess.Migrations
{
    [DbContext(typeof(InventoryTrackingSystemContext))]
    [Migration("20230507120320_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InventoryTrackingSystem.Domain.Entities.Inventory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UseCase")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("InventoryTrackingSystem.Domain.Entities.InventoryUseTime", b =>
                {
                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("InventoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("TotalTime")
                        .HasColumnType("interval");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("InventoryId");

                    b.HasIndex("UserId");

                    b.ToTable("InventoryUseTimes");
                });

            modelBuilder.Entity("InventoryTrackingSystem.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InventoryTrackingSystem.Domain.Entities.InventoryUseTime", b =>
                {
                    b.HasOne("InventoryTrackingSystem.Domain.Entities.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("InventoryTrackingSystem.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Inventory");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
