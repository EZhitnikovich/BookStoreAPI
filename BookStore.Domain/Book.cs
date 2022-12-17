﻿namespace BookStore.Domain;

public class Book : Entity
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
