using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Update
{
    public class UpdatePositionCommand : IRequest<PositionResponse>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Level { get; set; } 
    }
}
