using OnalCompany.Domain.Abstractions;

public class SiteSettings : Entity<int>
{
    public required string CompanyName { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required string FacebookUrl { get; set; }
    public required string TwitterUrl { get; set; }
    public required string LinkedInUrl { get; set; }
    public required string InstagramUrl { get; set; }
    public required string LogoUrl { get; set; }
    public required string FooterText { get; set; }
} 