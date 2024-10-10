using System.Collections.Generic;
using System.Linq;

namespace Linq_part_4
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public float Salary { get; set; }
        public string JobId { get; set; }
        public float? CommissionPct { get; set; }
        public string? PhoneNumber { get; set; }  

        public Employee(int id, string name, int departmentId, float salary, string jobId = null, float? commissionPct = null, string? phoneNumber = null)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
            Salary = salary;
            JobId = jobId;
            CommissionPct = commissionPct;
            PhoneNumber = phoneNumber;  
        }

        public override string ToString()
        {
            return
                $"name: {Name}, " +
                $"departmentId: {DepartmentId}, " +
                $"salary: {Salary}, " +
                $"phoneNumber: {PhoneNumber}";  // Добавлено для отображения номера телефона
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Department(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public override string ToString()
        {
            return $"id: {Id}, title: {Title}";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var departments = new List<Department>
            {
                new Department(10, "IT IT"),
                new Department(20, "Sales"),
                new Department(30, "Marketing"),
                new Department(50, "HR"),
                new Department(80, "Finance")
            };

            var employees = new List<Employee>
            {
                new Employee(1, "Bob", 10, 2500),
                new Employee(2, "Alex", 20, 1700),
                new Employee(3, "Arnold", 20, 1700),
                new Employee(4, "Petro", 10, 3700),
                new Employee(5, "Vasya", 50, 4000),
                new Employee(6, "Yula", 80, 2500, "IT_PROG", 0.15f, "999 333 7777"),
                new Employee(7, "David", 50, 4500, "IT_PROG"),
                new Employee(8, "Marta", 30, 5000),
                new Employee(9, "Anna", 30, 6000, null, 0.1f),
                new Employee(10, "Nina", 50, 7000),
                new Employee(11, "Mia%", 50, 8500),
                new Employee(12, "Lionotorororor", 20, 1000, phoneNumber: "222 111 444"),
            };
            Console.WriteLine("----------------Part 1----------------");
            // 1
            var allEmployees = employees.ToList();
            Console.WriteLine("Список всіх співробітників:");
            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee);
            }

            // 2
            var employeesNamedDavid = employees.Where(e => e.Name == "David");
            Console.WriteLine("\nСпівробітники з ім'ям 'David':");
            foreach (var employee in employeesNamedDavid)
            {
                Console.WriteLine(employee);
            }

            // 3
            var employeesWithJob = employees.Where(e => e.JobId == "IT_PROG");
            Console.WriteLine("\nСпівробітники з job_id 'IT_PROG':");
            foreach (var employee in employeesWithJob)
            {
                Console.WriteLine(employee);
            }

            // 4
            var employeesFromDepartment5 = employees
                .Where(e => e.DepartmentId == 50 && e.Salary > 4000);
            Console.WriteLine("\nСпівробітники з 50-го відділу з зарплатою > 4000:");
            foreach (var employee in employeesFromDepartment5)
            {
                Console.WriteLine(employee);
            }

            // 5
            var employeesFromD = employees.Where(e => e.DepartmentId == 20 || e.DepartmentId == 30);
            Console.WriteLine("\nСпівробітники з 20-го та 30-го відділу:");
            foreach (var employee in employeesFromD)
            {
                Console.WriteLine(employee);
            }

            // 6
            var employeesEndinghA = employees.Where(e => e.Name.EndsWith("a"));
            Console.WriteLine("\nСпівробітники, у яких остання літера в імені 'a':");
            foreach (var employee in employeesEndinghA)
            {
                Console.WriteLine(employee);
            }

            // 7
            var employeesWithBonus = employees.Where(e => (e.DepartmentId == 50 || e.DepartmentId == 80) && e.CommissionPct.HasValue);
            Console.WriteLine("\nСпівробітники з 50-го та 80-го відділу, у яких є бонус:");
            foreach (var employee in employeesWithBonus)
            {
                Console.WriteLine(employee);
            }

            // 8. 
            var employeesWithTwo = employees.Where(e => e.Name.Count(c => c == 'n') >= 2);
            Console.WriteLine("\nСпівробітники, у яких в імені міститься мінімум 2 літери 'n':");
            foreach (var employee in employeesWithTwo)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("----------------Part 2----------------");

            //1
            var salaryRange = employees.Where(e => e.Salary >= 8000 && e.Salary <= 9000);
            foreach (var employee in salaryRange)
            {
                Console.WriteLine(employee);
            }
            //2
            var percentSymbol= employees.Where(e => e.Name.Contains('%'));
            foreach (var employee in percentSymbol)
            {
                Console.WriteLine(employee);
            }

            // 3
            var managerIds = employees.Where(e => string.IsNullOrEmpty(e.JobId)).Select(e => e.Id);
            foreach (var id in managerIds)
            {
                Console.WriteLine(id);
            }

            // 4
            var longNameEmployees = employees.Where(e => e.Name.Length > 10);
            foreach (var employee in longNameEmployees)
            {
                Console.WriteLine(employee);
            }

            // 5
            var bLetterEmployees = employees.Where(e => e.Name.IndexOf('b', StringComparison.OrdinalIgnoreCase) >= 0);
            foreach (var employee in bLetterEmployees)
            {
                Console.WriteLine(employee);
            }

            // 6
            var doubleALetter = employees.Where(e => e.Name.Count(c => c == 'a') >= 2);
            foreach (var employee in doubleALetter)
            {
                Console.WriteLine(employee);
            }

            // 7
            var divisibleBy1000 = employees.Where(e => e.Salary % 1000 == 0);
            foreach (var employee in divisibleBy1000)
            {
                Console.WriteLine(employee);
            }

            //8
            var phoneNumberThree = employees.Select(e => e.PhoneNumber?.Substring(0, 3)).Distinct();

            foreach (var three in phoneNumberThree)
            {
                Console.WriteLine(three);
            }

            //9
            var firstWords = departments.Where(d => d.Title.Split(' ').Length > 1)
                                                          .Select(d => d.Title.Split(' ')[0]);

            foreach (var word in firstWords)
            {
                Console.WriteLine(word);
            }

        }
    }
}