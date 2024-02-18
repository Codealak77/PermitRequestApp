using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;
public class CreateBlueCollarEmployeeLeaveRequest : ICreateLeaveRequest
{
  public LeaveRequest.LeaveRequest Create(Guid? userId, Guid? managerId, Guid? managersManagerId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate)
  {
    if (leaveType == LeaveType.AnnualLeave) 
      return LeaveRequest.LeaveRequest.createLeaveRequest(userId,managersManagerId, reason, leaveType, startDate, endDate, Workflow.Pending);
    else
      return LeaveRequest.LeaveRequest.createLeaveRequest(userId,managerId, reason, leaveType, startDate, endDate, Workflow.Pending);

  }
}
