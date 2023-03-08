using Application.DTO;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _factionService;
    
    public ItemController(IItemService factionService)
    {
        _factionService = factionService ?? throw new NullReferenceException("Faction Service can not be null.");
    }
    
    [HttpGet]
    
    public List<Item> GetAllItems()
    {
        return _factionService.GetAllItems();
    }

    [HttpPost]
    public void AddItem([FromBody] AddItemRequest dto)
    {
        _factionService.AddItem(dto.Name);
    }

    [HttpDelete]
    [Route("DeleteItem{Id}")]
    public ActionResult<Item> DeleteItem(int Id)
    {
        try
        {
            return Ok(_factionService.DeleteItem(Id));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No Item found at ID" + Id);
        }
    }

}