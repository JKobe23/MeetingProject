using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreateMeetingCommand : IRequest<MeetingResponse>
    {
        public string RefNumber { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string? Notes { get; set; }
        public List<int> EmployeeIDs { get; set; }
        public List<int> SubjectIDs { get; set; }
    }
}
