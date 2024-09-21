using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    public class Controler1
    {
    }
}

[ApiController]
[Route("api/[Controller]")]
public class SubjectController : ControllerBase
{
    private readonly IUser_TypeService _user_typeService;

     public User_TypesController(IUser_Type user_typeService)
    {
        _user_typeService = user_typeService;
    }
}

[HttpGet]
[ProducesReponseType(StatusCodes.Status208OK)]
public async Task<Action<Result<IEnumerable>User_Type>>> GetAllUser_Type()
    {
    var User_Types = await _user_typeService.GetAllUser_TypeAsync();
    return Ok(User_Types);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status208OK)]