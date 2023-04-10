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
    [Fact]
    public void ItemServiceWithNullItemRepository_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemValidator = new ItemValidator();
        Action test = () => new ItemService(null, itemValidator);

        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void ItemServiceWithNullValidator_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        Action test = () => new ItemService(itemRepository.Object, null);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void GetAllItems_WithReturnOfNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.GetAllItems()).Returns((List<Item>)null);

        Action test = () => itemService.GetAllItems();

        test.Should().Throw<NullReferenceException>();
    }
  
    [Fact]
    public void AddItem_WithEmptyName_ShouldThrowValidationExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        AddItemRequest testItem = new AddItemRequest();
        testItem.Name = "";
        
        Action result = () => itemService.AddItem(testItem);

        result.Should().Throw<ValidationException>().WithMessage("Name cannot be empty.");
    }

    [Theory]
    [InlineData(1, "Item 1")]
    [InlineData(2, "Item 2")]
    [InlineData(3, "Item 3")]
    public void GetAllItems_WithInvalidProperties_ShouldThrowValidationExceptionWithMessage(int id, string name)
    {
        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        Action test = () => itemService.AddItem(new AddItemRequest(""));
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditItem_WithUnnaturalId_ShouldThrowValidationExceptionWithMessage()
    {
        var editItem = new Item
        {
            Id = -1,
            Name = "Name"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem));

        // Hvid ID er ugyldigt, retuner ArgumentException
        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ValidationException>().WithMessage("Id must be above 0.");
    }

    [Fact]
    public void EditItem_WithEmptyName_ShouldReturnArgumentException()
    {
        var editItem = new Item
        {
            Id = 1,
            Name = ""
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem));

        // Hvis item Name ikke er tomt, retunere ArgumentException with message
        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ArgumentException>();
    }

    // Hvis item ikke eksistere i DB, nullReferenceException
    [Fact]
    public void EditItem_NotExistInDB_ShouldReturnNullReferenceException()
    {
        var item = new Item
        {
            Id = 1,
            Name = "Unedited"
        };
        var editItem = new Item
        {
            Id = 2,
            Name = "Edited"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            if (item.Id != editItem.Id)
            {
                return null;
            }
            item.Name = editItem.Name;
            return item;
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<NullReferenceException>();
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
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            return new Item { Id = editItem.Id, Name = "Unchanged" };
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditItem_NullItem_ShouldThrowNullArgumentException()
    {
        var editItem = new Item
        {
            Id = 1,
            Name = "Test"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        Action test = () => itemService.EditItem(null);
        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void EditItem_ReturnNullItem_ShouldThrowNullArgumentException()
    {
        var editItem = new Item
        {
            Id = 1,
            Name = "Test"
        };

        var itemRepository = new Mock<IItemRepository>();
        var itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object, itemValidator);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            return null;
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<NullReferenceException>();
    }
}