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
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService ?? throw new NullReferenceException("Faction Service can not be null.");
    }

    [HttpGet]

    public List<Item> GetAllItems()
    {
        return _itemService.GetAllItems();
    }

    [HttpGet]
    [Route("{id}")]
    public Item GetFieldFromId([FromRoute] int id)
    {
        return _itemService.getItemFromId(id);
    }

    [HttpPost]
    public Item AddItem([FromBody] Item item)
    {
        return _itemService.AddItem(item);
    }

    [HttpPut]
    public Item EditItem([FromBody] Item item)
    {
        return _itemService.EditItem(item);
    }

    [HttpDelete]
    [Route("DeleteItem{Id}")]
    public ActionResult<Item> DeleteItem(int Id)
    {
        try
        {
            return Ok(_itemService.DeleteItem(Id));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No Item found at ID" + Id);
        }
    }
}