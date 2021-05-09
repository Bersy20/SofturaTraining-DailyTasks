using DbFirstProject.OrgModel;
using System;

namespace DbFirstProject
{
    class Program
    {
        //public static SofturaCFContext db = new SofturaCFContext();
        public static Employee employee = new Employee();
        private static Employee AcceptDetails()
        {
            Console.WriteLine("Enter Employee name");
            employee.Ename = Console.ReadLine();
            Console.WriteLine("Enter Employee Date Of Birth");
            employee.Dob = Console.ReadLine();
            Console.WriteLine("Enter Employee Phone Number");
            employee.Phone = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary");
            employee.Salary = Console.ReadLine();
            Console.WriteLine("Enter Employee Department");
            employee.Department = Console.ReadLine();
            return employee;
        }
        public static Employee GetEmployeeId()
        {
            using (var db = new SofturaCFContext())
            {
                Console.WriteLine("Enter employee Id ");
                int id = Convert.ToInt32(Console.ReadLine());
                employee = db.Employees.Find(id);
                return employee;
            }
        }
        public static void AddEmployeeDetails(Employee employee)
        {
            using (var db = new SofturaCFContext())
            {
                AcceptDetails();
                db.Employees.Add(employee);
                db.SaveChanges();
                Console.WriteLine("Records added successfully");
            }
        }
        private static void DisplayAllEmployees()
        {
            using (var db = new SofturaCFContext())
            {
                foreach (var item in db.Employees)
                {

                    Console.WriteLine(item.Eid + " " + item.Ename + " " + item.Dob + " " + item.Phone + " " + item.Salary + " " + item.Department);
        
                }
            }

        }
        private static void DisplayEmployeeById()
        {
            using (var db = new SofturaCFContext())
            {
                employee = GetEmployeeId();
                if (employee == null)
                {
                    Console.WriteLine("No such Employees");
                }
                else
                {
                    Console.WriteLine(employee);
                }
            }
        }
        private static void DeleteEmployeeById()
        {
            using (var db = new SofturaCFContext())
            {
                employee = GetEmployeeId();
                if (employee == null)
                {
                    Console.WriteLine("No such Employees");
                }
                else
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    Console.WriteLine("Employee Records Deleted successfullyy");
                }
            }
        }
        private static void UpdateEmployeeDetails()
        {
            using (var db = new SofturaCFContext())
            {
                employee = GetEmployeeId();
                Console.WriteLine(employee.ToString());
                employee = AcceptDetails();
                db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                Console.WriteLine("Records of this employee is updated sucessfullyy");
            }
        }
        
        public void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add Employee Records");
                Console.WriteLine("2. Print all the Employee Details ");
                Console.WriteLine("3. Delete Employee Records By Id");
                Console.WriteLine("4. Print Employee Details By ID");
                Console.WriteLine("5. Update Employee Details");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter the Operation to be Done");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployeeDetails(employee);
                        break;
                    case 2:
                        DisplayAllEmployees();
                        break;
                    case 3:
                        DeleteEmployeeById();
                        break;
                    case 4:
                        DisplayEmployeeById();
                        break;
                    case 5:
                        UpdateEmployeeDetails();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 6);
        }
        static void Main(string[] args)
        {
            new Program().PrintMenu();
        }
    }
    
}
