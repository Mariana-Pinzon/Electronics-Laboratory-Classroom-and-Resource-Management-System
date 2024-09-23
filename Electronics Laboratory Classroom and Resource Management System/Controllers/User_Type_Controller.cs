using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_Type_Controller : ControllerBase
    {
        private readonly IUser_TypeService _user_typeServise;
        public User_Type_Controller (IUser_TypeService user_typeService)
        {
            _user_typeServise = user_typeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<User_Type>>> GetAllUser_Type()
        {
            var user_types = await _user_typeServise.GetAllUser_TypeAsync();
            return Ok(user_types);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User_Type>> GetUser_TypeById(int id)
        {
            var user_type = await _user_typeServise.GetUser_TypeByIdAsync(id);
            if (user_type == null)
                return NotFound();

            return Ok(user_type);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser_Type([FromBody] User_Type user_type)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _user_typeServise.CreateUser_TypeAsync(user_type);
            return CreatedAtAction(nameof(GetUser_TypeById), new { id = user_type.User_Type_ID }, user_type);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUser_Type(int id, [FromBody] User_Type user_type)
        {
            if(id != user_type.User_Type_ID)
                return BadRequest();

            var existingUser_Type = await _user_typeServise.GetUser_TypeByIdAsync(id);
            if(existingUser_Type == null)
                return NotFound();

            await _user_typeServise.UpdateUser_TypeAsync(user_type);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUser_Type(int id)
        {
            var user_type = await _user_typeServise.GetUser_TypeByIdAsync(id);
            if (user_type == null)
                return NotFound();

            await _user_typeServise.SoftDeleteUser_TypeAsync(id);
            return NoContent();
        }
    }
}
