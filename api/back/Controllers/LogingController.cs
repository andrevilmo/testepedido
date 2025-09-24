using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Text.Json;
using System.Globalization;
using service;
using Api.Service.Dto;

namespace back.Controllers;

[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("Auth")]
    [AllowAnonymous]
    public IActionResult Auth([FromBody] Login login)
    {
        if (!"SENHA".Equals(login.Password))
            return new JsonResult(new
            {
                data = string.Empty
            })
            { StatusCode = 401 };
        var token = Token.Create();
        

        var ret = new JsonResult(new
        {
            data = token,
            role = login.User
        }

        , new JsonSerializerOptions
        {
            MaxDepth = 20,
            IncludeFields = true,
        });
        return ret;
    }
}