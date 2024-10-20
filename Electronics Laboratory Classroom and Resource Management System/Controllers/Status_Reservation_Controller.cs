﻿using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Status_Reservation_Controller : ControllerBase
    {
        private readonly IStatus_ReservationService _status_reservationService;
        public Status_Reservation_Controller(IStatus_ReservationService status_reservationService)
        {
            _status_reservationService = status_reservationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Status_Reservation>>> GetAllstatus_reservations()
        {
            var status_reservation = await _status_reservationService.GetAllstatus_reservationsAsync();
            return Ok(status_reservation);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Status_Reservation>> GetStatus_ReservationById(int id)
        {
            var status_reservation = await _status_reservationService.GetStatus_ReservationByIdAsync(id);
            if (status_reservation == null)
                return NotFound();

            return Ok(status_reservation);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<ActionResult> CreateStatus_Reservation(string StatusR)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _status_reservationService.CreateStatus_ReservationAsync(StatusR);
                
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
            return StatusCode(StatusCodes.Status201Created, "StatusReservation created succesfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateStatus_Reservationy(int id, string StatusR)
        {

            var existingstatus_reservation = await _status_reservationService.GetStatus_ReservationByIdAsync(id);
            if (existingstatus_reservation == null)
                return NotFound();

            await _status_reservationService.UpdateStatus_ReservationAsync(id, StatusR);
            return StatusCode(StatusCodes.Status200OK, "Updated Successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteStatus_Reservation(int id)
        {
            var status_reservation = await _status_reservationService.GetStatus_ReservationByIdAsync(id);
            if (status_reservation == null)
                return NotFound();

            try
            {
                await _status_reservationService.SoftDeleteStatus_ReservationAsync(id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}