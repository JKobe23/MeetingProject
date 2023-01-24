using MediatR;
using MeetingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public record CreateEntityCommand(string name, string location) : IRequest<Entity>;
    
}
