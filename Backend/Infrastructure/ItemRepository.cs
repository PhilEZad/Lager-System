using Domain;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ItemRepository : IItemRepository
{
    private readonly DatabaseContext _dbContext;
    
    public ItemRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException("DatabaseContext can not be null.");
    }

    public List<Item> GetAllItems()
    {
        return _dbContext.ItemTable.ToList();
    }
}