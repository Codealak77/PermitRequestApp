using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace PermitRequestApp.Core.Models.Notification;
public class Notification : IEntity<Guid>
{
  public Guid Id { get; set; }
  public Guid? UserId { get; set; }
  public string? Message { get; set; }
  public DateTime CreateDate { get; set; }
  public Guid? CumulativeLeaveRequestId { get; set; }

  public ADUser.ADUser? ADUser { get; set; }
  public CumulativeLeaveRequest.CumulativeLeaveRequest? CumulativeLeaveRequest { get; set; } 
}
