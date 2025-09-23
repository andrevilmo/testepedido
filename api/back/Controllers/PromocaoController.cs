using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Text.Json;
using System.Globalization;
using Newtonsoft.Json;
using db;
using service.Interfaces;
using Api.Db.Models.Entities;
using Api.Service.Dto;

namespace back.Controllers;

[Route("api/[controller]")]
public class PromocaoController : ControllerBase
{
    IPromocaoService srvGravaPromocao;
    public PromocaoController(IPromocaoService _gravaSrv)
    {
        srvGravaPromocao = _gravaSrv;
    }
    [HttpPost("Save")] 
    public IActionResult Save([FromBody] Promocao model)
    { 
        srvGravaPromocao.Save(model!);
        var ret = new JsonResult(new
        {
            data = "OK"

        });
        return ret;
    }
    [HttpDelete("Delete")] 
    public IActionResult Delete([FromBody] Promocao model)
    { 
        srvGravaPromocao.Delete(model!.Id);
        var ret = new JsonResult(new
        {
            data = "OK"
        });
        return ret;
    }
    [HttpGet("Load")]
    public IActionResult Load([FromBody] Promocao model)
    { 
        srvGravaPromocao.Load(model!.Id);
        var ret = new JsonResult(new
        {
            data = "OK"
        });
        return ret;
    }
}