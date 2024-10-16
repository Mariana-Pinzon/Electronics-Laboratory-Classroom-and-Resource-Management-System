using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Reservation_Controller : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public Reservation_Controller(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllreservations()
        {
            var reservations = await _reservationService.GetAllreservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReservation(int User_ID, int Laboratory_ID, [FromQuery] List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reservationService.CreateReservationAsync(User_ID, Laboratory_ID, Reservation_Equipments, Reservation_date, Start_time, End_time, StatusR_ID);
            return StatusCode(StatusCodes.Status201Created, "Reservation created succesfully");
        } 

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<IActionResult> UpdateReservation(int id, int User_ID, int Laboratory_ID, [FromQuery] List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            var existingReservation = await _reservationService.GetReservationByIdAsync(id);
            if (existingReservation == null)
                return NotFound();

            try
            {
                await _reservationService.UpdateReservationAsync(id, User_ID, Laboratory_ID, Reservation_Equipments, Reservation_date, Start_time, End_time, StatusR_ID);
                return StatusCode(StatusCodes.Status200OK, "Updated Successfully");
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteReservation(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
                return NotFound();

            try
            {
                await _reservationService.SoftDeleteReservationAsync( id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }
    }
}
