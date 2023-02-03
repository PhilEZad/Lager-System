using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;

namespace Application;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    
    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository ?? throw new NullReferenceException("ItemRepository can not be null.");
    }
    
    public List<Item> GetAllItems()
    {
        throw new NotImplementedException();
    }
}