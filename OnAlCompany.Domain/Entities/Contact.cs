using System;
using OnalCompany.Domain.Abstractions;

public class Contact : Entity<int>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Subject { get; set; }
    public required string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadDate { get; set; }
    public required string CompanyName { get; set; }
    public required string Department { get; set; }
} 