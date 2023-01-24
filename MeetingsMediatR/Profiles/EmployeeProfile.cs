using AutoMapper;
using MeetingCore;
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
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeResponse, Employee>().ForMember(x => x.Meetings, y => y.Ignore());
        }
    }
}
