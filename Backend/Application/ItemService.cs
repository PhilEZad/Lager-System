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

    public Item EditItem(EditItemRequest editItemRequest)
    {
        List<Item> itemList = _itemRepository.GetAllItems();

        if (string.IsNullOrEmpty(editItemRequest.Name)){
            throw new ArgumentException("Name must not be empty");
        }
        if (editItemRequest.Id <= 0){
            throw new ArgumentException("Id must be above 0");
        }     
        if (editItemRequest.Id != itemList[editItemRequest.Id - 1].Id){
            throw new ArgumentException();
        }
        
        return null;
    }
}