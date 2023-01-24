using MeetingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Response_Entities
{
    public class MeetingResponse
    {
        public int Id { get; set; }
        public string RefNumber { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string? Notes { get; set; }
        public IEnumerable<EmployeeResponse> Employees { get; set; }
        public IEnumerable<SubjectResponse> Subjects { get; set; }
    }
}
