using Ardalis.Result;
using Ardalis.SharedKernel;
using PermitRequestApp.Core.Interfaces;

namespace PermitRequestApp.UseCases.LeaveRequests.Create;
public class CreateLeaveRequestsHandler(ICreateLeaveRequestService _service)
  : ICommandHandler<CreateLeaveRequestCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(CreateLeaveRequestCommand request,
    CancellationToken cancellationToken)
  {
    return await _service.CreateLeaveRequest(request.UserId, request.Reason, request.LeaveType, request.StartDate, request.EndDate, cancellationToken);
  }
}
