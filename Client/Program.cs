using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.EmployeeService;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using EmployeeManagementService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList =  new EmployeeManagementService.EmployeeService(); ;

            while (true)
            { 
            Console.WriteLine("1. Add Employee ");
            Console.WriteLine("2. Retrive All Employee ");
            Console.WriteLine("3. Retrive Employee By Id ");
            Console.WriteLine("4. Retrive Employee By Name ");
            Console.WriteLine("\n");
            Console.WriteLine("Please select option");
            var answer = Console.ReadLine();

            switch (answer) 
            { 
                case "1" : 
                    string value ="";

                    do
                    {
                        Console.WriteLine("Do you want to add Employee yes or no?");
                        value = Console.ReadLine();
                        if (value.ToLower() == "no") {
                            break;
                        }        
                        Console.WriteLine("Please Enter the Employee ID :");
                        int employeeId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Please Enter the Employee Name :");
                        string name = Console.ReadLine();

                        Console.WriteLine("Please Enter the Employee Remark :");
                        string remark = Console.ReadLine();

                        DateTime date = DateTime.Today;

                        employeeList.CreateEmployee(employeeId, name, remark, date);

                    } while (value == "yes");
                    
                    break;
                
                case "2" :


                    var retriveEmployee = employeeList.GetAllEmployeeDetails();
                    if (retriveEmployee != null)
                    {
                        foreach (var index in retriveEmployee)
                        {
                            Console.WriteLine("Employee ID : " + index.EmployeeId);
                            Console.WriteLine("Employee Name : " + index.EmployeeName);
                            Console.WriteLine("Employee Remark : " + index.RemarkText);
                            Console.WriteLine("Employee Remark Dade : " + index.RemarkDate);

                        }
                    }
                    else {
                        Console.WriteLine("Employee Not Found!");
                    }
                    break;

                case "3" :
                    Console.WriteLine("Please Enter The Employee ID");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    var retriveEmployeeById = employeeList.GetEmployeeDetails(empId);
                    
                    if (retriveEmployeeById != null)
                    {
                        Console.WriteLine("Employee ID : " + retriveEmployeeById.EmployeeId);
                        Console.WriteLine("Employee Name : " + retriveEmployeeById.EmployeeName);
                        Console.WriteLine("Employee Remark : " + retriveEmployeeById.RemarkText);
                        Console.WriteLine("Employee Remark Dade : " + retriveEmployeeById.RemarkDate);
                    }
                    else {
                        Console.WriteLine("Employee Not Found!");
   
                     }
                    break;

                case "4" :

                    Console.WriteLine("Enter the employee name");
                    string employeeName = Console.ReadLine();
                    var retriveEmployeeByName = employeeList.GetEmployeeDetails(employeeName);

                    if (retriveEmployeeByName != null)
                    {
                        Console.WriteLine("Employee ID : " + retriveEmployeeByName.EmployeeId);
                        Console.WriteLine("Employee Name : " + retriveEmployeeByName.EmployeeName);
                        Console.WriteLine("Employee Remark : " + retriveEmployeeByName.RemarkText);
                        Console.WriteLine("Employee Remark Dade : " + retriveEmployeeByName.RemarkDate);
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found!");

                    }
                    break;

                        
            }
                               
        }
        }
        
    }
}
