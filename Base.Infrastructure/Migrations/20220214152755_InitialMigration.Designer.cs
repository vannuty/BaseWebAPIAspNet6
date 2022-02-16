﻿// <auto-generated />
using System;
using Base.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Base.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220214152755_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BaseLibrary.Entities.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AssignedTo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DoneAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedTo = "",
                            CreatedAt = new DateTime(2022, 2, 14, 15, 27, 55, 367, DateTimeKind.Local).AddTicks(709),
                            Deleted = false,
                            Description = "Task 1",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            AssignedTo = "",
                            CreatedAt = new DateTime(2022, 2, 14, 15, 27, 55, 367, DateTimeKind.Local).AddTicks(744),
                            Deleted = false,
                            Description = "Task 2",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            AssignedTo = "",
                            CreatedAt = new DateTime(2022, 2, 14, 15, 27, 55, 367, DateTimeKind.Local).AddTicks(746),
                            Deleted = false,
                            Description = "Task 3",
                            Status = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}