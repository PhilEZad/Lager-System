using Domain;

namespace Infrastructure.Interfaces;

public interface IItemRepository
{
    public List<Item> GetAllItems();
}