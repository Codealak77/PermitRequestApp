using MediatR;
using Microsoft.Extensions.Logging;
using PermitRequestApp.Core.Models.LeaveRequest.Events;

namespace PermitRequestApp.Core.Models.LeaveRequestAggregate.Handlers;
internal class LeaveRequestCreatedHandler() : INotificationHandler<LeaveRequestCreatedEvent>
{
  public async Task Handle(LeaveRequestCreatedEvent domainEvent, CancellationToken cancellationToken)
  {



    // TODO: do meaningful work here
    await Task.Delay(1);
  }
}
