using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ubiquitous.Data.Models.Entity;

/// <summary>
/// Application database context configured for ASP.NET Core Identity.
/// </summary>
public class UbiquitousDbContext : IdentityDbContext<Users, IdentityRole<int>, int>
{
    public UbiquitousDbContext(DbContextOptions<UbiquitousDbContext> options) : base(options) { }

    public DbSet<Url> Urls { get; set; }
    public DbSet<ClickLog> ClickLogs { get; set; }
}