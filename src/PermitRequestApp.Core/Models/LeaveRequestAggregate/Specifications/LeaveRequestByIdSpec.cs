using Ardalis.Specification;

namespace PermitRequestApp.Core.Models.LeaveRequestAggregate.Specifications;
public class LeaveRequestByIdSpec : Specification<LeaveRequest.LeaveRequest>
{
  public LeaveRequestByIdSpec(Guid leaveRequestId)
  {
    Query
        .Where(lr => lr.Id == leaveRequestId);
  }
}
