using Application.DTO;
using Domain;

namespace Application.Interfaces;

public interface IItemService
{
    public List<Item> GetAllItems();
    
    public Item AddItem(Item item);
    public Item EditItem(Item item);

    public Item DeleteItem(int id);
    public Item getItemFromId(int id);
}