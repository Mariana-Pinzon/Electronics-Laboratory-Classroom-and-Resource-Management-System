using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Reservation_History_Controller : ControllerBase
    {
        private readonly IReservation_HistoryService _reservation_historyServise;
        public Reservation_History_Controller (IReservation_HistoryService reservation_historyService)
        {
            _reservation_historyServise = reservation_historyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Reservation_History>>> GetAllreservations_history()
        {
            var reservation_history = await _reservation_historyServise.GetAllreservations_historyAsync();
            return Ok(reservation_history);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation_History>> GetReservation_HistoryById(int id)
        {
            var reservation_history = await _reservation_historyServise.GetReservation_HistoryByIdAsync(id);
            if (reservation_history == null)
                return NotFound();

            return Ok(reservation_history);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReservation_History([FromBody] Reservation_History reservation_history)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reservation_historyServise.CreateReservation_HistoryAsync(reservation_history);
            return CreatedAtAction(nameof(GetReservation_HistoryById), new { id = reservation_history.History_ID }, reservation_history);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateReservation_History(int id, [FromBody] Reservation_History reservation_history)
        {
            if (id != reservation_history.History_ID)
                return BadRequest();

            var existingReservation_History = await _reservation_historyServise.GetReservation_HistoryByIdAsync(id);
            if (existingReservation_History == null)
                return NotFound();

            await _reservation_historyServise.UpdateReservation_HistoryAsync(reservation_history);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteReservation_History(int id)
        {
            var reservation_history = await _reservation_historyServise.GetReservation_HistoryByIdAsync(id);
            if (reservation_history == null)
                return NotFound();

            await _reservation_historyServise.SoftDeleteReservation_HistoryAsync(id);
            return NoContent();
        }
    }
}
    

