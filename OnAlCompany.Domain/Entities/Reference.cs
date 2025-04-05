using OnalCompany.Domain.Abstractions;

namespace OnalCompany.Domain.Entities
{
    public class Reference : Entity<int>
    {
        public required string CompanyName { get; set; }
        public required string Description { get; set; }
        public required string LogoUrl { get; set; }
        public required string WebsiteUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
} 