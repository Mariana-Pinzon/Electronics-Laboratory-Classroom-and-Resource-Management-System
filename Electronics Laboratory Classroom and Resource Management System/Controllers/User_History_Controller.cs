using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_History_Controller : ControllerBase
    {
        private readonly IUser_HistoryService _user_historyServise;
        public User_History_Controller(IUser_HistoryService user_historyService)
        {
            _user_historyServise = user_historyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<User_History>>> GetAllusers_history()
        {
            var user_history = await _user_historyServise.GetAllusers_historyAsync();
            return Ok(user_history);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User_History>> GetUser_HistoryById(int id)
        {
            var user_history = await _user_historyServise.GetUser_HistoryByIdAsync(id);
            if (user_history == null)
                return NotFound();

            return Ok(user_history);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser_History([FromBody] User_History user_history)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _user_historyServise.CreateUser_HistoryAsync(user_history);
            return CreatedAtAction(nameof(GetUser_HistoryById), new { id = user_history.User_History_ID }, user_history);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUser_History(int id, [FromBody] User_History user_history)
        {
            if (id != user_history.User_History_ID)
                return BadRequest();

            var existingUser_History = await _user_historyServise.GetUser_HistoryByIdAsync(id);
            if (existingUser_History == null)
                return NotFound();

            await _user_historyServise.UpdateUser_HistoryAsync(user_history);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUser_History(int id)
        {
            var user_history = await _user_historyServise.GetUser_HistoryByIdAsync(id);
            if (user_history == null)
                return NotFound();

            await _user_historyServise.SoftDeleteUser_HistoryAsync(id);
            return NoContent();
        }
    }
}
