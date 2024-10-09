using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Laboratory_Controller : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryServise;
        public Laboratory_Controller(ILaboratoryService laboratoryService)
        {
            _laboratoryServise = laboratoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Laboratory>>> GetAlllaboratories()
        {
            var laboratories = await _laboratoryServise.GetAlllaboratoriesAsync();
            return Ok(laboratories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Laboratory>> GetLaboratoryById(int id)
        {
            var laboratory = await _laboratoryServise.GetLaboratoryByIdAsync(id);
            if (laboratory == null)
                return NotFound();

            return Ok(laboratory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateLaboratory([FromBody] Laboratory laboratory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _laboratoryServise.CreateLaboratoryAsync(laboratory);
            return CreatedAtAction(nameof(GetLaboratoryById), new { id = laboratory.Laboratory_ID }, laboratory);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateLaboratory(int id, [FromBody] Laboratory laboratory)
        {
            if (id != laboratory.Laboratory_ID)
                return BadRequest();

            var existingLaboratory = await _laboratoryServise.GetLaboratoryByIdAsync(id);
            if (existingLaboratory == null)
                return NotFound();

            await _laboratoryServise.UpdateLaboratoryAsync(laboratory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteLaboratory(int id)
        {
            var laboratory = await _laboratoryServise.GetLaboratoryByIdAsync(id);
            if (laboratory == null)
                return NotFound();

            await _laboratoryServise.SoftDeleteLaboratoryAsync(id);
            return NoContent();
        }
    }
}