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

    [HttpPost]
    public void AddItem([FromBody] AddItemRequest dto)
    {
        _itemService.AddItem(dto);
    }

    [HttpPut]
    public Item EditItem([FromBody] Item item ){
        return _itemService.EditItem(item);
    }
}