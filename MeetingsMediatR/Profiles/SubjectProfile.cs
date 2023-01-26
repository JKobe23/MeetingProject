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
    public class SubjectProfile: Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectResponse>().ReverseMap().ForMember(x => x.Meetings, y => y.Ignore());
            CreateMap<Subject, CreateSubjectCommand>().ReverseMap().ForMember(x => x.Meetings, y => y.Ignore());
            CreateMap<Subject, UpdateSubjectCommand>().ReverseMap().ForMember(x => x.Meetings, y => y.Ignore())
                                                                    .ForMember(x => x.RefNumber, y => y.Ignore());
        }
    }
}
