using Application;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;

namespace Test;

public class CategoryServiceTest
{

    [Fact]
    public void CategoryServiceWithNullItemRepository_ShouldThrowNullReferenceExceptionWithMessage()
    {
        Action test = () => new CategoryService(null);

        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void GetAllCategories_WithReturnOfNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.GetAllCategories()).Returns((List<Category>)null);

        Action test = () => categoryService.GetAllCategories();

        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void AddCategory_Empty_Name()
    {
        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Add(new Category { CategoryId = 1, CategoryName = "" }));

        Action test = () => categoryService.Add(new Category { CategoryId = 1, CategoryName = "" });
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditCategory_WithUnnaturalId_ShouldReturnArgumentException()
    {
        var editCategory = new Category
        {
            CategoryId = -1,
            CategoryName = "Name"
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Edit(editCategory));

        // Hvid ID er ugyldigt, retuner ArgumentException
        Action test = () => categoryService.Edit(editCategory);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditCategory_WithEmptyName_ShouldReturnArgumentException()
    {
        var editCategory = new Category
        {
            CategoryId = 1,
            CategoryName = ""
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Edit(editCategory));

        // Hvis item Name ikke er tomt, retunere ArgumentException with message
        Action test = () => categoryService.Edit(editCategory);
        test.Should().Throw<ArgumentException>();
    }

    // Hvis item ikke eksistere i DB, nullReferenceException
    [Fact]
    public void EditCategory_NotExistInDB_ShouldReturnNullReferenceException()
    {
        var category = new Category
        {
            CategoryId = 1,
            CategoryName = "Unedited"
        };
        var editCategory = new Category
        {
            CategoryId = 2,
            CategoryName = "Edited"
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Edit(editCategory)).Returns(() =>
        {
            if (category.CategoryId != editCategory.CategoryId)
            {
                return null;
            }
            category.CategoryName = editCategory.CategoryName;
            return category;
        });

        Action test = () => categoryService.Edit(editCategory);
        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void EditCategory_UnchangedDataInDB_ShouldThrowArgumentException()
    {
        var editCategory = new Category
        {
            CategoryId = 1,
            CategoryName = "Changed"
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Edit(editCategory)).Returns(() =>
        {
            return new Category { CategoryId = editCategory.CategoryId, CategoryName = "Unchanged" };
        });

        Action test = () => categoryService.Edit(editCategory);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditCategory_NullItem_ShouldThrowNullArgumentException()
    {
        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        Action test = () => categoryService.Edit(null);
        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void EditCategory_ReturnNullItem_ShouldThrowNullArgumentException()
    {
        var editCategory = new Category
        {
            CategoryId = 1,
            CategoryName = "Test"
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Edit(editCategory)).Returns(() =>
        {
            return null;
        });

        Action test = () => categoryService.Edit(editCategory);
        test.Should().Throw<NullReferenceException>();
    }


    [Fact]
    public void DeleteCategory_ReturnItemNull_ShouldThrowNullArgumentException()
    {
        var item = new Category
        {
            CategoryName = "Test"
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        categoryRepository.Setup(x => x.Delete(item.CategoryId)).Returns(() =>
        {
            return null;
        });

        Action test = () => categoryService.Delete(item.CategoryId);
        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void DeleteCategory_NullItemId_ShouldThrowNullArgumentException()
    {
        var item = new Category
        {
            CategoryId = 1,
            CategoryName = "Test"
        };

        var categoryRepository = new Mock<ICategoryRepository>();
        CategoryService categoryService = new CategoryService(categoryRepository.Object);

        Action test = () => categoryService.Delete(item.CategoryId);
        test.Should().Throw<NullReferenceException>();
    }
}
