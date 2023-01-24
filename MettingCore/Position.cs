using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public class Position
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
