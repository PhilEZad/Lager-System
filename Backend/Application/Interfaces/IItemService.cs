using Domain;

namespace Application.Interfaces;

public interface IItemService
{
    public List<Item> GetAllItems();

    public void AddItem(string name);

    public Item DeleteItem(int id);
}