﻿namespace BookStore.Domain;

internal class Entity
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
}
