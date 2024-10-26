using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchLevel_Controller : ControllerBase
    {
        private readonly IMatchLevelService _matchlevelService;

        public MatchLevel_Controller(IMatchLevelService matchlevelService)
        {
            _matchlevelService = matchlevelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MatchLevel>>> GetAllMatchesLevel()
        {
            var matcheslevel = await _matchlevelService.GetAllMatchesLevelAsync();
            return Ok(matcheslevel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MatchLevel>> GetMatchLevelById(int id)
        {
            var matchlevel = await _matchlevelService.GetMatchLevelByIdAsync(id);
            if (matchlevel == null)
                return NotFound();

            return Ok(matchlevel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMatchLevel(int Match_ID, int Level_ID, int PointsEarned)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _matchlevelService.CreateMatchLevelAsync(Match_ID, Level_ID, PointsEarned);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            return StatusCode(StatusCodes.Status201Created, "MatchLevel created succesfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMatchLevel(int id, int Match_ID, int Level_ID, int PointsEarned)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingMatchLevel = await _matchlevelService.GetMatchLevelByIdAsync(id);
            if (existingMatchLevel == null)
                return NotFound();

            try
            {
                await _matchlevelService.UpdateMatchLevelAsync(id, Match_ID, Level_ID, PointsEarned);
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
        public async Task<IActionResult> SoftDeleteMatchLevel(int id)
        {
            var matchlevel = await _matchlevelService.GetMatchLevelByIdAsync(id);
            if (matchlevel == null)
                return NotFound();

            await _matchlevelService.SoftDeleteMatchLevelAsync(id);
            return NoContent();

        }
    }
}
