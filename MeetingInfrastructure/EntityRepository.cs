using MeetingCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class EntityRepository : GenericRepository<Entity>, IRepoEntity
    {
        public EntityRepository(MeetingsContext context) : base(context)
        {
        }
    }
}
