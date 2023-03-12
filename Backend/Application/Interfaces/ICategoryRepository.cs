using Domain;

namespace Infrastructure.Interfaces;

public interface ICategoryRepository
{
    public List<Category> GetAllCategories();

    public Category GetById(int id);

    public Category Add(Category category);

    public Category Edit(Category category);

    public Category? Delete(int id);
}
