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
    public class SubjectProfile: Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectResponse>();
        }
    }
}
