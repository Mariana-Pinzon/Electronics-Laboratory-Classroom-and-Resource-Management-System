﻿// <auto-generated />
using System;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    [DbContext(typeof(ElectronicsLaboratoryClassroomandResourceDBContext))]
    [Migration("20240907223134_Settings-First-migration")]
    partial class SettingsFirstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Equipment", b =>
                {
                    b.Property<int>("Equipment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Equipment_ID"));

                    b.Property<DateTime>("Acquisition_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Laboratory_ID")
                        .HasColumnType("int");

                    b.Property<int>("Status_EquipmentStatusE_ID")
                        .HasColumnType("int");

                    b.HasKey("Equipment_ID");

                    b.HasIndex("Laboratory_ID");

                    b.HasIndex("Status_EquipmentStatusE_ID");

                    b.ToTable("equipments");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Inventory", b =>
                {
                    b.Property<int>("Inventory_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Inventory_ID"));

                    b.Property<int>("Available_quantity")
                        .HasColumnType("int");

                    b.Property<int>("Equipment_ID")
                        .HasColumnType("int");

                    b.Property<int>("Laboratory_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Last_update")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total_quantity")
                        .HasColumnType("int");

                    b.HasKey("Inventory_ID");

                    b.HasIndex("Equipment_ID");

                    b.HasIndex("Laboratory_ID");

                    b.ToTable("inventories");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Laboratory", b =>
                {
                    b.Property<int>("Laboratory_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Laboratory_ID"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Laboratory_Num")
                        .HasColumnType("int");

                    b.HasKey("Laboratory_ID");

                    b.ToTable("laboratories");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation", b =>
                {
                    b.Property<int>("Reservation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_ID"));

                    b.Property<TimeOnly>("End_time")
                        .HasColumnType("time");

                    b.Property<int>("Laboratory_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Reservation_date")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("Start_time")
                        .HasColumnType("time");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Reservation_ID");

                    b.HasIndex("Laboratory_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation_Equipment", b =>
                {
                    b.Property<int>("ReservationE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationE_ID"));

                    b.Property<int>("Equipment_ID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ReservationE_ID");

                    b.HasIndex("Equipment_ID");

                    b.ToTable("reservations_equipment");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation_History", b =>
                {
                    b.Property<int>("History_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("History_ID"));

                    b.Property<DateTime>("Modification_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reservation_ID")
                        .HasColumnType("int");

                    b.Property<int>("Status_ReservationStatusR_ID")
                        .HasColumnType("int");

                    b.HasKey("History_ID");

                    b.HasIndex("Reservation_ID");

                    b.HasIndex("Status_ReservationStatusR_ID");

                    b.ToTable("reservations_history");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Equipment", b =>
                {
                    b.Property<int>("StatusE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusE_ID"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusE_ID");

                    b.ToTable("status_equipments");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Reservation", b =>
                {
                    b.Property<int>("StatusR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusR_ID"));

                    b.Property<string>("StatusR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusR_ID");

                    b.ToTable("status_reservations");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Type_ID")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.HasIndex("User_Type_ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Type", b =>
                {
                    b.Property<int>("User_Type_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Type_ID"));

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Type_ID");

                    b.ToTable("user_types");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Equipment", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("Laboratory_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Equipment", "Status_Equipment")
                        .WithMany()
                        .HasForeignKey("Status_EquipmentStatusE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratory");

                    b.Navigation("Status_Equipment");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Inventory", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("Equipment_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("Laboratory_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("Laboratory_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation_Equipment", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("Equipment_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation_History", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("Reservation_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Reservation", "Status_Reservation")
                        .WithMany()
                        .HasForeignKey("Status_ReservationStatusR_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Status_Reservation");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Type", "User_Type")
                        .WithMany()
                        .HasForeignKey("User_Type_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_Type");
                });
#pragma warning restore 612, 618
        }
    }
}
