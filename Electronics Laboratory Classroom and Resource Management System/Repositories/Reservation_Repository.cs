﻿using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IReservation_Repository
    {
        Task<IEnumerable<Reservation>> GetAllreservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID);
        Task UpdateReservationAsync(int id, int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID);
        Task SoftDeleteReservationAsync(int id);
    }
    public class Reservation_Repository : IReservation_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Reservation_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reservation>> GetAllreservationsAsync()
        {
            return await _context.reservations
                .Include(r => r.User)
                .Include(r => r.Laboratory)
                .Include(r => r.Reservation_Equipments)
                .Include(r => r.Status_Reservation)
                .Where(r => !r.IsDeleted)
                .ToListAsync();
                
        }
        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.reservations
                .Include(r => r.User)
                .Include(r => r.Laboratory)
                .Include(r => r.Reservation_Equipments)
                .Include(r => r.Status_Reservation)
                .FirstOrDefaultAsync(r => r.Reservation_ID == id && !r.IsDeleted);
        }

        public async Task SoftDeleteReservationAsync(int id)
        {
            var reservation = await _context.reservations.FindAsync(id);
            if (reservation != null)
            {
                reservation.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateReservationAsync(int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            var User = await _context.users.FindAsync(User_ID) ?? throw new Exception("User not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");
            
            var Status = await _context.status_reservations.FindAsync(StatusR_ID) ?? throw new Exception("Status not found");

            var reservationEquipment = new List<Reservation_Equipment>();
            foreach (var equipmentId in Reservation_Equipments)
            {
                var equipment = await _context.reservations_equipment.FindAsync(equipmentId) ?? throw new Exception($"Equipment with ID {equipmentId} not found");
                reservationEquipment.Add(equipment);
            }
            var reservation = new Reservation
            {
                User = User,
                Laboratory = Laboratory,
                Reservation_Equipments = reservationEquipment,
                Reservation_date = Reservation_date,
                Start_time = Start_time,
                End_time = End_time,
                Status_Reservation = Status,
            };

            _context.reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateReservationAsync(int id, int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            var reservation = await _context.reservations
                  .Include(r => r.Reservation_Equipments) // Cargar la lista de equipos
                  .FirstOrDefaultAsync(r => r.Reservation_ID == id) ?? throw new Exception("Reservation not found");
            var User = await _context.users.FindAsync(User_ID) ?? throw new Exception("User not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");
            var Status = await _context.status_reservations.FindAsync(StatusR_ID) ?? throw new Exception("Status not found");

            // Actualizar los equipos reservados
            reservation.Reservation_Equipments.Clear(); // Limpiar equipos anteriores
            foreach (var equipmentId in Reservation_Equipments)
            {
                var equipment = await _context.reservations_equipment.FindAsync(equipmentId) ?? throw new Exception($"Equipment with ID {equipmentId} not found");
                reservation.Reservation_Equipments.Add(equipment);
            }

            reservation.User = User;
            reservation.Laboratory = Laboratory;
            reservation.Reservation_date = Reservation_date;
            reservation.Start_time = Start_time;
            reservation.End_time = End_time;
            reservation.Status_Reservation = Status;

            _context.reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}