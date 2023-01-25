using AutoMapper;
using MeetingCore;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Commands.Update;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponse>().ReverseMap().ForMember(x => x.Meetings, y => y.Ignore());
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap().ForMember(x => x.Meetings, y => y.Ignore());
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap().ForMember(x => x.Meetings, y => y.Ignore())
                                                                     .ForMember(x => x.SSN, y => y.Ignore());
        }
    }
}
