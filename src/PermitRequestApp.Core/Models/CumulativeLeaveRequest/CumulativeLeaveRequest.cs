using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace PermitRequestApp.Core.Models.CumulativeLeaveRequest;
public class CumulativeLeaveRequest : IEntity<Guid>
{
  public Guid Id { get; set; }
  public Enum.LeaveType LeaveType { get; set; }
  public Guid UserId { get; set; }
  public int? TotalHours { get; set; }
  public int Year { get; set; }

  public ADUser.ADUser? ADUser { get; set; }
  public List<Notification.Notification> NotificationList { get; set; } = new();
}
