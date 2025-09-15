using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Text.Json;
using System.Globalization;
using service;

namespace back.Controllers;

[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("Auth")]
    [AllowAnonymous]
    public IActionResult Auth([FromBody] Object model)
    {
        
        var token = Token.Create();

        var ret = new JsonResult(new
        {
            data = token

        }

        , new JsonSerializerOptions
        {
            MaxDepth = 20,
            IncludeFields = true,
        });
        return ret;
    }
}