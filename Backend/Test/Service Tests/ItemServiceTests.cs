using Application;
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

        test.Should().Throw<NullReferenceException>().WithMessage("ItemRepository is null.");
    }
    
    [Fact]
    public void GetAllItems_WithReturnOfNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        var itemRepository = new Mock<IItemRepository>();
        ItemService itemService = new ItemService();

        itemRepository.Setup(x => x.GetAllItems()).Returns((List<Item>)null);
        
        Action test = () => itemService.GetAllItems();

        test.Should().Throw<NullReferenceException>().WithMessage("Unable to fetch items from database.");
    }
}