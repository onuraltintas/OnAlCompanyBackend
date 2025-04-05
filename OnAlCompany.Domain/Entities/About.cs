using OnalCompany.Domain.Abstractions;


public class About : Entity<int>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string SeoUrl { get; set; }
    public required string Vision { get; set; }
    public required string Mission { get; set; }
    public int DisplayOrder { get; set; }
} 