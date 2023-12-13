using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M7BookAPI.Controllers;

[ApiController]
[Route("api/[Controller]")]
[Authorize]
public abstract class APIBaseController: ControllerBase
{

    
}
