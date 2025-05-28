using Microsoft.AspNetCore.Mvc;
using VentixeCRUD.Data.Entities;
using VentixeCRUD.Services;

namespace VentixeCRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController(EventService eventServices) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEventAsync([FromBody] EventEntity entity)
    {
        await eventServices.CreateEventAsync(entity);
        return Ok(new { message = "Event saved successfully" });
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var eventEntity = await eventServices.GetByIdAsync(id);
        return Ok(eventEntity);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var eventList = await eventServices.GetAllAsync();
        return Ok(eventList);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] EventEntity entity)
    {
        await eventServices.UpdateAsync(entity);
        return Ok(new { message = "Event updated successfully" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await eventServices.DeleteAsync(id);
        return Ok(new { message = "Successfully deleted event" });
    }
    
   
    
   

   
    
    
    
}