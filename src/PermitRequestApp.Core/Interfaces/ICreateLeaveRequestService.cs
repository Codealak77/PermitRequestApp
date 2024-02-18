using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Interfaces;
public interface ICreateLeaveRequestService
{
  public Task<Result<Guid>> CreateLeaveRequest(Guid userId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
}
