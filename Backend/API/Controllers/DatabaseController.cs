using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly IDatabaseRepository _databaseRepository;
    
    public DatabaseController(IDatabaseRepository databaseRepository)
    {
        _databaseRepository = databaseRepository ?? throw new NullReferenceException("DatabaseRepository can not be null.");
    }
    
    [HttpGet]
    public void buildDB()
    {
        _databaseRepository.buildDB();
    }
}