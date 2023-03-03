using Application.DTO;
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

    public List<Domain.Item> GetAllItems()
    {
        return _dbContext.ItemTable.ToList();
    }

    public void AddItem(string name)
    {
        _dbContext.ItemTable.Add(new Domain.Item() { Id = 0, Name = name });
        _dbContext.SaveChanges();
    }

    public Domain.Item? EditItem(Domain.Item item)
    {
        _dbContext.ItemTable.Update(item);
        _dbContext.SaveChanges();
        return _dbContext.ItemTable.Find(item.Id);
    }
}