using MediatR;
using MeetingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreatePositionCommand : IRequest<Position>
    {
        public string title { get; set; }
        public int level { get; set; }
    }
}
