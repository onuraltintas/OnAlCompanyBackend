using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Abstractions;
using OnalCompany.Domain.Entities;
using OnAlCompany.Domain.Entities;

namespace OnAlCompany.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public DbSet<About> Abouts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<NewsItem> News { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SiteSettings> Settings { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Team> Teams { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);

        // Identity tablolarını yoksay
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();

        // Entity konfigürasyonları
        builder.Entity<About>(a =>
        {
            a.Property(x => x.Title).IsRequired().HasMaxLength(200);
            a.Property(x => x.Description).IsRequired();
            a.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            a.Property(x => x.SeoUrl).IsRequired().HasMaxLength(200);
        });

        builder.Entity<Category>(c =>
        {
            c.Property(x => x.Name).IsRequired().HasMaxLength(200);
            c.Property(x => x.Description).IsRequired();
            c.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            c.Property(x => x.SeoUrl).IsRequired().HasMaxLength(200);
            c.HasOne(x => x.Parent)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Product>(p =>
        {
            p.Property(x => x.Name).IsRequired().HasMaxLength(200);
            p.Property(x => x.Description).IsRequired();
            p.Property(x => x.Features).IsRequired();
            p.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            p.Property(x => x.SeoUrl).IsRequired().HasMaxLength(200);
            p.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Service>(s =>
        {
            s.Property(x => x.Title).IsRequired().HasMaxLength(200);
            s.Property(x => x.Description).IsRequired();
            s.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            s.Property(x => x.IconUrl).IsRequired().HasMaxLength(500);
            s.Property(x => x.SeoUrl).IsRequired().HasMaxLength(200);
        });

        builder.Entity<Reference>(r =>
        {
            r.Property(x => x.CompanyName).IsRequired().HasMaxLength(200);
            r.Property(x => x.Description).IsRequired();
            r.Property(x => x.LogoUrl).IsRequired().HasMaxLength(500);
            r.Property(x => x.WebsiteUrl).IsRequired().HasMaxLength(500);
        });

        builder.Entity<NewsItem>(n =>
        {
            n.Property(x => x.Title).IsRequired().HasMaxLength(200);
            n.Property(x => x.Content).IsRequired();
            n.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            n.Property(x => x.SeoUrl).IsRequired().HasMaxLength(200);
        });

        builder.Entity<Contact>(c =>
        {
            c.Property(x => x.Name).IsRequired().HasMaxLength(100);
            c.Property(x => x.Email).IsRequired().HasMaxLength(100);
            c.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            c.Property(x => x.Subject).IsRequired().HasMaxLength(200);
            c.Property(x => x.Message).IsRequired();
            c.Property(x => x.CompanyName).HasMaxLength(200);
            c.Property(x => x.Department).HasMaxLength(100);
        });

        builder.Entity<SiteSettings>(s =>
        {
            s.Property(x => x.CompanyName).IsRequired().HasMaxLength(200);
            s.Property(x => x.Address).IsRequired();
            s.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            s.Property(x => x.Email).IsRequired().HasMaxLength(100);
            s.Property(x => x.LogoUrl).IsRequired().HasMaxLength(500);
            s.Property(x => x.FooterText).IsRequired();
        });

        builder.Entity<Slider>(s =>
        {
            s.Property(x => x.Title).IsRequired().HasMaxLength(200);
            s.Property(x => x.Description).IsRequired();
            s.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            s.Property(x => x.ButtonText).IsRequired().HasMaxLength(50);
            s.Property(x => x.ButtonUrl).IsRequired().HasMaxLength(500);
        });

        builder.Entity<Team>(t =>
        {
            t.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            t.Property(x => x.Title).IsRequired().HasMaxLength(100);
            t.Property(x => x.Description).IsRequired();
            t.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
            t.Property(x => x.SeoUrl).IsRequired().HasMaxLength(200);
            t.Property(x => x.Email).IsRequired().HasMaxLength(100);
            t.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            t.Property(x => x.LinkedIn).HasMaxLength(200);
            t.Property(x => x.Twitter).HasMaxLength(200);
            t.Property(x => x.Instagram).HasMaxLength(200);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity<int>>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedDate).CurrentValue = DateTime.UtcNow;
                entry.Property(p => p.IsActive).CurrentValue = true;
            }
            
            if (entry.State == EntityState.Modified)
            {
                entry.Property(p => p.UpdatedDate).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
