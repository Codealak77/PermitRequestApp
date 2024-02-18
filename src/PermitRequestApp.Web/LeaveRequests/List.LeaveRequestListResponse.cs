using PermitRequestApp.Web.LeaveRequests;

namespace PermitRequestApp.Web.Endpoints.LeaveRequestEndpoints;

public class LeaveRequestListResponse
{
  public List<LeaveRequestRecord> LeaveRequests { get; set; } = new();
}
