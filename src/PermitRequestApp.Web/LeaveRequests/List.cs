using FastEndpoints;
using MediatR;
using PermitRequestApp.UseCases.LeaveRequests.List;
using PermitRequestApp.Web.Endpoints.LeaveRequestEndpoints;
using PermitRequestApp.Web.LeaveRequests;

namespace PermitRequestApp.Web.LeaveRequestEndpoints;

public class List(IMediator _mediator) : EndpointWithoutRequest<LeaveRequestListResponse>
{
  public override void Configure()
  {
    Get("/LeaveRequests");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListLeaveRequestsQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new LeaveRequestListResponse
      {
         LeaveRequests = result.Value.Select(c => new LeaveRequestRecord(c.RequestFormNumber, c.Name, c.LeaveType, c.CreatedDate, c.StartDate, c.EndDate, c.TotalHour, c.Workflow)).ToList()
      };
    }
  }
}
