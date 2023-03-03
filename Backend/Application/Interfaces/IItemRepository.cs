﻿using Application.DTO;
using Domain;

namespace Infrastructure.Interfaces;

public interface IItemRepository
{
    public List<Item> GetAllItems();
    public void AddItem(string name);
    public Item? EditItem(Item item);
}