using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;

namespace Application;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    
    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository ?? throw new NullReferenceException("ItemRepository is null.");
    }
    
    public List<Item> GetAllItems()
    {
        List<Item> itemList = _itemRepository.GetAllItems();
        
        if (itemList == null)
        {
            throw new NullReferenceException("Unable to fetch items from database.");
        }

        return itemList;
    }

    public void AddItem(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name must not be empty");
        }
        _itemRepository.AddItem(name);
    }
}