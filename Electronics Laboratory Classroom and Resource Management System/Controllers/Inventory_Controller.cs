using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Inventory_Controller : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public Inventory_Controller(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllinventories()
        {
            var inventories = await _inventoryService.GetAllinventoriesAsync();
            return Ok(inventories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
                return NotFound();

            return Ok(inventory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<ActionResult> CreateInventory(int Equipment_ID, int Available_quantity, int Laboratory_ID, [FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _inventoryService.CreateInventoryAsync(Equipment_ID, Available_quantity, Laboratory_ID, inventory);
                return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.Inventory_ID }, inventory);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> UpdateInventory(int id, int Equipment_ID, int Available_quantity, int Laboratory_ID)
        {
            var existingInventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (existingInventory == null)
                return NotFound();

            try
            {
                await _inventoryService.UpdateInventoryAsync(id, Equipment_ID, Available_quantity, Laboratory_ID);
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
                return NotFound();

            try
            {
                await _inventoryService.SoftDeleteInventoryAsync(id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}