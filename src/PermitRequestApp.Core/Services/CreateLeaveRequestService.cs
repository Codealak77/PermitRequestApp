using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using PermitRequestApp.Core.Enum;
using PermitRequestApp.Core.Interfaces;
using PermitRequestApp.Core.Models.ADUser;
using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.Core.Models.LeaveRequest.Events;
using PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;

namespace PermitRequestApp.Core.Services;
public class CreateLeaveRequestService(IRepository<LeaveRequest> _repository, IRepository<ADUser> _repositoryAduser,
  IMediator _mediator) : ICreateLeaveRequestService
{
  public async Task<Result<Guid>> CreateLeaveRequest(Guid userId, string? reason, LeaveType leaveType, DateTime startDate, DateTime endDate,CancellationToken cancellationToken)
  {
    var createUser = await _repositoryAduser.GetByIdAsync(userId);

    var newRequest = LeaveRequestFactory.Create(userId, createUser!.ManagerId, createUser!.Manager?.ManagerId, reason, leaveType, createUser!.UserType, startDate, endDate);
    var createdItem = await _repository.AddAsync(newRequest, cancellationToken);

    var domainEvent = new LeaveRequestCreatedEvent(createdItem.Id);
    await _mediator.Publish(domainEvent);
    return createdItem.Id;
  }

}
