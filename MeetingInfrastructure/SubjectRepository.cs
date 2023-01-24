using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingCore;

namespace MeetingInfrastructure
{
    public class SubjectRepository : GenericRepository<Subject>, IRepoSubject
    {
        public SubjectRepository(MeetingsContext context) : base(context)
        {

        }

        public Subject getByRefNumber(string refId)
        {
            Subject subject = Context.Subjects.FirstOrDefault(s => s.RefNumber.ToLower() == refId.ToLower());
            return subject;
        }
    }
}
