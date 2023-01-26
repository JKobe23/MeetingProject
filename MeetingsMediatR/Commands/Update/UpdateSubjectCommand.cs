using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Update
{
    public class UpdateSubjectCommand : IRequest<SubjectResponse>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Decision { get; set; }
    }
}
