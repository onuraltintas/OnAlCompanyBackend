using OnalCompany.Domain.Abstractions;

public class NewsItem : Entity<int>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string ImageUrl { get; set; }
    public required string SeoUrl { get; set; }
    public DateTime PublishDate { get; set; }
    public int DisplayOrder { get; set; }
} 