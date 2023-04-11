using Application.DTO;
using Domain;

namespace Application.Interfaces;

public interface IItemService
{
    public List<Item> GetAllItems();
    public Item AddItem(AddItemRequest addItemRequest);
    public Item EditItem(Item item);
    public Boolean DeleteItem(Item item);
}