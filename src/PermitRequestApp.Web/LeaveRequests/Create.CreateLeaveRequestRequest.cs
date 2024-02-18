﻿using System.ComponentModel.DataAnnotations;
using PermitRequestApp.Core.Enum;

namespace PermitRequestApp.Web.Endpoints.LeaveRequestEndpoints;

public class CreateLeaveRequestRequest
{
  public const string Route = "/LeaveRequests";

  public Guid UserId { get; set; }
  public string? Reason { get; set; }
  public LeaveType LeaveType { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
}
