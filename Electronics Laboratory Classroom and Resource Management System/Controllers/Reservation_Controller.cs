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
        private readonly IReservationService _reservationServise;
        public Reservation_Controller(IReservationService reservationService)
        {
            _reservationServise = reservationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllreservations()
        {
            var reservations = await _reservationServise.GetAllreservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await _reservationServise.GetReservationByIdAsync(id);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reservationServise.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Reservation_ID }, reservation);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
        {
            if (id != reservation.Reservation_ID)
                return BadRequest();

            var existingReservation = await _reservationServise.GetReservationByIdAsync(id);
            if (existingReservation == null)
                return NotFound();

            await _reservationServise.UpdateReservationAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteReservation(int id)
        {
            var reservation = await _reservationServise.GetReservationByIdAsync(id);
            if (reservation == null)
                return NotFound();

            await _reservationServise.SoftDeleteReservationAsync(id);
            return NoContent();
        }
    }
}
