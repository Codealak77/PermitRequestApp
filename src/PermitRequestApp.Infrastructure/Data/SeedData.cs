using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PermitRequestApp.Core.Enum;
using PermitRequestApp.Core.Models.ADUser;
using PermitRequestApp.Core.Models.CumulativeLeaveRequest;
using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;
using PermitRequestApp.Core.Models.Notification;
using PermitRequestApp.Core.Utility;

namespace PermitRequestApp.Infrastructure.Data;

public static class SeedData
{
  public static readonly List<ADUser> Adusers = new List<ADUser>
  {
    new ADUser
    {
      Id = new Guid("def8a165-289e-467c-8c4a-0e960976907e"),
      FirstName = "Kemal",
      LastName = "Sunal",
      Email = "test1@test.com",
      UserType = UserType.BlueCollarEmployee,
      ManagerId = new Guid("aaf8a165-289e-467c-8c4a-0e960976907e")
    },
    new ADUser
    {
      Id = new Guid("bbf8a165-289e-467c-8c4a-0e960976907e"),
      FirstName = "Munir",
      LastName = "Özkul",
      Email = "deneme@test.com",
      UserType = UserType.Manager,
      ManagerId = null,
    },
    new ADUser
    {
      Id = new Guid("aaf8a165-289e-467c-8c4a-0e960976907e"),
      FirstName = "Şener",
      LastName = "Şen",
      Email = "uyart@test.com",
      UserType = UserType.WhiteCollarEmployee,
      ManagerId = new Guid("bbf8a165-289e-467c-8c4a-0e960976907e"),
    }
  };

  public static readonly List<CumulativeLeaveRequest> _cumulativeLeaveRequests = new List<CumulativeLeaveRequest>
  {
    new CumulativeLeaveRequest
    {
      Id = new Guid("def8a165-111e-467c-8c4a-0e960976907e"),
      LeaveType = LeaveType.AnnualLeave,
      UserId = new Guid("def8a165-289e-467c-8c4a-0e960976907e"),
      TotalHours = 50,
      Year = 2024
    },
    new CumulativeLeaveRequest
    {
      Id = Generator.IdGenerator(),
      LeaveType = LeaveType.ExcusedAbsence,
      UserId = new Guid("aaf8a165-289e-467c-8c4a-0e960976907e"),
      TotalHours = 16,
      Year = 2024
    }
  };

  public static readonly List<LeaveRequest> _leaveRequests = new List<LeaveRequest>
  {
    LeaveRequestFactory.Create(
        new Guid("aaf8a165-289e-467c-8c4a-0e960976907e"),
        new Guid("bbf8a165-289e-467c-8c4a-0e960976907e"),
        null,
        "İhtiyaç",
        LeaveType.ExcusedAbsence,
        UserType.WhiteCollarEmployee,
        new DateTime(2024,3,5),
        new DateTime(2024,3,7)
      )
  };


  public static readonly List<Notification> _notification = new List<Notification>
  {
    new Notification
    {
      Id = Generator.IdGenerator(),
      CreateDate = new DateTime(),
      CumulativeLeaveRequestId = new Guid("def8a165-111e-467c-8c4a-0e960976907e"),
      Message = "Deneme",
      UserId = new Guid("def8a165-289e-467c-8c4a-0e960976907e"),
    }
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.ADUsers.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    dbContext.ADUsers.AddRange(Adusers);
    dbContext.CumulativeLeaveRequests.AddRange(_cumulativeLeaveRequests);
    dbContext.LeaveRequests.AddRange(_leaveRequests);
    dbContext.Notifications.AddRange(_notification);

    dbContext.SaveChanges();
  }
}
