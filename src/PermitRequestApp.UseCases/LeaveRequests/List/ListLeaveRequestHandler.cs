using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;

namespace PermitRequestApp.UseCases.LeaveRequests.List;

public class ListLeaveRequestsHandler(IListLeaveRequestQueryService _query, IMapper _mapper)
  : IQueryHandler<ListLeaveRequestsQuery, Result<IEnumerable<LeaveRequestDTO>>>
{
  public async Task<Result<IEnumerable<LeaveRequestDTO>>> Handle(ListLeaveRequestsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();
    var dtoItems = result.Select(x => _mapper.Map<LeaveRequestDTO>(x));
    return Result.Success(dtoItems);
  }
}
