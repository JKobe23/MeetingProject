using MeetingCore;
using MeetingInfrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MeetingConsole
{
    public class Program
    {
        public static void Main(string[] args) {
           
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MeetingsContext>();
            serviceCollection.AddScoped<IRepoEmployee, EmployeeRepository>();
            serviceCollection.AddScoped<IRepoEntity, EntityRepository>();
            serviceCollection.AddScoped<IRepoMeeting, MeetingRepository>();
            serviceCollection.AddScoped<IRepoPosition, PositionRepository>();
            serviceCollection.AddScoped<IRepoSubject, SubjectRepository>();

            var provider = serviceCollection.BuildServiceProvider();
             
            IRepoEmployee? employeeRepository= provider.GetService<IRepoEmployee>();  
            IRepoEntity? entityRepository= provider.GetService<IRepoEntity>();
            IRepoMeeting? meetingRepository = provider.GetService<IRepoMeeting>();
            IRepoPosition? positionRepository = provider.GetService<IRepoPosition>();
            IRepoSubject? subjectRepository= provider.GetService<IRepoSubject>();

            int key;

            do
            {
                Console.Write(showOptions());
                if (int.TryParse(Console.ReadLine(), out key))
                {

                    if (key == 0)
                    {
                        Console.Write("Enter position name: ");
                        string positionName = Console.ReadLine();
                        while (positionName.Trim().IsNullOrEmpty() || int.TryParse(positionName, out int test))
                        {
                            Console.Write("This field is required and must not be only numbers, retry: ");
                            positionName = Console.ReadLine();
                        }
                        
                        Console.Write("Enter position level (optional): ");
                        int level;
                        string levelInput = Console.ReadLine();
                        while(!int.TryParse(levelInput, out level) || level <=0)
                        {
                            if(levelInput.Trim().IsNullOrEmpty())
                            {
                                break;
                            }
                            Console.Write("Level must strictly be a positive number, retry: ");
                            levelInput = Console.ReadLine();    
                        }

                        positionRepository.Add(new Position
                        {
                            Title = positionName,
                            Level = level
                        });
                    }

                    else if (key == 1)
                    {
                        Console.Write("Enter Company name: ");
                        string entityName = Console.ReadLine();
                        while (entityName.Trim().IsNullOrEmpty() || int.TryParse(entityName, out int test))
                        {
                            Console.Write("This field is required and cannot be only numbers, retry: ");
                            entityName = Console.ReadLine();
                        }

                        Console.Write("Enter its location: (optional): ");
                        string location = Console.ReadLine();

                        entityRepository.Add(new Entity
                        {
                            Name = entityName,
                            Location = location
                        });
                    }

                    else if (key == 2)
                    {
                        Console.Write("Enter SSN: ");
                        string ssn = Console.ReadLine();
                        while (ssn.Trim().IsNullOrEmpty() || employeeRepository.GetBySsn(ssn) != null)
                        {
                            Console.Write("This field is required and must not already exist in the database, retry: ");
                            ssn = Console.ReadLine();
                        }

                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        while (name.Trim().IsNullOrEmpty() || int.TryParse(name, out int test))
                        {
                            Console.Write("This field is required and must not be only numbers, retry: ");
                            name = Console.ReadLine();
                        }

                        int entityID;
                        Entity entity = null;
                        Console.Write("Enter an existing entity ID: ");
                        int entityFlag = 0;

                        while (entityFlag == 0)
                        {
                            if (int.TryParse(Console.ReadLine(), out entityID) && (entityID > 0))
                            {
                                if (entityRepository.GetById(entityID) != null)
                                {
                                    entity = entityRepository.GetById(entityID);
                                    entityFlag = 1;
                                }
                                else
                                {
                                    Console.Write("Must be a positive existing number in the records, re-Enter entity ID: ");
                                }
                            }
                            else
                            {
                                Console.Write("Must be a positive existing number in the records, re-Enter entity ID: ");
                            }
                        }

                        int positionID;
                        Position position = null;
                        Console.Write("Enter an existing position ID: ");
                        int positionFlag = 0;

                        while(positionFlag == 0 )
                        {
                            if(int.TryParse(Console.ReadLine(), out positionID) && (positionID > 0))
                            {
                                if(positionRepository.GetById(positionID) != null)
                                {
                                    position = positionRepository.GetById(positionID);
                                    positionFlag = 1;   
                                }
                                else
                                {
                                    Console.Write("Must be a positive existing number in the records, re-Enter position ID: ");
                                }
                            }
                            else
                            {
                                Console.Write("Must be a positive existing number in the records, re-Enter position ID: ");
                            }
                        }

                        employeeRepository.Add(new Employee
                        {
                            SSN = ssn,
                            Name = name,
                            Entity = entity,
                            Position = position
                        }) ;
                    }

                    else if (key == 3)
                    {
                        Console.WriteLine(employeeRepository.listAllEmployees());
                    }

                    else if(key == 4)
                    {
                        Console.Write("Enter SSN: ");
                        string ssn = Console.ReadLine();
                        Employee employee = null;
                        int ssnFlag = 0;
                        while(ssnFlag == 0)
                        {
                            if(!ssn.Trim().IsNullOrEmpty())
                            {
                                if(employeeRepository.GetBySsn(ssn) != null)
                                {
                                    employee = employeeRepository.GetBySsn(ssn);
                                    ssnFlag= 1;
                                }

                                else
                                {
                                    Console.Write("Not found. Enter an existing SSN: ");
                                    ssn = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.Write("SSN Cannot be empty, retry: ");
                                ssn = Console.ReadLine();
                            }
                        }
                        Console.WriteLine($"Employee Name with SSN {ssn.ToUpper()}: {employee.Name}");       
                    }

                    else if(key == 5)
                    {
                        Console.Write("Enter meeting name: ");
                        string meetingName = Console.ReadLine();
                        while(meetingName.Trim().IsNullOrEmpty() || int.TryParse(meetingName, out int test))
                        {
                            Console.Write("Meeting name cannot be null or numbers only, retry: ");
                            meetingName = Console.ReadLine();
                        }

                        Console.Write("Create meeting reference number: ");
                        string refNumber = Console.ReadLine();
                        while(refNumber.Trim().IsNullOrEmpty() || meetingRepository.getByRefNumber(refNumber) != null)
                        {
                            Console.Write("Reference number must not be empty and must not already exist, retry: ");
                            refNumber = Console.ReadLine();
                        }

                        Console.Write("Enter meeting date (mm/dd/yyyy): ");
                        DateTime meetingDate;
                        while(!DateTime.TryParse(Console.ReadLine(), out meetingDate))
                        {
                            Console.Write("You should enter a date, and in the specified format. Retry: ");
                        }

                        Console.Write("Enter meeting location: ");
                        string location = Console.ReadLine();
                        while(location.Trim().IsNullOrEmpty())
                        {
                            Console.Write("Should enter a location, retry: ");
                            location = Console.ReadLine();
                        }

                        Console.Write("Enter meeting notes (optional): ");
                        string notes = Console.ReadLine();

                        Console.Write("Type (a) if you wish to add Employees to the meeting, type any character otherwise: ");
                        string a = Console.ReadLine();

                        HashSet<string> ssns = new HashSet<string>();
                        if (a.ToLower().Equals("a"))
                        {
                            string addMoreEmployees = "y"; 
                            while(addMoreEmployees.ToLower().Equals("y"))
                            {
                                string employeeSsn;
                                Console.Write("Enter SSN of Empolyee to be added to this meeting: ");
                                employeeSsn = Console.ReadLine();
                                while(employeeSsn.Trim().IsNullOrEmpty() || employeeRepository.GetBySsn(employeeSsn) == null)
                                {
                                    Console.Write("Nonexistent or empty value entered, retry (type 'cancel' to exit this task): ");
                                    employeeSsn= Console.ReadLine();
                                    if(employeeSsn.ToLower().Equals("cancel"))
                                    {
                                        break;
                                    }
                                }
                                if (employeeSsn.ToLower() != "cancel") 
                                {
                                    if (ssns.Add(employeeSsn))
                                    {
                                        Console.Write("Add more Employees? (Type y for yes, any character for no): ");
                                        addMoreEmployees = Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("This employee is/was part of this meeting.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Employee addition canceled as requested.");
                                    Console.Write("Add more Employees? (Type y for yes, any character for no): ");
                                    addMoreEmployees = Console.ReadLine();

                                }
                            }
                        }
                        HashSet<Subject> subjects = new HashSet<Subject>();

                        Console.Write("Type (s) if you wish to add subjects to the meeting, type any character otherwise: ");
                        string s = Console.ReadLine();
                        if (s.ToLower().Equals("s"))
                        {
                            Console.Write("New or existing? (Type (e) for existing, any character for new): ");
                            string exSubject = Console.ReadLine();
                            if(exSubject.Equals("e"))
                            {
                                string moreExisting = "y";
                                while(moreExisting.Equals("y")) {
                                    Console.Write("Enter an existing subject reference number: ");
                                    string subjref = Console.ReadLine();
                                    while(subjref.Trim().IsNullOrEmpty() || subjectRepository.getByRefNumber(subjref) == null)
                                    {
                                        Console.Write("Subject reference number cannot be nonexistent or empty, retry: ");
                                        subjref = Console.ReadLine();
                                    }
                                    Subject exsubj = subjectRepository.getByRefNumber(subjref);
                                    subjects.Add(exsubj);
                                    Console.Write("Add more existing subjects? (y for yes, any character otherwise): ");
                                    moreExisting = Console.ReadLine();
                                }
                            }
                            Console.Write("Create new subject(s): ");
                            string addMoreSubjects = "y";
                            while(addMoreSubjects.ToLower().Equals("y"))
                            {
                                string subjectRefNumber;
                                Console.Write("Create subject Reference number: ");
                                subjectRefNumber = Console.ReadLine();
                                while(subjectRefNumber.Trim().IsNullOrEmpty() || subjectRepository.getByRefNumber(subjectRefNumber) != null)
                                {
                                    Console.Write("Cannot be empty or already existing, re-enter: ");
                                    subjectRefNumber = Console.ReadLine();
                                }

                                Console.Write("Enter subject title: ");
                                string subjectTitle = Console.ReadLine();
                                while (subjectTitle.Trim().IsNullOrEmpty())
                                {
                                    Console.Write("Cannot be empty, re-enter: ");
                                    subjectTitle = Console.ReadLine();
                                }

                                Console.Write("Enter subject description: ");
                                string desc = Console.ReadLine();
                                while (desc.Trim().IsNullOrEmpty())
                                {
                                    Console.Write("Cannot be empty, re-enter: ");
                                    desc = Console.ReadLine();
                                }

                                Console.Write("Enter subject decision: ");
                                string decision = Console.ReadLine();
                                while (decision.Trim().IsNullOrEmpty())
                                {
                                    Console.Write("Cannot be empty, re-enter: ");
                                    decision = Console.ReadLine();
                                }

                                Subject subject = new Subject
                                {
                                    Title = subjectTitle,
                                    RefNumber = subjectRefNumber,
                                    Description = desc,
                                    Decision = decision
                                };

                                if (subjects.Add(subject))
                                {
                                    subjectRepository.Add(subject);
                                    Console.Write("Subject added. Add more? (y for yes, any for no): ");
                                    addMoreSubjects = Console.ReadLine();
                                }

                                else
                                {
                                    Console.WriteLine("Subject creation error.");
                                }
                            }
                        }
                        Meeting meeting = new Meeting
                        {
                            Name = meetingName,
                            RefNumber = refNumber,
                            Date = meetingDate,
                            Location = location,
                            Notes = notes
                        };

                        if (!ssns.IsNullOrEmpty())
                        {
                            List<Employee> employees = new List<Employee>();
                            foreach(string sn in ssns)
                            {
                                employees.Add(employeeRepository.GetBySsn(sn));
                            }
                            meeting.Employees = employees; 
                        }

                        if(!subjects.IsNullOrEmpty())
                        {
                            meeting.Subjects = subjects;
                        }
                        meetingRepository.Add(meeting);
                        Console.WriteLine("Meeting successfully created.");

                    }

                    else if (key == 6)
                    {
                        Console.Write("Enter meeting Reference number: ");
                        string refId = Console.ReadLine();
                        while(refId.Trim().IsNullOrEmpty())
                        {
                            Console.Write("Enter a non-empty exising reference number: ");
                            refId = Console.ReadLine();
                        }
                        Console.WriteLine("\n" + meetingRepository.listDetails(refId));
                    }

                    else if (key ==7)
                    {
                        Console.WriteLine(meetingRepository.listAllMeetings());
                    }

                    else break;
                    Console.WriteLine("Iteration Complete");
                }
                else
                {
                    Console.WriteLine("Enter a number only");
                }
            } while (key != -1);
        }

        public static String showOptions()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("------------------------------------------------------------------------------------------------------------------------\n");
            builder.Append("Add position: Press 0 \n");
            builder.Append("Add Entity (Company/Organization): Press 1 \n");
            builder.Append("Add Employee: Press 2 \n");
            builder.Append("List all employee details: Press 3 \n");
            builder.Append("Find an employee by SSN: Press 4 \n");
            builder.Append("Create a new meeting: Press 5 \n");
            builder.Append("Find meeting by reference: Press 6 \n");
            builder.Append("List all meetings: Press 7 \n");
            builder.Append("End process: Press -1 or any other key \n");
            builder.Append("------------------------------------------------------------------------------------------------------------------------\n");
            builder.Append("Your Input: ");

            return builder.ToString();
        } 
    }
}