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
        Pago pago = new Pago();
        try
        {
      
            pago = _context.Pago.Find(id);
            return Ok(pago);
        }
        catch (Exception e)
        {
       
            return BadRequest(pago);
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
    public IActionResult CreatePago(Pago pPago)
    {
        try
        {
            _context.Pago.Add(pPago);
            _context.SaveChanges();

            ///Se envia el id del proyecto cuando se crea al bus de 
            ///eventos para que se desactive su disponibilidad

            SendProjectIdBus(Int32.Parse(pPago.IdProyecto));

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    private bool SendProjectIdBus(int pProjetId)
    {
        bool isSuccesfull = true;
        try
        {
            var factory = new ConnectionFactory()
            {
                HostName = "172.17.0.2",
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ColaPICA", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = pProjetId + string.Empty;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: string.Empty, routingKey: "ColaPICA", basicProperties: null, body: body);
                }
            }
        }
        catch (Exception)
        {
            isSuccesfull = false;
        }
        return isSuccesfull;
    }
}
