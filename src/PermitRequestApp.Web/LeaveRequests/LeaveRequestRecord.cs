using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Web.LeaveRequests;

public record LeaveRequestRecord(string? RequestFormNumber, string? Name, string? LeaveType, string? CreatedDate, string? StartDate, string? EndDate, string? TotalHour, string? Workflow);
