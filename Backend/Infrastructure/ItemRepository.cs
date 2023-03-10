
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
        _dbContext.ItemTable.Add(new Item() { Id = 0, Name = item.Name });
        _dbContext.SaveChanges();
        return item;
    }


    public Item? EditItem(Item item)
    {
        _dbContext.ItemTable.Update(item);
        _dbContext.SaveChanges();
        return _dbContext.ItemTable.Find(item.Id);


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

    public Item GetItemFromId(int id)
    {
        return _dbContext.ItemTable.Find(id);
    }
}


