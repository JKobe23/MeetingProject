using MeetingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Response_Entities
{
    public class EmployeeResponse
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public EntityResponse Entity { get; set; }
        public PositionResponse Position { get; set; }
    }
}
