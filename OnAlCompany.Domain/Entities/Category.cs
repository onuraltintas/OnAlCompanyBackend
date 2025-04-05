using OnalCompany.Domain.Abstractions;

namespace OnalCompany.Domain.Entities
{
    public class Category : Entity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required string SeoUrl { get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public int DisplayOrder { get; set; }
    }
} 