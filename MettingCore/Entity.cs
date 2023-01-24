using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public class Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
