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

    public void AddItem(string name)
    {
        _dbContext.ItemTable.Add(new Item(){Id = 0,Name = name});
        _dbContext.SaveChanges();
    }

    public Item DeleteItem(int id)
    {
        Item? item = _dbContext.ItemTable.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            throw new NullReferenceException();
        }
        _dbContext.ItemTable.Remove(item);
        _dbContext.SaveChanges();
        return item;
    }
}