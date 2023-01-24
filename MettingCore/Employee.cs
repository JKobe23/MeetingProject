using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public class Employee
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public Entity Entity { get; set; }
        public Position Position { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}
