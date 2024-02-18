using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PermitRequestApp.UseCases.LeaveRequests.List;

public record ListLeaveRequestsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<LeaveRequestDTO>>>;
