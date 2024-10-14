﻿// <auto-generated />
using System;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    [DbContext(typeof(ElectronicsLaboratoryClassroomandResourceDBContext))]
    partial class ElectronicsLaboratoryClassroomandResourceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateOnly>("Acquisition_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Laboratory_ID")
                        .HasColumnType("int");

                    b.HasKey("Inventory_ID");

                    b.HasIndex("Equipment_ID");

                    b.HasIndex("Laboratory_ID");

                    b.ToTable("inventories");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Inventory_History", b =>
                {
                    b.Property<int>("Inventory_History_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Inventory_History_ID"));

                    b.Property<string>("Available_quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory_ID")
                        .HasColumnType("int");

                    b.Property<string>("Laboratory_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Inventory_History_ID");

                    b.ToTable("inventories_history");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Laboratory", b =>
                {
                    b.Property<int>("Laboratory_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Laboratory_ID"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Laboratory_Num")
                        .HasColumnType("int");

                    b.HasKey("Laboratory_ID");

                    b.ToTable("laboratories");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Permission", b =>
                {
                    b.Property<int>("Permission_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Permission_ID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Permission_ID");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation", b =>
                {
                    b.Property<int>("Reservation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_ID"));

                    b.Property<TimeOnly>("End_time")
                        .HasColumnType("time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Laboratory_ID")
                        .HasColumnType("int");

                    b.Property<int>("Reservation_EquipmentReservationE_ID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Reservation_date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Start_time")
                        .HasColumnType("time");

                    b.Property<int>("Status_ReservationStatusR_ID")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Reservation_ID");

                    b.HasIndex("Laboratory_ID");

                    b.HasIndex("Reservation_EquipmentReservationE_ID");

                    b.HasIndex("Status_ReservationStatusR_ID");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ReservationE_ID");

                    b.HasIndex("Equipment_ID");

                    b.ToTable("reservations_equipment");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Equipment", b =>
                {
                    b.Property<int>("StatusE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusE_ID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusE_ID");

                    b.ToTable("status_equipments");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Equipment_History", b =>
                {
                    b.Property<int>("Status_Equipment_History_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Status_Equipment_History_ID"));

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusE_ID")
                        .HasColumnType("int");

                    b.HasKey("Status_Equipment_History_ID");

                    b.ToTable("status_equipments_history");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Reservation", b =>
                {
                    b.Property<int>("StatusR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusR_ID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StatusR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusR_ID");

                    b.ToTable("status_reservations");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Reservation_History", b =>
                {
                    b.Property<int>("Status_Reservation_History_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Status_Reservation_History_ID"));

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusR_ID")
                        .HasColumnType("int");

                    b.HasKey("Status_Reservation_History_ID");

                    b.ToTable("status_reservations_history");
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("User_Type_ID")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.HasIndex("User_Type_ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_History", b =>
                {
                    b.Property<int>("User_History_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_History_ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<string>("User_Type_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_History_ID");

                    b.ToTable("users_history");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Permission", b =>
                {
                    b.Property<int>("UserP_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserP_ID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Permission_ID")
                        .HasColumnType("int");

                    b.Property<int>("User_Type_ID")
                        .HasColumnType("int");

                    b.HasKey("UserP_ID");

                    b.HasIndex("Permission_ID");

                    b.HasIndex("User_Type_ID");

                    b.ToTable("user_permissions");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Type", b =>
                {
                    b.Property<int>("User_Type_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Type_ID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Reservation_Equipment", "Reservation_Equipment")
                        .WithMany()
                        .HasForeignKey("Reservation_EquipmentReservationE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Status_Reservation", "Status_Reservation")
                        .WithMany()
                        .HasForeignKey("Status_ReservationStatusR_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratory");

                    b.Navigation("Reservation_Equipment");

                    b.Navigation("Status_Reservation");

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

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Type", "User_Type")
                        .WithMany()
                        .HasForeignKey("User_Type_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_Type");
                });

            modelBuilder.Entity("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Permission", b =>
                {
                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("Permission_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electronics_Laboratory_Classroom_and_Resource_Management_System.Model.User_Type", "User_Type")
                        .WithMany()
                        .HasForeignKey("User_Type_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User_Type");
                });
#pragma warning restore 612, 618
        }
    }
}
