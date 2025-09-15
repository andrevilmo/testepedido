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
public class PedidoController : ControllerBase
{
    IGravaPedidoService srvGravaPedido;
    public PedidoController(IGravaPedidoService _gravaSrv)
    {
        srvGravaPedido = _gravaSrv;
    }


    [HttpPost("Save")]
    [AllowAnonymous]
    public IActionResult Save([FromBody] GravaPedido model)
    {
        // Deserialize with DateTimeZoneHandling.Utc
        JsonSerializerSettings settingsDateTimeUtc = new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DateFormatString= "yyyy-MM-ddTHH:mm:ss.fffZ",
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss.fffZ") }
        };
        var settings = new JsonSerializerSettings
        {
            //2025-08-13T20:05:00.591Z
            Converters = { new CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss.fffZ") }
        };
        var toSave = JsonConvert.DeserializeObject<List<Pedido>>(model!.ToString()!, settings);
        
        srvGravaPedido.Save(model!);

        var ret = new JsonResult(new
        {
            data = ""

        }

        , new JsonSerializerOptions
        {
            MaxDepth = 20,
            IncludeFields = true,
        });
        return ret;
    }
}
public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _format;

    public CustomDateTimeConverter(string format)
    {
        _format = format;
    }

  public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
       {
        if (reader.TokenType == JsonToken.Date){
            return (DateTime) reader.Value!;
        }
        if (reader.TokenType == JsonToken.Null)
        {
            return default; // Or throw an exception, depending on your null handling
        }
        Console.WriteLine("reader.TokenType: " + reader.TokenType);
        if (reader.TokenType == JsonToken.String)
        {
            /*
            string dateString = reader.Value.ToString();
            if (DateTime.TryParseExact(dateString, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }*/
            string? dateString = reader.Value!.ToString();
            return DateTime.Parse(dateString!,new CultureInfo("pt-BR"));
            // Handle parsing failure, e.g., throw an exception or return a default value
            //throw new JsonSerializationException($"Unable to parse date '{dateString}' with format '{_format}'.");
        }

        throw new JsonSerializationException($"Unexpected token type {reader.TokenType} when deserializing DateTime.");
    }
 

    public override void WriteJson(JsonWriter writer, DateTime value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(_format));
    }
}