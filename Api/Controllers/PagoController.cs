using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class PagoController : ControllerBase
{
    private readonly dbsoftwareContext _context;

    public PagoController(dbsoftwareContext context)
    { 
        _context = context;
    }
      
    [HttpGet("GetList")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetList()
    {
        try
        {
            List<dynamic> ListOjal = new List<dynamic>
            {
                new
                {
                    Nombre = "El Edgar ALias Taranga",
                     Padres ="Hijo de la nada"
                },
                new
                {
                    Nombre = "El Oscar ALias matamba",
                    Padres ="No registra"
                },
                new
                {
                    Nombre = "Laura la peligrosa",
                     Padres ="Hija de la nada"
                },

                new
                {
                    Nombre = "Julian Alias Sutanga",
                    Padres = "No registra"
                }
            };
            return Ok(ListOjal);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetPagoById(int id)
    {
        try
        { 
            return Ok(_context.Pago.Find(id));
        }
        catch (Exception e)
        {

            return BadRequest(e);
        }
    }

    [HttpGet("GetListPagos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetListPagosBy()
    {
        try
        {
            return Ok(_context.Pago.ToList());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }


    [HttpPost("CreatePago")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateProyect(Pago pPago)
    {
        try
        {
            _context.Pago.Add(pPago);
            return Ok(_context.SaveChanges());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
