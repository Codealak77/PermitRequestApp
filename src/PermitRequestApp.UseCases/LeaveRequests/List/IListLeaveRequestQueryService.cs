using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.UseCases.ADUsers;

namespace PermitRequestApp.UseCases.LeaveRequests.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListLeaveRequestQueryService
{
  Task<IEnumerable<LeaveRequestDTO>> ListAsync();
}
