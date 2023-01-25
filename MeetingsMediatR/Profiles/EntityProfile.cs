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
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, EntityResponse>().ReverseMap().ForMember(x => x.Employees, y => y.Ignore());
            CreateMap<Entity, CreateEntityCommand>().ReverseMap().ForMember(x => x.Employees, y => y.Ignore());
            CreateMap<Entity, UpdateEntityCommand>().ReverseMap().ForMember(x => x.Employees, y => y.Ignore());
        }
    }
}
