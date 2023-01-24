using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Response_Entities
{
    public class PositionResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int? Level { get; set; }
    }
}
