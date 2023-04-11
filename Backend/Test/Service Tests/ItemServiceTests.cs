using Application;
using Application.DTO;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentAssertions;
using FluentValidation;
using Infrastructure.Interfaces;
using Moq;

namespace Test;

public class ItemServiceTests
{
    
    // Test for ItemService constructor
    [Fact]
    public void ItemServiceWithNullItemRepository_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemValidator = new ItemValidator();
        
        Action test = () => new ItemService(null, itemValidator);

        test.Should().Throw<NullReferenceException>().WithMessage("ItemRepository is null.");
    }

    [Fact]
    public void ItemServiceWithNullValidator_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        
        Action test = () => new ItemService(itemRepository.Object, null);

        test.Should().Throw<NullReferenceException>().WithMessage("ItemValidator is null.");
    }
    
    
    // Test for GetAllItems method
    [Fact]
    public void GetAllItems_WithReturnOfNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.GetAllItems()).Returns((List<Item>)null);

        Action test = () => itemService.GetAllItems();

        test.Should().Throw<NullReferenceException>().WithMessage("Unable to fetch items from database.");
    }
  
    // Test for AddItem method
    [Fact]
    public void AddItem_WithItemAsNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);
        
        Action result = () => itemService.AddItem(null);
        
        result.Should().Throw<NullReferenceException>().WithMessage("AddItemRequest is null.");
    }
    
    [Theory]
    [InlineData("", "Name cannot be empty.")]
    [InlineData(null, "Name cannot be empty.")]
    [InlineData("Название теста", "Name may only contain alphanumeric characters.")]
    public void AddItem_WithInvalidName_ShouldThrowValidationExceptionWithMessage(string itemName, string errorMessage)
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        var testItem = new AddItemRequest
        {
            Name = itemName
        };

        Action result = () => itemService.AddItem(testItem);

        result.Should().Throw<ValidationException>().WithMessage(errorMessage);
    }

    /*
     * Test for EditItem method
     */
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(null)]
    public void EditItem_WithInvalidId_ShouldThrowValidationExceptionWithMessage(int id)
    {
        var editItem = new Item
        {
            Id = id,
            Name = "Test"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem));
        
        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ValidationException>().WithMessage("Id must be greater than 0.");
    }

    [Theory]
    [InlineData("", "Name cannot be empty.")]
    [InlineData(null, "Name cannot be empty.")]
    [InlineData("Название теста", "Name may only contain alphanumeric characters.")]
    public void EditItem_WithEmptyName_ShouldReturnValidationExceptWithMessage(string itemName, string errorMessage)
    {
        var editItem = new Item
        {
            Id = 1,
            Name = itemName
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem));
        
        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ValidationException>().WithMessage(errorMessage);
    }
    
    [Fact]
    public void EditItem_ReturnItemAsNull_ShouldReturnNullReferenceExceptionWithMessage()
    {
        var editItem = new Item
        {
            Id = 2,
            Name = "Test  Item"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            return null;
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<NullReferenceException>().WithMessage("Item does not exist in database.");
    }

    [Fact]
    public void EditItem_UnchangedDataInDB_ShouldThrowArgumentException()
    {
        var editItem = new Item
        {
            Id = 1,
            Name = "Changed"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            return new Item { Id = editItem.Id, Name = "Unchanged" };
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditItem_ItemAsNull_ShouldThrowNullReferenceException()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        Action test = () => itemService.EditItem(null);
        test.Should().Throw<NullReferenceException>().WithMessage("Item is null.");
    }

    [Fact]
    public void EditItem_ReturnNullItem_ShouldThrowNullReferenceException()
    {
        var editItem = new Item
        {
            Id = 1,
            Name = "Test"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            return null;
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<NullReferenceException>();
    }
    
    /**
     * Test for DeleteItem method
     */
    [Fact]
    public void DeleteItem_WithValidId_ShouldReturnTrue()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.DeleteItem(1)).Returns(() =>
        {
            return 1;
        });
        
        var testItem = new Item
        {
            Id = 1,
            Name = "Test Item"
        };

        var result = itemService.DeleteItem(testItem);

        result.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void DeleteItem_WithInvalidId_ShouldReturnFalse(int id)
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        var testItem = new Item
        {
            Id = id,
            Name = "Test Item"
        };

        var result = itemService.DeleteItem(testItem);

        result.Should().BeFalse();
    }
    
    [Fact]
    public void DeleteItem_WithNoChangeReturned_ShouldReturnFalse()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        var itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.DeleteItem(1)).Returns(() =>
        {
            return 0;
        });
        
        var testItem = new Item
        {
            Id = 1,
            Name = "Test Item"
        };

        var result = itemService.DeleteItem(testItem);

        result.Should().BeFalse();
    }
    
}