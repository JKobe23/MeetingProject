using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Response_Entities
{
    public class EntityResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
    }
}
