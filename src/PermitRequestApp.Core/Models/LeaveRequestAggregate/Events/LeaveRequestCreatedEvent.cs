using Ardalis.SharedKernel;

namespace PermitRequestApp.Core.Models.LeaveRequest.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class LeaveRequestCreatedEvent(Guid leaveRequestId) : DomainEventBase
{
  public Guid LeaveRequestId { get; init; } = leaveRequestId;
}
