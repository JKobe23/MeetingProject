using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Response_Entities
{
    public class SubjectResponse
    {
        public int ID { get; set; }
        public string RefNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Decision { get; set; }
    }
}
