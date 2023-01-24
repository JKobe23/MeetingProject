using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public interface IRepoEmployee : IRepoGeneric<Employee>
    {
        public List<Employee> listAllEmployees();
        public Employee GetBySsn(string ssn);
    }
}
