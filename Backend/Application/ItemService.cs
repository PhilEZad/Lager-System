using Application.DTO;
using Application.Helpers;
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
        if (addItemRequest == null)
        {
            throw new NullReferenceException("AddItemRequest is null.");
        }

        Item item = ObjectGenerator.ItemRequestToItem(addItemRequest);

        var validation = _itemValidator.Validate(item, options => options.IncludeRuleSets("Add"));

            if (!validation.IsValid){
            throw new ValidationException(validation.ToString());
        }
        
        Item returnItem = _itemRepository.AddItem(item);

        if (returnItem == null)
        {
            throw new NullReferenceException("Item does not exist in database.");
        }
        
        var returnValidation = _itemValidator.Validate(returnItem);
        if (!returnValidation.IsValid){
            throw new ValidationException(returnValidation.ToString());
        }
        
        return returnItem;
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
            throw new NullReferenceException("Item does not exist in database.");
        }
        
        if (item.Name != returnItem.Name){
            throw new ArgumentException("No change was made to the item.");
        }

        var validationReturn = _itemValidator.Validate(returnItem);
        if (!validationReturn.IsValid){
            throw new ValidationException(validationReturn.ToString());
        }

        return returnItem;
    }
    
    public Boolean DeleteItem(Item item)
    {
        if (item == null){
            throw new NullReferenceException("Item is null.");
        }

        if (item.Id <= 0)
        {
            return false;
        }
        
        int change = _itemRepository.DeleteItem(item.Id);
        
        if (change == 0)
        {
            return false;
        }
        return true;
    }
}