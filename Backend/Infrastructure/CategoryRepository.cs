using Infrastructure.Interfaces;
using Domain;

namespace Infrastructure;

public class CategoryRepository: ICategoryRepository
{
    private readonly DatabaseContext _dbContext;
    
    public CategoryRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException("DatabaseContext can not be null.");
    }
    
    public List<Category> GetAllCategories()
    {
        return _dbContext.CategoryTable.ToList();
    }

    public Category GetById(int id)
    {
        return _dbContext.CategoryTable.Find(id);
    }

    public Category Add(Category category)
    {
        _dbContext.CategoryTable.Add(new Category() { CategoryId = 0, CategoryName = category.CategoryName });
        _dbContext.SaveChanges();
        return category;
    }

    public Category Edit(Category category)
    {
        _dbContext.CategoryTable.Update(category);
        _dbContext.SaveChanges();
        return _dbContext.CategoryTable.Find(category.CategoryId);
    }

    public Category? Delete(int id)
    {
        Category? category = _dbContext.CategoryTable.FirstOrDefault(x => x.CategoryId == id);
        _dbContext.CategoryTable.Remove(category);
        _dbContext.SaveChanges();
        return category;
    }
}