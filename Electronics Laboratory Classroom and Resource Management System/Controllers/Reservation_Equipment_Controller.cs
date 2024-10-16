using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Reservation_Equipment_Controller : ControllerBase
    {
        private readonly IReservation_EquipmentService _reservation_equipmentService;
        public Reservation_Equipment_Controller(IReservation_EquipmentService reservation_equipmentService)
        {
            _reservation_equipmentService = reservation_equipmentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Reservation_Equipment>>> GetAllreservations_equipment()
        {
            var reservation_equipment = await _reservation_equipmentService.GetAllreservations_equipmentAsync();
            return Ok(reservation_equipment);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation_Equipment>> GetReservation_EquipmentById(int id)
        {
            var reservation_equipment = await _reservation_equipmentService.GetReservation_EquipmentByIdAsync(id);
            if (reservation_equipment == null)
                return NotFound();

            return Ok(reservation_equipment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReservation_Equipment(int Equipment_ID, int Quantity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reservation_equipmentService.CreateReservation_EquipmentAsync(Equipment_ID, Quantity);
            return StatusCode(StatusCodes.Status201Created, "Reservation created succesfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<IActionResult> UpdateReservationEquipment(int id, int Equipment_ID, int Quantity)
        {

            var existingReservationEquipment = await _reservation_equipmentService.GetReservation_EquipmentByIdAsync(id);
            if (existingReservationEquipment == null)
                return NotFound();

            try
            {
                await _reservation_equipmentService.UpdateReservation_EquipmentAsync( id, Equipment_ID, Quantity);
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
        public async Task<IActionResult> SoftDeleteReservationEquipment(int id)
        {
            var reservationEquipment = await _reservation_equipmentService.GetReservation_EquipmentByIdAsync(id);
            if (reservationEquipment == null)
                return NotFound();

            try
            {
                await _reservation_equipmentService.SoftDeleteReservation_EquipmentAsync( id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }
    }
}