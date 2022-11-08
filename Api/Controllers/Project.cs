using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly dbContext _context;

    public ProjectController(dbContext context)
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
