using MeetingCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class MeetingsContext: DbContext
    {
        private static string connectionString = "Server = INTALIO-JKO\\SQL19; Database = MeetingsDB; Integrated Security = True; Encrypt=False";
        public MeetingsContext(DbContextOptions<MeetingsContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opbuilder)
        {
            opbuilder.UseSqlServer(connectionString);
        }
    }
}
