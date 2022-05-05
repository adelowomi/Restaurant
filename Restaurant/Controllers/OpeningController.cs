using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpeningController : ControllerBase
{
    [HttpPost("format", Name = nameof(FormatOpenings))]
    [ProducesResponseType(200)]
    public ActionResult FormatOpenings(DaysOfTheWeek model)
    {
        return Ok(new DaysOfTheWeek().GetReadableFormat(model));
    }
}

