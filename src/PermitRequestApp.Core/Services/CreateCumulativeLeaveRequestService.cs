using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using PermitRequestApp.Core.Enum;
using PermitRequestApp.Core.Interfaces;
using PermitRequestApp.Core.Models.CumulativeLeaveRequest;
using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.Core.Models.LeaveRequest.Events;
using PermitRequestApp.Core.Models.LeaveRequestAggregate.BuilderFactory;

namespace PermitRequestApp.Core.Services;
public class CreateCumulativeLeaveRequestService(IRepository<LeaveRequest> _repository 
  //IRepository<CumulativeLeaveRequest> _repositoryClr,
  //IMediator _mediator
  ) : ICreateCumulativeLeaveRequestService
{
  public async Task<Result<Guid>> CreateCumulativeLeaveRequest(Guid leaveRequestId, CancellationToken cancellationToken)
  {
    var createUser = await _repository.GetByIdAsync(leaveRequestId); // 

    //var newRequest = LeaveRequestFactory.Create(userId, createUser!.ManagerId, createUser!.Manager?.ManagerId, reason, leaveType, createUser!.UserType, startDate, endDate);
    //var createdItem = await _repository.AddAsync(newRequest, cancellationToken);

    //var domainEvent = new LeaveRequestCreatedEvent(createdItem.Id);
    //await _mediator.Publish(domainEvent);
    //return createdItem.Id;
    throw new NotImplementedException();
  }


  /// LeaveRequest > Id si ile detayını bulup, CreatedById den bağlı olduğu User Bulunmalı.
  ///  CLR tablosunda bu tipte user varmı diye aranacak eğer bulunmuyoırsa yeni oluşturulacak, varsa update edilecek.
  /// Update Edilirken 
  /*
   *
• AnnualLeave bir sene içerisinde 14 gün olabilir. %10 fazla olduğu durumda exception
fırlatılacak ve kullanıcı bilgilendirilecektir. Bu durumda izin talebi Workflow bilgisi her
durumda Exception olacak ve kullanıcı ile varsa Manager’a bildirim yapılacaktır.
• ExcusedAbsence bir sene içerisinde 5 gün olabilir. %20 fazla olduğu durumda exception
fırlatılacak ve kullanıcı bilgilendirilecektir. Bu durumda izin talebi Workflow bilgisi her
durumda Exception olacak ve kullanıcı ile varsa Manager’a bildirim yapılacaktır.
• Her izin tipi için müsade edilen gün sayısının %80 i kullanıldığında da kullanıcıya notification
yaratılacaktır. 
   * 
   */

}
