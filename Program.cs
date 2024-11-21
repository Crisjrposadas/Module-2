using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, string position, decimal salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{Id}: {Name}, {Position}, ${Salary}";
    }
}

public class EmployeeManagementSystem
{
    private List<Employee> employees;

    public EmployeeManagementSystem()
    {
        employees = new List<Employee>();
    }

  
    public void Create(int id, string name, string position, decimal salary)
    {
        
        if (employees.Any(e => e.Id == id))
        {
            Console.WriteLine("Employee with this ID already exists.");
            return;
        }

        Employee newEmployee = new Employee(id, name, position, salary);
        employees.Add(newEmployee);
        Console.WriteLine("Employee added successfully.");
    }

    
    
    public void ListAllEmployees()
    {
        Console.WriteLine("\nAll Employees:");
        if (employees.Any())
        {
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
        else
        {
            Console.WriteLine("No employees available.");
        }
    }

    
    public Employee FindEmployeeById(int id)
    {
        return employees.FirstOrDefault(e => e.Id == id);
    }

    
    public void Update(int id, string name, string position, decimal salary)
    {
        var employee = FindEmployeeById(id);
        if (employee != null)
        {
            employee.Name = name;
            employee.Position = position;
            employee.Salary = salary;
            Console.WriteLine("Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee with this ID not found.");
        }
    }

    
    public void Delete(int id)
    {
        var employee = FindEmployeeById(id);
        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee with this ID not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var employeeSystem = new EmployeeManagementSystem();

        while (true)
        {
            Console.WriteLine("\n--- Employee Management System ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List All Employees");
            Console.WriteLine("3. Find Employee by ID");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    
                    Console.Write("Enter Employee ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Employee Position: ");
                    string position = Console.ReadLine();
                    Console.Write("Enter Employee Salary: ");
                    decimal salary = decimal.Parse(Console.ReadLine());

                    employeeSystem.Create(id, name, position, salary);
                    break;

                case "2":
                    
                    employeeSystem.ListAllEmployees();
                    break;

                case "3":
                    
                    Console.Write("Enter Employee ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    var employee = employeeSystem.FindEmployeeById(searchId);
                    if (employee != null)
                    {
                        Console.WriteLine("Employee Found: " + employee);
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                    break;

                case "4":
                    
                    Console.Write("Enter Employee ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Position: ");
                    string newPosition = Console.ReadLine();
                    Console.Write("Enter New Salary: ");
                    decimal newSalary = decimal.Parse(Console.ReadLine());

                    employeeSystem.Update(updateId, newName, newPosition, newSalary);
                    break;

                case "5":
                    
                    Console.Write("Enter Employee ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());

                    employeeSystem.Delete(deleteId);
                    break;

                case "6":
                    
                    Console.WriteLine("Exiting the system.");
                    return;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}

