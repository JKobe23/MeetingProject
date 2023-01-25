using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public int PositionID { get; set; }
        public int EntityID { get; set; }
    }
}
