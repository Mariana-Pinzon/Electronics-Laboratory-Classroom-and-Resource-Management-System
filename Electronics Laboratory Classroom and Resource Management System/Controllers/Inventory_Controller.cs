using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Inventory_Controller : ControllerBase
    {
        private readonly Services.IInventoryService _inventoryServise;
        public Inventory_Controller(Services.IInventoryService inventoryService)
        {
            _inventoryServise = inventoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventory()
        {
            var inventories = await _inventoryServise.GetAllInventoryAsync();
            return Ok(inventories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var inventory = await _inventoryServise.GetInventoryByIdAsync(id);
            if (inventory == null)
                return NotFound();

            return Ok(inventory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateInventory([FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _inventoryServise.CreateInventoryAsync(inventory);
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.Inventory_ID }, inventory);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateInventory(int id, [FromBody] Inventory inventory)
        {
            if (id != inventory.Inventory_ID)
                return BadRequest();

            var existingInventory = await _inventoryServise.GetInventoryByIdAsync(id);
            if (existingInventory == null)
                return NotFound();

            await _inventoryServise.UpdateInventoryAsync(inventory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteInventory(int id)
        {
            var inventory = await _inventoryServise.GetInventoryByIdAsync(id);
            if (inventory == null)
                return NotFound();

            await _inventoryServise.SoftDeleteInventoryAsync(id);
            return NoContent();
        }
    }
}
