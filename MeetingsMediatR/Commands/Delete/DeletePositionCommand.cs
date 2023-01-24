using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Delete
{
    public record DeletePositionCommand(int id) : IRequest<PositionResponse>;

}
