using Application;
using Application.Interfaces;
using Application.Validators;
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

        test.Should().Throw<NullReferenceException>().WithMessage("ItemRepository is null.");
    }
    
    [Fact]
    public void GetAllItems_WithReturnOfNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.GetAllItems()).Returns((List<Item>)null);
        
        Action test = () => itemService.GetAllItems();

        test.Should().Throw<NullReferenceException>().WithMessage("Unable to fetch items from database.");
    }
  
    [Fact]
    public void AddItem_Empty_Name()
    {
        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.GetAllItems()).Returns(new List<Item>());
        
        var result = itemService.GetAllItems();

        result.Should().BeEmpty();
    }

    [Theory]
    [InlineData(1, "Item 1")]
    [InlineData(2, "Item 2")]
    [InlineData(3, "Item 3")]
    public void GetAllItems_WithInvalidProperties_ShouldThrowValidationExceptionWithMessage(int id, string name)
    {
        var itemRepository = new Mock<IItemRepository>();
        ItemValidator itemValidator = new ItemValidator();
        ItemService itemService = new ItemService(itemRepository.Object);

        itemRepository.Setup(x => x.AddItem(""));

        Action test = () => itemService.AddItem("");
        test.Should().Throw<ArgumentException>().WithMessage("Name must not be empty");

    }
    
    
    
}