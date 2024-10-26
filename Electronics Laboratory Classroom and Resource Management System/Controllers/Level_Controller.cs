using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Level_Controller : ControllerBase
    {
        private readonly ILevelService _levelService;

        public Level_Controller(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Level>>> GetAlllevels()
        {
            var levels = await _levelService.GetAlllevelsAsync();
            return Ok(levels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Level>> GetLevelById(int id)
        {
            var level = await _levelService.GetLevelByIdAsync(id);
            if (level == null)
                return NotFound();

            return Ok(level);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateLevel(string Level_Name, int ScorePerLevel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _levelService.CreateLevelAsync(Level_Name, ScorePerLevel);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            return StatusCode(StatusCodes.Status201Created, "Level created succesfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLevel(int id, string Level_Name, int ScorePerLevel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingLevel = await _levelService.GetLevelByIdAsync(id);
            if (existingLevel == null)
                return NotFound();

            try
            {
                await _levelService.UpdateLevelAsync(id, Level_Name, ScorePerLevel);
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
        public async Task<IActionResult> SoftDeleteLevel(int id)
        {
            var level = await _levelService.GetLevelByIdAsync(id);
            if (level == null)
                return NotFound();

            await _levelService.SoftDeleteLevelAsync(id);
            return NoContent();

        }
    }
}
