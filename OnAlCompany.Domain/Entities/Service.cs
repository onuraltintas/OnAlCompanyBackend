using OnalCompany.Domain.Abstractions;
using System;

public class Service : Entity<int>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string IconUrl { get; set; }
    public required string SeoUrl { get; set; }
    public int DisplayOrder { get; set; }
} 