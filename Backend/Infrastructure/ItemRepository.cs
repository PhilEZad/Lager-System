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

    public List<Item> GetAllItems()
    {
        return _dbContext.ItemTable.ToList();
    }

    public void AddItem(string name)
    {
        _dbContext.ItemTable.Add(new Item() { Id = 0, Name = name });
        _dbContext.SaveChanges();
    }

    public Item EditItem(EditItemRequest editItemRequest)
    {
        var itemsList = _dbContext.ItemTable.ToList<Item>();

        if (itemsList[editItemRequest.Id - 1].Id != editItemRequest.Id)
        {
            return null;
        }

        return null;
    }
}