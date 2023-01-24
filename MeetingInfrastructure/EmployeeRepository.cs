using MeetingCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class EmployeeRepository : GenericRepository<Employee>, IRepoEmployee
    {
        public EmployeeRepository(MeetingsContext context) : base(context)
        {
            
        }

        public Employee GetBySsn(string ssn)
        {
            Employee? employee = Context.Employees.Include(e => e.Entity).Include(e => e.Position)
                                                 .SingleOrDefault(e => e.SSN.ToLower() == ssn.ToLower());
            return employee;
        }

        public List<Employee> listAllEmployees()
        {
            List<Employee> employees = Context.Employees.Include(e => e.Entity).Include(e => e.Position).ToList();

            if (employees.IsNullOrEmpty())
            {
                return null;
            }
            
            //StringBuilder builder= new StringBuilder();
            //builder.Append($"All {employees.Count} employee(s) in the database: \n");
            //foreach (Employee e in employees)
            //{
            //    builder.Append(e.Name);
            //    builder.Append(", ");
            //    builder.Append($"SSN: {e.SSN}");
            //    builder.Append("\n");
            //    builder.Append($"{e.Position.Title} at {e.Entity.Name} \n");
            //}

            return employees;
        }

    }
}
