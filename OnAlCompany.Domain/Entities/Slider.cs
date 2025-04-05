using OnalCompany.Domain.Abstractions;

public class Slider : Entity<int>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string ButtonText { get; set; }
    public required string ButtonUrl { get; set; }
    public int DisplayOrder { get; set; }
} 