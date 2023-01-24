using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class MeetingsContextFactory : IDesignTimeDbContextFactory<MeetingsContext>
    {
        public MeetingsContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<MeetingsContext>();
            optionsBuilder.UseSqlServer("Server = INTALIO-JKO\\SQL19;Database=MeetingsDB; Integrated Security=True; Encrypt=False");

            return new MeetingsContext(optionsBuilder.Options);
        }
    }
}
