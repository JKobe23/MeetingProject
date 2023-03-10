using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreatePositionCommand : IRequest<PositionResponse>
    {
        public string title { get; set; }
        public int level { get; set; }
    }
}
