using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PositionID { get; set; }
        public int EntityID { get; set; }
        
    }
}
