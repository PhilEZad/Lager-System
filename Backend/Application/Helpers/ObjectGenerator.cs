using Application.DTO;
using Domain;

namespace Application.Helpers;

public static class ObjectGenerator
{
    public static Item ItemRequestToItem(AddItemRequest itemDTO)
    {
        return new Item
        {
            Id = 0,
            Name = itemDTO.Name
        };
    }
}