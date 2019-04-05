﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(CswContext))]
    [Migration("20190405103247_AddNoneOption")]
    partial class AddNoneOption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<int>("PlatoonId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PlatoonId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Enum.Platoon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Platoon");

                    b.HasData(
                        new { Id = 1, Name = "Alchemists" },
                        new { Id = 2, Name = "Borg" },
                        new { Id = 3, Name = "DeliveryOffice" },
                        new { Id = 4, Name = "Fusion" },
                        new { Id = 5, Name = "Jedi" },
                        new { Id = 6, Name = "Klingon" },
                        new { Id = 7, Name = "Machimbombo" },
                        new { Id = 8, Name = "Patinhas" },
                        new { Id = 9, Name = "Rebels" },
                        new { Id = 10, Name = "Skywalkers" },
                        new { Id = 11, Name = "Spartans" },
                        new { Id = 12, Name = "Species" },
                        new { Id = 13, Name = "Typhoon" },
                        new { Id = 14, Name = "Vision" },
                        new { Id = 15, Name = "Vulcan" },
                        new { Id = 16, Name = "None" }
                    );
                });

            modelBuilder.Entity("Domain.Enum.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = 1, Name = "JE" },
                        new { Id = 2, Name = "PE" },
                        new { Id = 3, Name = "SE" }
                    );
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.ProjectAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("PercentageAllocation");

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectAllocations");
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.HasOne("Domain.Enum.Platoon", "Platoon")
                        .WithMany()
                        .HasForeignKey("PlatoonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Enum.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.ProjectAllocation", b =>
                {
                    b.HasOne("Domain.Employee", "Employee")
                        .WithMany("ProjectAllocations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("ProjectAllocations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}