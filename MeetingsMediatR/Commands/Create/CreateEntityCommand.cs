using MediatR;
using MeetingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreateEntityCommand : IRequest<Entity>
    {
        public string name { get; set; }
        public string location { get; set; }
    }
    
}
