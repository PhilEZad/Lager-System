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
}