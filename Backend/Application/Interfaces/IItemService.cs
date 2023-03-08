using Application.DTO;
using Domain;

namespace Application.Interfaces;

public interface IItemService
{
    public List<Item> GetAllItems();
    
    public void AddItem(AddItemRequest addItemRequest);
    public Item EditItem(Item item);

    public void AddItem(string name);

    public Item DeleteItem(int id);

}