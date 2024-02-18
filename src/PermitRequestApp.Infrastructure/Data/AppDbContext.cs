using System.Reflection;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using PermitRequestApp.Core.Models.ADUser;
using PermitRequestApp.Core.Models.CumulativeLeaveRequest;
using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.Core.Models.Notification;

namespace PermitRequestApp.Infrastructure.Data;
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<ADUser> ADUsers => Set<ADUser>();
  public DbSet<CumulativeLeaveRequest> CumulativeLeaveRequests => Set<CumulativeLeaveRequest>();
  public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
  public DbSet<Notification> Notifications => Set<Notification>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ADUser>().HasKey(x => x.Id);
    modelBuilder.Entity<CumulativeLeaveRequest>().HasKey(x => x.Id);
    modelBuilder.Entity<LeaveRequest>().HasKey(x => x.Id);
    modelBuilder.Entity<Notification>().HasKey(x => x.Id);

    modelBuilder.Entity<ADUser>()
      .HasMany(x => x.AssignedToMeList)
      .WithOne(x => x.AssignedUser)
      .HasForeignKey(x => x.AssignedUserId)
      .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<ADUser>()
     .HasMany(x => x.ModifiedByMeList)
     .WithOne(x => x.LastModifiedBy)
     .HasForeignKey(x => x.LastModifiedById)
     .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<ADUser>()
     .HasMany(x => x.CreatedByMeList)
     .WithOne(x => x.CreatedBy)
     .HasForeignKey(x => x.CreatedById)
     .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<ADUser>()
     .HasOne(x => x.Manager)
     .WithMany()
     .HasForeignKey(x => x.ManagerId);

    modelBuilder.Entity<ADUser>()
     .HasMany(x => x.NotificationList)
     .WithOne(x => x.ADUser)
     .HasForeignKey(x => x.UserId)
     .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<ADUser>()
     .HasMany(x => x.CumulativeLeaveRequestList)
     .WithOne(x => x.ADUser)
     .HasForeignKey(x => x.UserId);

    modelBuilder.Entity<CumulativeLeaveRequest>()
     .HasMany(x => x.NotificationList)
     .WithOne(x => x.CumulativeLeaveRequest)
     .HasForeignKey(x => x.CumulativeLeaveRequestId)
     .OnDelete(DeleteBehavior.NoAction);

    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    ChangeTracker.Entries().ToList().ForEach(e =>
    {
      if (e.Entity is LeaveRequest p)
      {
        if (e.State == EntityState.Modified)
        {
          p.setLastModifiedAt();
        }
        else if (e.State == EntityState.Added)
        {
          p.setCreatedAt();
        }
      }
    });

    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    ChangeTracker.Entries().ToList().ForEach(e =>
    {
      if (e.Entity is LeaveRequest p)
      {
        if (e.State == EntityState.Modified)
        {
          p.setLastModifiedAt();
        }
        else if (e.State == EntityState.Added)
        {
          p.setCreatedAt();
        }
      }
    });
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
