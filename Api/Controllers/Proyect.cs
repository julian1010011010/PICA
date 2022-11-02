using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

public class ProyectController : ControllerBase
{

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        try
        {
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "Javeriana", new {id= id*2 } }
            };
            return Ok(data);
        }
        catch (Exception e)
        {

            return BadRequest(e);
        } 
    }


}
