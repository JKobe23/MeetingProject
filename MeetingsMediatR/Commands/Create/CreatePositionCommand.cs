using MediatR;
using MeetingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public record CreatePositionCommand(string title, int level) : IRequest<Position>;    
}
