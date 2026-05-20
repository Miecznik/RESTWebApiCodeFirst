using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTWebApiCodeFirst.Data;
using RESTWebApiCodeFirst.DTOs;
using RESTWebApiCodeFirst.Entities;
using RESTWebApiCodeFirst.Exception;
using RESTWebApiCodeFirst.Services;

namespace RESTWebApiCodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PCsController : ControllerBase
{
    
    private readonly IDbService _dbService;
    public PCsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        
        var pCs = await _dbService.GetAllPCs();
        
        return Ok(pCs);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeletePC([FromRoute] int id)
    {
        try
        {
            await _dbService.DeletePC(id);
            return NoContent();
        }
        catch(NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateUser(int id, UpdatePCsDTO pCs)
    {
        try
        {
            await _dbService.UpdatePCsAsync(id, pCs);
            return Ok();   
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        } 
    }
    [HttpPost]
    public async Task<ActionResult<GetPCsDTO>> AddUser(AddPCsDTO pCs)
    {
        var createdPc = await _dbService.AddPCAsync(pCs);
        
        return Created("", createdPc);
   
    }
    

   
}