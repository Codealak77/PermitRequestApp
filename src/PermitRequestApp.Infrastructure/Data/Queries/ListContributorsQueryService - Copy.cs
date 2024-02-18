using Ardalis.Specification.EntityFrameworkCore;
using PermitRequestApp.Core.Enum;
using PermitRequestApp.UseCases.ADUsers;
using PermitRequestApp.UseCases.LeaveRequests;
using PermitRequestApp.UseCases.LeaveRequests.List;

namespace PermitRequestApp.Infrastructure.Data.Queries;

public class ListLeaveRequestQueryService(AppDbContext _db) : IListLeaveRequestQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries - this is just an example

  public  Task<IEnumerable<LeaveRequestDTO>> ListAsync()
  {
    _db = _db ?? throw new ArgumentNullException(nameof(WaitHandleExtensions));
    //var result = await _db.LeaveRequests
      //.Select(c => new LeaveRequestDTO(c.FormNumber, c.AssignedUser!.FirstName, c.LeaveType.ToString(), c.CreatedAt.ToString(), c.StartDate.ToString(), c.EndDate.ToString(), c.CreatedBy!.CumulativeLeaveRequestList.FirstOrDefault(x => x.Year == DateTime.Now.Year && x.LeaveType == c.LeaveType).TotalHours.ToString(), c.WorkflowStatus.ToString()))
      //.ToListAsync();

    throw new NotImplementedException();
    //return object;
  }
}
