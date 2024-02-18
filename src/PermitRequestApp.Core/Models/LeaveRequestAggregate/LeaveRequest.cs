using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using System.Xml.Linq;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Models.LeaveRequest;
public class LeaveRequest : EntityBase<Guid>, IAggregateRoot
//public class LeaveRequest(Guid assignedUserId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate) : EntityBase<Guid>, IAggregateRoot
{
  public string? FormNumber { get; private set; }
  public int RequestNumber { get; private set; }
  public Enum.LeaveType LeaveType { get; private set; }
  public string? Reason { get; private set; }
  public DateTime StartDate { get; private set; }
  public DateTime EndDate { get; private set; }
  public Enum.Workflow WorkflowStatus { get; private set; }
  public Guid? AssignedUserId { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public Guid? CreatedById { get; private set; }
  public DateTime? LastModifiedAt { get; private set; }
  public Guid? LastModifiedById { get; private set; }

  public virtual ADUser.ADUser? AssignedUser { get; private set; }
  public virtual ADUser.ADUser? CreatedBy { get; private set; }
  public virtual ADUser.ADUser? LastModifiedBy { get; private set; }

  public static LeaveRequest createLeaveRequest(Guid? userId, Guid? assignedUserId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate, Enum.Workflow workflow)
  {
    return new LeaveRequest { CreatedById = userId, AssignedUserId = assignedUserId, Reason = reason, LeaveType = leaveType, StartDate = startDate, EndDate = endDate, WorkflowStatus = workflow };
  }
  public void setCreatedAt()
  {
    this.CreatedAt = DateTime.Now;
  }
  public void setLastModifiedAt()
  {
    this.LastModifiedAt = DateTime.Now;
  }
}
