using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Queries
{
    public record GetPositionByIdQuery(int id) : IRequest<PositionResponse>;   
}
