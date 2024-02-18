using AutoMapper;
using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.UseCases.LeaveRequests.Create;

namespace PermitRequestApp.UseCases.LeaveRequests.Mappings;

public class LeaveRequestMappingProfiles : Profile
  {
    public LeaveRequestMappingProfiles()
    {
      CreateMap<LeaveRequest, CreateLeaveRequestCommand>().ReverseMap();
      CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
    }
  }
