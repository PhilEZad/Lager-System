using Application.DTO;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using Infrastructure.Interfaces;

namespace Application;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly ItemValidator _itemValidator;
    
    public ItemService(IItemRepository itemRepository, ItemValidator itemValidator)
    {
        _itemRepository = itemRepository ?? throw new NullReferenceException("ItemRepository is null.");
        _itemValidator = itemValidator ?? throw new NullReferenceException("ItemValidator is null.");
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

    public Item AddItem(AddItemRequest addItemRequest)
    {
        _itemRepository.AddItem(addItemRequest.Name);
        
        throw new NotImplementedException();
    }

    public Item EditItem(Item item)
    {
        if (item == null){
            throw new NullReferenceException("Item is null.");
        }
        
        var validation = _itemValidator.Validate(item);
        if (!validation.IsValid){
            throw new ValidationException(validation.ToString());
        }
        
        Item? returnItem = _itemRepository.EditItem(item);
        
        if (returnItem == null){
            throw new NullReferenceException("Return item is null.");
        }

        var validationReturn = _itemValidator.Validate(returnItem);
        if (!validationReturn.IsValid){
            throw new ValidationException(validationReturn.ToString());
        }

        return returnItem;
    }
}