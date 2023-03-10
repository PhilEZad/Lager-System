using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService ?? throw new NullReferenceException("Faction Service can not be null.");
    }

    [HttpGet]

    public List<Category> GetAllItems()
    {
        return _categoryService.GetAllCategories();
    }

    [HttpGet]
    [Route("{id}")]
    public Category GetFieldFromId([FromRoute] int id)
    {
        return _categoryService.GetById(id);
    }

    [HttpPost]
    public Category AddItem([FromBody] Category category)
    {
        return _categoryService.Add(category);
    }

    [HttpPut]
    public Category EditItem([FromBody] Category category)
    {
        return _categoryService.Edit(category);
    }

    [HttpDelete]
    [Route("DeleteItem{Id}")]
    public ActionResult<Category> DeleteItem(int Id)
    {
        try
        {
            return Ok(_categoryService.Delete(Id));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No Item found at ID" + Id);
        }
    }
}
