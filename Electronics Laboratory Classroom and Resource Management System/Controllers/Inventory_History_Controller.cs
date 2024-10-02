using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Inventory_History_Controller : ControllerBase
    {
        private readonly IInventory_HistoryService _inventory_historyServise;
        public Inventory_History_Controller(IInventory_HistoryService inventory_historyService)
        {
            _inventory_historyServise = inventory_historyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Inventory_History>>> GetAllinventories_history()
        {
            var inventory_history = await _inventory_historyServise.GetAllinventories_historyAsync();
            return Ok(inventory_history);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Inventory_History>> GetInventory_HistoryById(int id)
        {
            var inventory_history = await _inventory_historyServise.GetInventory_HistoryByIdAsync(id);
            if (inventory_history == null)
                return NotFound();

            return Ok(inventory_history);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateInventory_History([FromBody] Inventory_History inventory_history)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _inventory_historyServise.CreateInventory_HistoryAsync(inventory_history);
            return CreatedAtAction(nameof(GetInventory_HistoryById), new { id = inventory_history.Inventory_History_ID }, inventory_history);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateInventory_History(int id, [FromBody] Inventory_History inventory_history)
        {
            if (id != inventory_history.Inventory_History_ID)
                return BadRequest();

            var existingInventory_History = await _inventory_historyServise.GetInventory_HistoryByIdAsync(id);
            if (existingInventory_History == null)
                return NotFound();

            await _inventory_historyServise.UpdateInventory_HistoryAsync(inventory_history);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteInventory_History(int id)
        {
            var inventory_history = await _inventory_historyServise.GetInventory_HistoryByIdAsync(id);
            if (inventory_history == null)
                return NotFound();

            await _inventory_historyServise.SoftDeleteInventory_HistoryAsync(id);
            return NoContent();
        }
    }
}
