
using Domain;

namespace Infrastructure.Interfaces;

public interface IItemRepository
{
    public List<Item> GetAllItems();
    public Item AddItem(Item item);
    public Item? EditItem(Item item);

    public int DeleteItem(int id);
    public Item GetItemFromId(int id);
}