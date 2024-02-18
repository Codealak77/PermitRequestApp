using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;
public interface ICreateLeaveRequest
{
  public LeaveRequest.LeaveRequest Create(Guid? userId, Guid? managerId,Guid? managersManagerId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate);
}
