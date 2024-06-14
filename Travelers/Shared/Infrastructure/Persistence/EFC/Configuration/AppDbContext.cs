using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using Travelers.Subscriptions.Domain.Model.Aggregates;
using Travelers.Subscriptions.Domain.Model.ValueObjects;

namespace Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        /*builder.Entity<SalesAgent>().ToTable("SalesAgents");
        builder.Entity<SalesAgent>().HasKey(salesAgent => salesAgent.Id);
        builder.Entity<SalesAgent>().Property(salesAgent => salesAgent.Id).ValueGeneratedOnAdd();
        builder.Entity<SalesAgent>().Property(salesAgent => salesAgent.Name).IsRequired();
        builder.Entity<SalesAgent>().Property(salesAgent => salesAgent.Commission).HasConversion(v=>v.Value, v => new Commision(v)).IsRequired();
        builder.Entity<SalesAgent>().Property(salesAgent => salesAgent.SalesCount).HasConversion(v=>v.Value,v=> new SalesCount(v)).IsRequired();
        builder.Entity<SalesAgent>().Property(salesAgent => salesAgent.LicenseId).HasConversion(v => v.Id, v=>new LicenseId(v)).IsRequired();
        */
        
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired();
        builder.Entity<Plan>().Property(p => p.MaxUsers).HasConversion(v=>v.Value, v=>new MaxUsers(v)).IsRequired();
        builder.Entity<Plan>().Property(p => p.IsDefault).HasConversion(v=>v.Value, v=>new IsDefault(v)).IsRequired();
        
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}