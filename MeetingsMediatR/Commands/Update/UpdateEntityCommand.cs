using MediatR;
using MeetingCore;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Update
{
    public class UpdateEntityCommand : IRequest<EntityResponse>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
