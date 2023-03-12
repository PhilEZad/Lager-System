using Domain;

namespace Application.Interfaces;

public interface ICategoryService
{

    public List<Category> GetAllCategories();

    public Category GetById(int id);

    public Category Add(Category category);

    public Category Edit(Category category);

    public Category? Delete(int id);
}
