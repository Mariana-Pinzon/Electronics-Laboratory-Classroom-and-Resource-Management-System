using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Match_Controller : ControllerBase
    {
        private readonly IMatchService _matchService;

        public Match_Controller(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Match>>> GetAllmatches()
        {
            var matches = await _matchService.GetAllmatchesAsync();
            return Ok(matches);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Equipment>> GetEquipmentById(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
                return NotFound();

            return Ok(match);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMatch(int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _matchService.CreateMatchAsync(User_ID, StartDate, IsFinished, PositionX,  PositionY,  PositionZ, CurrentScore);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            return StatusCode(StatusCodes.Status201Created, "Match started succesfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMatch(int id, int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingMatch = await _matchService.GetMatchByIdAsync(id);
            if (existingMatch == null)
                return NotFound();

            try
            {
                await _matchService.UpdateMatchAsync(id, User_ID, StartDate, IsFinished, PositionX, PositionY, PositionZ, CurrentScore);
                return StatusCode(StatusCodes.Status200OK, "Updated Successfully");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteMatch(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
                return NotFound();

                await _matchService.SoftDeleteMatchAsync(id);
                return NoContent();

        }
    }
}
