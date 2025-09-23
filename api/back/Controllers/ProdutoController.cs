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
[Authorize]
public class ProdutoController : ControllerBase
{
    IProdutoService srvGravaProduto;
    public ProdutoController(IProdutoService _gravaSrv)
    {
        srvGravaProduto = _gravaSrv;
    }
    [HttpPost("Save")] 
    public IActionResult Save([FromBody] Produto model)
    { 
        srvGravaProduto.Save(model!);
        var ret = new JsonResult(new
        {
            data = "OK"

        });
        return ret;
    }
    [HttpDelete("Delete")] 
    public IActionResult Delete([FromBody] Produto model)
    { 
        srvGravaProduto.Delete(model);
        var ret = new JsonResult(new
        {
            data = "OK"
        });
        return ret;
    }
    [HttpGet("Load")]
    public IActionResult Load([FromBody] Produto model)
    { 
        srvGravaProduto.Load(model!.Id);
        var ret = new JsonResult(new
        {
            data = "OK"
        });
        return ret;
    }
    [HttpGet("All")]
    public IActionResult All()
    {
        var allProducts = srvGravaProduto.GetAll();
        var ret = new JsonResult(new
        {
            data = allProducts
        });
        return ret;
    }
}