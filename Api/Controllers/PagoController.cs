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

<<<<<<< HEAD:Api/Controllers/Project.cs

    [HttpGet("RunRabbitMQ")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public void RunRabbitMQ()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "172.17.0.4",
        };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ColaPICA", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    int idProject = Int32.Parse(Encoding.UTF8.GetString(body));
                    this.GetChangeStatusProject(idProject);
                };
                channel.BasicConsume(queue: "ColaPICA", autoAck: true, consumer: consumer);
            }
        }
    }


    [HttpGet("GetChangeStatusProject")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool GetChangeStatusProject(int idProject)
    {
        bool updateSucceful = true;
        try
        {
            Proyecto proyecto = _context.Proyecto.Where(r => r.ProyectoId == idProject).FirstOrDefault();
            proyecto.EstaDisponible = false;
            _context.SaveChanges();

        }
        catch (Exception ex)
        {
            updateSucceful = false;
        }

        return updateSucceful;
    }


=======
>>>>>>> ac10ac76229253509601c041799c1929f0dbf4ad:Api/Controllers/PagoController.cs
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
                HostName = "172.17.0.4",
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
