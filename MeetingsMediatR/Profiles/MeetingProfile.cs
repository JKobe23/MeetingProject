using AutoMapper;
using MeetingCore;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Profiles
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<Meeting, MeetingResponse>().ReverseMap();
            CreateMap<Meeting, CreateMeetingCommand>()
                     .ForMember(x=> x.EmployeeIDs, y=> y.Ignore()).ForMember(x => x.SubjectIDs, y => y.Ignore())
                     .ReverseMap().ForMember(x => x.Employees, y => y.Ignore())
                     .ForMember(x => x.Subjects, y => y.Ignore());
        }               
    }
}
