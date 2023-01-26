using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public interface IRepoMeeting : IRepoGeneric<Meeting>
    {
        public Meeting getByRefNumber(string refId);
        public string listDetails(string refId);
        public List<Meeting> listAllMeetings();
        public List<Employee> retreiveEmployees(List<int> employeeIDs);
        public List<Subject> retreiveSubjects(List <int> subjectIDs);
    }
}
