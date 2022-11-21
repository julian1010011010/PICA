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
public class ProjectController : ControllerBase
{
    private readonly dbsoftwareContext _context;

    public ProjectController(dbsoftwareContext context)
    {

        _context = context;
    }


    [HttpGet("RunRabbitMQ")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public void RunRabbitMQ()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost" 
        };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            { 
                channel.QueueDeclare(queue: "ColaPICA", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
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
            Proyecto proyecto = _context.Proyecto.Find(idProject);
            proyecto.EstaDisponible = false;
            _context.SaveChanges();

        }
        catch (Exception)
        {
            updateSucceful = false;
        }

        return updateSucceful;
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
    public IActionResult GetProyectById(int id)
    {
        try
        {
            Proyecto proyecto = new Proyecto();

            proyecto = _context.Proyecto.Find(id);
            return Ok(proyecto);
        }
        catch (Exception e)
        {

            return BadRequest(e);
        }
    }

    [HttpGet("GetListProyect")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetListProyectBy()
    {
        try
        {
            return Ok(_context.Proyecto.ToList());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }


    [HttpPost("CreateProyect")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateProyect(Proyecto pProyecto)
    {
        try
        {
            _context.Proyecto.Add(pProyecto);
            return Ok(_context.SaveChanges());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
