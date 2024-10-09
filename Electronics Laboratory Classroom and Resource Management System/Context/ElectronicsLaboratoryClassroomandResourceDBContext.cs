using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Context
{
    public class ElectronicsLaboratoryClassroomandResourceDBContext : DbContext
    {
        public ElectronicsLaboratoryClassroomandResourceDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.User_ID);

            modelBuilder.Entity<Equipment>()
                .HasKey(e => e.Equipment_ID);

            modelBuilder.Entity<Inventory>()
            .HasKey(i => i.Inventory_ID);

            modelBuilder.Entity<Laboratory>()
            .HasKey(l => l.Laboratory_ID);

            modelBuilder.Entity<Reservation>()
            .HasKey(r => r.Reservation_ID);

            modelBuilder.Entity<Status_Equipment>()
            .HasKey(se => se.StatusE_ID);

            modelBuilder.Entity<Status_Reservation>()
            .HasKey(sr => sr.StatusR_ID);

            modelBuilder.Entity<User_Type>()
            .HasKey(ut => ut.User_Type_ID);

            modelBuilder.Entity<Reservation_Equipment>()
            .HasKey(re => re.ReservationE_ID);

            modelBuilder.Entity<Permission>()
            .HasKey(p => p.Permission_ID);

            modelBuilder.Entity<User_Permission>()
            .HasKey(up => up.UserP_ID);

            modelBuilder.Entity<User_History>()
            .HasKey(uh => uh.User_History_ID);

            modelBuilder.Entity<Inventory_History>()
            .HasKey(ih => ih.Inventory_History_ID);

            modelBuilder.Entity<Status_Equipment_History>()
            .HasKey(seh => seh.Status_Equipment_History_ID);

            modelBuilder.Entity<Status_Reservation_History>()
            .HasKey(srh => srh.Status_Reservation_History_ID);

        }

        public DbSet<User> users { get; set; }
        public DbSet<User_Type> user_types { get; set; }
        public DbSet<Laboratory> laboratories { get; set; }
        public DbSet<Equipment> equipments { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Status_Equipment> status_equipments { get; set; }
        public DbSet<Reservation_Equipment> reservations_equipment { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Status_Reservation> status_reservations { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<User_Permission> user_permissions { get; set; }
        public DbSet<User_History> users_history { get; set; }
        public DbSet<Inventory_History> inventories_history { get; set; }
        public DbSet<Status_Equipment_History> status_equipments_history { get; set; }
        public DbSet<Status_Reservation_History> status_reservations_history { get; set; }

    }
}

