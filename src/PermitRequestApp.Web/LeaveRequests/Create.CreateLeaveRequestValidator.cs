using PermitRequestApp.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace PermitRequestApp.Web.Endpoints.LeaveRequestEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateLeaveRequestValidator : Validator<CreateLeaveRequestRequest>
{
  public CreateLeaveRequestValidator()
  {
    RuleFor(x => x.UserId)
      .NotEmpty()
      .WithMessage("User is required.");
  }
}
