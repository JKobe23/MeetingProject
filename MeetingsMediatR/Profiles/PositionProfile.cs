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
    public class PositionProfile: Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionResponse>().ReverseMap().ForMember(x => x.Employees, y => y.Ignore());
            CreateMap<Position, CreatePositionCommand>().ReverseMap().ForMember(x => x.Employees, y => y.Ignore());
            CreateMap<Position, UpdatePositionCommand>().ReverseMap().ForMember(x => x.Employees, y => y.Ignore());
        }
    }
}
