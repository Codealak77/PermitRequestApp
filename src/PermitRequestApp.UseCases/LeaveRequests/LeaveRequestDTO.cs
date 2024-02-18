namespace PermitRequestApp.UseCases.LeaveRequests;
public record LeaveRequestDTO(string? RequestFormNumber, string? Name, string? LeaveType, string? CreatedDate, string? StartDate, string? EndDate, string? TotalHour, string? Workflow);

