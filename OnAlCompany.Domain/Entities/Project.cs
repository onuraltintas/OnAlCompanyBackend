using OnalCompany.Domain.Abstractions;
using OnalCompany.Domain.Entities;

public class Project : Entity<int>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string SeoUrl { get; set; }
    public required string Client { get; set; }
    public required string Location { get; set; }
    public DateTime ProjectDate { get; set; }
    public int DisplayOrder { get; set; }    
    
} 