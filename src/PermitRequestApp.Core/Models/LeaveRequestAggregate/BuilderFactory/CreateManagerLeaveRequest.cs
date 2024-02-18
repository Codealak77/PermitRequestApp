using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;
public class CreateManagerLeaveRequest : ICreateLeaveRequest
{
  public LeaveRequest.LeaveRequest Create(Guid? userId, Guid? managerId, Guid? managersManagerId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate)
  {
    return LeaveRequest.LeaveRequest.createLeaveRequest(userId,null,reason,leaveType,startDate,endDate,Workflow.None);
  }
}
