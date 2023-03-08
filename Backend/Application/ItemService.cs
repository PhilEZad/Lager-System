using Application.DTO;
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

    public void AddItem(AddItemRequest addItemRequest)
    {
        if (addItemRequest == null  || string.IsNullOrEmpty(addItemRequest.Name))
        {
            throw new ArgumentException("Name must not be empty");
        }
        _itemRepository.AddItem(addItemRequest.Name);
    }

    public Item EditItem(Item item)
    {
        if (item == null){
            throw new NullReferenceException();
        }
        if (string.IsNullOrEmpty(item.Name)){
            throw new ArgumentException("Name must not be empty");
        }
        if (item.Id <= 0){
            throw new ArgumentException("Id must be above 0");
        }     
        Item? returnItem = _itemRepository.EditItem(item);
        if (returnItem == null){
            throw new NullReferenceException();
        }
        if (item.Name != returnItem.Name){
            throw new ArgumentException();
        }
        
        return returnItem;
    }

    public void AddItem(string name)
    {
        throw new NotImplementedException();
    }

    public Item DeleteItem(int id)
    {
       return _itemRepository.DeleteItem(id);
    }
}