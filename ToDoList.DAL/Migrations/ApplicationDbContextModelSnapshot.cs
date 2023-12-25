﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.DAL.Data;

#nullable disable

namespace ToDoList.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDoList.DAL.Entity.ToDoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalDescription")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Description");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskEndTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("End time");

                    b.Property<DateTime>("TaskStartTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Start time");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdditionalDescription = "Just do nothing",
                            Status = "done",
                            TaskEndTime = new DateTime(2023, 12, 26, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5582),
                            TaskStartTime = new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5542),
                            TaskTitle = "Do nothing1",
                            Type = "feature"
                        },
                        new
                        {
                            Id = 2,
                            AdditionalDescription = "Just do nothing",
                            Status = "in-progress",
                            TaskEndTime = new DateTime(2023, 12, 26, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5592),
                            TaskStartTime = new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5588),
                            TaskTitle = "Do nothing2",
                            Type = "bug"
                        },
                        new
                        {
                            Id = 3,
                            AdditionalDescription = "Just do nothing",
                            Status = "in-progress",
                            TaskEndTime = new DateTime(2023, 12, 26, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5600),
                            TaskStartTime = new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5596),
                            TaskTitle = "Do nothing3",
                            Type = "feature"
                        },
                        new
                        {
                            Id = 4,
                            AdditionalDescription = "Just do nothing",
                            Status = "to-do",
                            TaskEndTime = new DateTime(2023, 12, 27, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5608),
                            TaskStartTime = new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5604),
                            TaskTitle = "Do nothing4",
                            Type = "bug"
                        },
                        new
                        {
                            Id = 5,
                            AdditionalDescription = "Just do nothing",
                            Status = "to-do",
                            TaskEndTime = new DateTime(2023, 12, 28, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5615),
                            TaskStartTime = new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5612),
                            TaskTitle = "Do nothing5",
                            Type = "feature"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
