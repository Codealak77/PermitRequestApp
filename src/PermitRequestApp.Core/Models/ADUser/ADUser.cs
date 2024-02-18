using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using PermitRequestApp.Core.Models.LeaveRequest;

namespace PermitRequestApp.Core.Models.ADUser;
public class ADUser : EntityBase<Guid>, IAggregateRoot
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public Enum.UserType UserType { get; set; }
  public Guid? ManagerId { get; set; }

  public List<Notification.Notification> NotificationList { get; set;} = new ();
  public List<CumulativeLeaveRequest.CumulativeLeaveRequest> CumulativeLeaveRequestList { get; set; } = new();
  public virtual List<LeaveRequest.LeaveRequest> AssignedToMeList { get; set; } = new();
  public virtual List<LeaveRequest.LeaveRequest> CreatedByMeList { get; set; } = new();
  public virtual List<LeaveRequest.LeaveRequest> ModifiedByMeList { get; set; } = new();
  public ADUser? Manager { get; set; }
}
