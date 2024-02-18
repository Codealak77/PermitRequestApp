using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Core.Interfaces;
public interface ICreateCumulativeLeaveRequestService
{
  public Task<Result<Guid>> CreateCumulativeLeaveRequest(Guid leaveRequestId, CancellationToken cancellationToken);
}
