using Domain;

namespace Application.DTO;

public class AddItemRequest
{
    public Item AddItemRequestToItem(AddItemRequest itemRequest)
    {
        return new Item
        {
            Id = 0,
            Name = itemRequest.Name
        };
    }
    
    public string Name;
}