using Domain;

namespace Application.DTO;

public class AddItemRequest
{
    public AddItemRequest() { }
    
    public Item AddItemRequestToItem(AddItemRequest itemRequest)
    {
        return new Item
        {
            Id = 0,
            Name = this.Name
        };
    }
    
    public string Name;
}