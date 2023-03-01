using Application;
using Application.DTO;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;

namespace Test;

public class ItemServiceTests
{
    [Fact]
    public void ItemServiceWithNullItemRepository_ShouldThrowNullReferenceExceptionWithMessage()
    {
        Action test = () => new ItemService(null);

        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void GetAllItems_WithReturnOfNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.GetAllItems()).Returns((List<Item>)null);

        Action test = () => itemService.GetAllItems();

        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void AddItem_Empty_Name()
    {
        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.AddItem(""));

        Action test = () => itemService.AddItem(new AddItemRequest(""));
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditItem_WithUnnaturalId_ShouldReturnArgumentException()
    {
        var editItem = new EditItemRequest
        {
            Id = -1,
            Name = "Name"
        };

        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.EditItem(editItem));

        // Hvid ID er ugyldigt, retuner ArgumentException
        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditItem_WithEmptyName_ShouldReturnArgumentException()
    {
        var editItem = new EditItemRequest
        {
            Id = 1,
            Name = ""
        };

        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

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
        var editItem = new EditItemRequest
        {
            Id = 2,
            Name = "Edited"
        };

        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.EditItem(editItem)).Returns(() =>
        {
            if (item.Id != editItem.Id){
                return null;
            }
            item.Name = editItem.Name;
            return item;
        });

        Action test = () => itemService.EditItem(editItem);
        test.Should().Throw<NullReferenceException>();
    }
}