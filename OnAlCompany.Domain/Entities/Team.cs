using OnalCompany.Domain.Abstractions;

namespace OnalCompany.Domain.Entities;

public sealed class Team : Entity<int>
{
    public string FullName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string SeoUrl { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? LinkedIn { get; set; }
    public string? Twitter { get; set; }
    public string? Instagram { get; set; }
    public int DisplayOrder { get; set; }
}