using Domain;

namespace Application.Interfaces;

public interface IItemService
{
    public List<Item> GetAllItems();
}