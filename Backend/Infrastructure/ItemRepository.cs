using Domain;
using Infrastructure.Interfaces;

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

    public Item AddItem(Item item)
    {
        _dbContext.ItemTable.Add(item);
        _dbContext.SaveChanges();
        return _dbContext.ItemTable.Find(item.Id);
    }

    public Item? EditItem(Item item)
    {
        _dbContext.ItemTable.Update(item);
        _dbContext.SaveChanges();
        return _dbContext.ItemTable.Find(item.Id);
    }

    public bool DeleteItem(int id)
    {
        throw new NotImplementedException();
    }
}