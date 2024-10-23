using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint3Rewiew
{
    public interface IEmployee
    {
        string Name { get; set; }
        string Position { get; set; }
        decimal Salary { get; set; }

        void PrintInfo();
    }


    public interface IReportable
    {
        string GenerateReport();
    }


    public interface ITeamLeader
    {
        List<string> GetTeamMembers();
    }


    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set;}

        public Employee(string name, string position, decimal salary)
        {
            Name = name; 
            Position = position; 
            Salary = salary;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Employee:\n" +
                $"Name: {Name}\n" +
                $"Position: {Position}\n" +
                $"Salary: {Salary}");
        }
    }


    public class Manager : Employee
    {
        public List<string> Members = new List<string>();

        public string Departament { get; set; }

        public Manager(
            string name, string position, decimal salary, string  departament
            ) : base(name, position, salary)
        {
            Departament = departament;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Departament: {Departament}");
        }
    }


    public class ProjectManager : Manager, IReportable, ITeamLeader
    {
        public string ProjectName { get; set; }

        public ProjectManager(
            string name, string position, decimal salary, string departament, string progectName
            ) : base(name, position, salary, departament)
        {
            ProjectName = progectName;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"ProgectName: {ProjectName}");
        }

        public virtual string GenerateReport()
        {
            return "Строка с отчётом";
        }

        public virtual void AddEmploee(Employee employee)
        {
            Members.Add(employee.Name);
        }

        public virtual List<string> GetTeamMembers()
        {
            return Members;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Димон", "Программист", 100000.0m);
            employee.PrintInfo();
            Manager manager = new Manager("Петя", "Менеджер", 200000.7m, "Департамент");
            manager.PrintInfo();
            ProjectManager projectManager = new ProjectManager(
                "Михаил", "Проектный менеджер", 120000.5m, "Департамент", "Google"
                );
            projectManager.PrintInfo();
            projectManager.AddEmploee(employee);
            string report = projectManager.GenerateReport();
            Console.WriteLine(report);
            List<string> teamMembers = projectManager.GetTeamMembers();
            foreach (string teamMember in teamMembers)
            {
                Console.WriteLine(teamMember);
            }
            Console.ReadKey();
        }
    }
}
