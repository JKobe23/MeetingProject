using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Position")]
        public int PositionID { get; set; }
        public Entity Entity { get; set; }
        [ForeignKey("Entity")]
        public int EntityID { get; set; }
        public Position Position { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}
