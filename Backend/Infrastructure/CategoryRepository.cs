using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class CategoryRepository: ICategoryRepository
{
    public List<Category> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Category Add(Category category)
    {
        throw new NotImplementedException();
    }

    public Category Edit(Category category)
    {
        throw new NotImplementedException();
    }

    public object? Delete(int id)
    {
        throw new NotImplementedException();
    }
}