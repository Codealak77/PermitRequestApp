using FastEndpoints;
using MediatR;
using PermitRequestApp.UseCases.LeaveRequests.Create;
using PermitRequestApp.Web.Endpoints.LeaveRequestEndpoints;

namespace PermitRequestApp.Web.LeaveRequestEndpoints;

public class Create(IMediator _mediator)
  : Endpoint<CreateLeaveRequestRequest, CreateLeaveRequestResponse>
{
  public override void Configure()
  {
    Post(CreateLeaveRequestRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateLeaveRequestRequest { 
       // UserId = 
      };
    });
  }

  public override async Task HandleAsync(
    CreateLeaveRequestRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateLeaveRequestCommand(request.UserId, request.Reason, request.LeaveType, request.StartDate, request.EndDate));

    if(result.IsSuccess)
    {
      Response = new CreateLeaveRequestResponse(result.Value);
    }
    // TODO: Handle other cases as necessary
  }
}
