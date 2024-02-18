using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;
public class LeaveRequestFactory
{
  public static LeaveRequest.LeaveRequest Create(Guid? userId, Guid? managerId, Guid? managersManagerId, string? reason, LeaveType leaveType, UserType userType, DateTime startDate, DateTime endDate)
  {
    ICreateLeaveRequest creator = Choose(userType);
    return creator.Create(userId, managerId, managersManagerId, reason, leaveType, startDate, endDate);
  }

  private static ICreateLeaveRequest Choose(UserType userType)
  {
    if (userType == UserType.Manager)
      return new CreateManagerLeaveRequest();
    else if(userType == UserType.WhiteCollarEmployee)
      return new CreateWhiteCollarEmployeeLeaveRequest();
    else
      return new CreateBlueCollarEmployeeLeaveRequest();
  }
}
