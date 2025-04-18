﻿// <auto-generated />
using System;
using AdminService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminService.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminService.Domain.Entities.AdminStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("admin_status", "GN");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_at = new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6855),
                            description = "Active",
                            updated_at = new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6864)
                        },
                        new
                        {
                            id = 2,
                            created_at = new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6864),
                            description = "In Active",
                            updated_at = new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6865)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
