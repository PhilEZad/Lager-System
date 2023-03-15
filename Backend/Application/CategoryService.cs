using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;

namespace Application;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository ?? throw new NullReferenceException("CategoryRepository is null.");
    }
    public List<Category> GetAllCategories()
    {
        List<Category> categoryList = _repository.GetAllCategories();

        if (categoryList == null)
        {
            throw new NullReferenceException("Unable to fetch categories from database.");
        }

        return categoryList;
    }

    public Category GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Category Add(Category category)
    {
        if (category == null || string.IsNullOrEmpty(category.CategoryName))
        {
            throw new ArgumentException("Name must not be empty");
        }
        return _repository.Add(category);
    }

    public Category Edit(Category category)
    {
        if (category == null)
        {
            throw new NullReferenceException();
        }
        if (string.IsNullOrEmpty(category.CategoryName))
        {
            throw new ArgumentException("Name must not be empty");
        }
        if (category.CategoryId <= 0)
        {
            throw new ArgumentException("Id must be above 0");
        }
        Category? returnCategory = _repository.Edit(category);
        
        if (returnCategory == null)
        {
            throw new NullReferenceException();
        }
        if (category.CategoryName != returnCategory.CategoryName)
        {
            throw new ArgumentException();
        }

        return returnCategory;
    }

    public Boolean Delete(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentNullException("Id must be above 0");
        }
        int change = _repository.Delete(id);
        
        if (change == 0)
        {
            throw new NullReferenceException();
        }
        
        return true;
    }
}

