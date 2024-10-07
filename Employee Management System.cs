using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class Program
    {
        // Employee class to store employee details
        public class Employee
        {
            public long Id { get; set; } // Changed from int to long
            public string Name { get; set; }
            public string Position { get; set; }
            public double Salary { get; set; }
        }

        // Static list to act as database
        static List<Employee> Employees = new List<Employee>();
        static long employeeIdCounter = 1; // Changed from int to long

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ViewEmployees();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Method to add a new employee
        static void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Add New Employee");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();
            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Employees.Add(new Employee
            {
                Id = employeeIdCounter++, // Employee ID is now long
                Name = name,
                Position = position,
                Salary = salary
            });

            Console.WriteLine("Employee added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        // Method to view all employees
        static void ViewEmployees()
        {
            Console.Clear();
            Console.WriteLine("Employee List:");
            foreach (var employee in Employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary:C}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to update an employee's details
        static void UpdateEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee ID to update: ");
            long id = Convert.ToInt64(Console.ReadLine());  // Changed to long
            var employee = Employees.Find(e => e.Id == id);

            if (employee != null)
            {
                Console.Write("Enter new Name (leave blank to keep unchanged): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    employee.Name = name;
                }

                Console.Write("Enter new Position (leave blank to keep unchanged): ");
                string position = Console.ReadLine();
                if (!string.IsNullOrEmpty(position))
                {
                    employee.Position = position;
                }

                Console.Write("Enter new Salary (leave blank to keep unchanged): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(salaryInput))
                {
                    employee.Salary = Convert.ToDouble(salaryInput);
                }

                Console.WriteLine("Employee updated successfully! Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Employee not found! Press any key to continue...");
            }
            Console.ReadKey();
        }

        // Method to delete an employee
        static void DeleteEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee ID to delete: ");
            long id = Convert.ToInt64(Console.ReadLine()); // Changed to long
            var employee = Employees.Find(e => e.Id == id);

            if (employee != null)
            {
                Employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully! Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Employee not found! Press any key to continue...");
            }
            Console.ReadKey();
        }
    }
}
