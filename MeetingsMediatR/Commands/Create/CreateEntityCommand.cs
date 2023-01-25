using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreateEntityCommand : IRequest<EntityResponse>
    {
        public string name { get; set; }
        public string location { get; set; }
    }
    
}
