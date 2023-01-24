using MeetingCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class PositionRepository : GenericRepository<Position>, IRepoPosition
    {
        public PositionRepository(MeetingsContext context) : base(context)
        {
        }
    }
}
