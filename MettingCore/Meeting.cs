using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public class Meeting
    {
        public int Id { get; set; }
        public string RefNumber { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public List<Employee> Employees { get; set; }

        public List<Subject> Subjects { get; set; }

    }
}
