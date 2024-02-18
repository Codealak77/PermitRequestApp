namespace PermitRequestApp.Web.Endpoints.LeaveRequestEndpoints;

public class CreateLeaveRequestResponse
{
  public CreateLeaveRequestResponse(Guid id)
  {
    Id = id;
  }
  public Guid Id { get; set; }
}
