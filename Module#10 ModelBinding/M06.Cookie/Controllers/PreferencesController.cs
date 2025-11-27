
using System.Net;
using M06.Cookie.Requests;
using Microsoft.AspNetCore.Mvc;

namespace M06.Cookie.Controllers;

[ApiController]
[Route("[controller]")]
public class PreferencesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var theme = HttpContext.Request.Cookies["theme"];
        var language = HttpContext.Request.Cookies["language"];
        var timeZone = HttpContext.Request.Cookies["timeZone"];

        return Ok(new { Theme = theme, Language = language, TimeZone = timeZone });
    }
}