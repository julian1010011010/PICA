using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

public class ProyectController : ControllerBase
{
    private readonly dbContext _context;
    public ProyectController(dbContext context)
    {

        _context = context;
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
