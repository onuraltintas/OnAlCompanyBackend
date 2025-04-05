using OnalCompany.Domain.Abstractions;

namespace OnalCompany.Domain.Entities
{
    public class Product : Entity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Features { get; set; } // Teknik özellikler
        public required string ImageUrl { get; set; }
        public required string SeoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int DisplayOrder { get; set; }
    }
} 