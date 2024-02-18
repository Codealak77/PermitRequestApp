using Ardalis.Result;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.UseCases.LeaveRequests.Create;

public record CreateLeaveRequestCommand(Guid UserId,string? Reason, LeaveType LeaveType, DateTime StartDate, DateTime EndDate) : Ardalis.SharedKernel.ICommand<Result<Guid>>;
