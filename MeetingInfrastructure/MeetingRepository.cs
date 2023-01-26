using Azure.Core;
using MeetingCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class MeetingRepository : GenericRepository<Meeting>, IRepoMeeting
    {
        public MeetingRepository(MeetingsContext context) : base(context)
        {
        }

        public Meeting getByRefNumber(string refId)
        {
            Meeting meeting = Context.Meetings.FirstOrDefault(m => m.RefNumber.ToLower() == refId.ToLower());

            return meeting;
        }
        public string listDetails(string refId)
        {
            Meeting? meeting = Context.Meetings
                               .Include(m => m.Employees)
                               .Include(m => m.Subjects)
                               .FirstOrDefault(m => m.RefNumber.ToLower() == refId.ToLower());

            if (meeting == null)
            {
                return "Meeting not found.";
            }

            int employeesCount = meeting.Employees.Count();
            int subjectsCount = meeting.Subjects.Count();

            StringBuilder builder = new StringBuilder();
            builder.Append($"Meeting title: {meeting.Name} \n");
            builder.Append($"Reference number: {meeting.RefNumber} \n");
            builder.Append($"Date and location: {meeting.Location} on {meeting.Date:dd/MM/yyyy} \n");
            builder.Append($"Number of Employees attending: {employeesCount} \n");
            builder.Append($"Number of subjects of discussion: {subjectsCount} \n");
            builder.Append($"Meeting notes: {meeting.Notes} \n");

            return builder.ToString();
        }

        public List<Meeting> listAllMeetings()
        {
            List<Meeting> meetings = Context.Meetings.Include(m => m.Employees).Include(m => m.Subjects).ToList();
            if (meetings == null)
            {
                return null;
            }

            return meetings;

            //StringBuilder builder = new StringBuilder();
            //builder.Append($"{meetings.Count} meeting(s) found. \n");
            //if (meetings.Count > 0)
            //{
            //    foreach (Meeting m in meetings)
            //    {
            //        builder.Append($"Meeting name: {m.Name}, Reference number: {m.RefNumber}\n");
            //    }
            //}
            //return builder.ToString();
        }

        public List<Employee> retreiveEmployees(List<int> ids)
        {

            List<Employee> Employees = Context.Employees.Where(x => ids.Contains(x.ID)).ToList();
            return Employees;
        }

        public List<Subject> retreiveSubjects(List<int> ids)
        {
            List<Subject> subjects = Context.Subjects.Where(s => ids.Contains(s.ID)).ToList();
            return subjects;
        }
    }
}
