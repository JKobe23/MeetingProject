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
        public int ID { get; set; }
        public string RefNumber { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string? Notes { get; set; }
        public List<EmployeeResponse> Employees { get; set; }
        public List<SubjectResponse> Subjects { get; set; }
    }
}
