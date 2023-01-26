using MediatR;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Commands.Create
{
    public class CreateSubjectCommand : IRequest<SubjectResponse>
    {
        public string RefNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Decision { get; set; }
    }
}
