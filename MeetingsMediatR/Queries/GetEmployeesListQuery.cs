using MediatR;
using MeetingCore;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Queries
{
    public record GetEmployeesListQuery : IRequest<IEnumerable<EmployeeResponse>>;
     
}
