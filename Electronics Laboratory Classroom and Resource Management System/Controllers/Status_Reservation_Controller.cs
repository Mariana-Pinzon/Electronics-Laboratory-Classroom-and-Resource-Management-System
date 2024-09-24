using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Status_Reservation_Controller : ControllerBase
    {
        private readonly Services.IStatus_ReservationService _status_reservationServise;
        public Status_Reservation_Controller(Services.IStatus_ReservationService status_reservationService)
        {
            _status_reservationServise = status_reservationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Status_Reservation>>> GetAllStatus_Reservation()
        {
            var status_reservation = await _status_reservationServise.GetAllStatus_ReservationAsync();
            return Ok(status_reservation);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Status_Reservation>> GetStatus_ReservationById(int id)
        {
            var status_reservation = await _status_reservationServise.GetStatus_ReservationByIdAsync(id);
            if (status_reservation == null)
                return NotFound();

            return Ok(status_reservation);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateStatus_Reservation([FromBody] Status_Reservation status_reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _status_reservationServise.CreateStatus_ReservationAsync(status_reservation);
            return CreatedAtAction(nameof(GetStatus_ReservationById), new { id = status_reservation.StatusR_ID }, status_reservation);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateStatus_Reservationy(int id, [FromBody] Status_Reservation status_reservation)
        {
            if (id != status_reservation.StatusR_ID)
                return BadRequest();

            var existingstatus_reservation = await _status_reservationServise.GetStatus_ReservationByIdAsync(id);
            if (existingstatus_reservation == null)
                return NotFound();

            await _status_reservationServise.UpdateStatus_ReservationAsync(status_reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteStatus_Reservation(int id)
        {
            var status_reservation = await _status_reservationServise.GetStatus_ReservationByIdAsync(id);
            if (status_reservation == null)
                return NotFound();

            await _status_reservationServise.SoftDeleteStatus_ReservationAsync(id);
            return NoContent();
        }
    }
}