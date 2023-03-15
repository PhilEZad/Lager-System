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

    public ActionResult<List<Item>> GetAllItems()
    {
        return Ok(_itemService.GetAllItems());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Item> GetFieldFromId([FromRoute] int id)
    {
        return Ok(_itemService.getItemFromId(id));
    }

    [HttpPost]
    public ActionResult<Item> AddItem([FromBody] Item item)
    {
        return Ok(_itemService.AddItem(item));
    }

    [HttpPut]
    public ActionResult<Item> EditItem([FromBody] Item item)
    {
        return Ok(_itemService.EditItem(item));
    }

    [HttpDelete]
    [Route("DeleteItem{Id}")]
    public ActionResult<Boolean> DeleteItem(int Id)
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