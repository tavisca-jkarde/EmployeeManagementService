using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.EmployeeService;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService");
            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");

            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("1. Add Employee ");
                Console.WriteLine("2. Retrive All Employee ");
                Console.WriteLine("3. Retrive Employee By Id ");
                Console.WriteLine("4. Retrive Employee By Name ");
                Console.WriteLine("5. Add Remark");
                Console.WriteLine("6. Retrive Employee By Remark");
                Console.WriteLine("\n");
                Console.WriteLine("Please select option");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        string value = "";

                        do
                        {
                            try
                            {

                                Console.WriteLine("Do you want to add Employee yes or no?");
                                value = Console.ReadLine();
                                if (value.ToLower() == "no")
                                {
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

                            }
                            catch (FaultException ex)
                            {
                                if (ex.Code.Name == "Create Employee Error")
                                {

                                    Console.WriteLine("Handling Create Employee Error{0}", ex.Reason);

                                }
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine("Error occured when{0}", ex.Message);

                            }

                        } while (value == "yes");

                        break;


                    case "2":

                        try
                        {
                            
                            var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();

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
                            else
                            {
                                Console.WriteLine("Employee Not Found!");
                            }

                        }
                        catch (FaultException ex)
                        {
                            if (ex.Code.Name == "Get All Employee Error")
                            {

                                Console.WriteLine("Handling Get All Employee Error{0}", ex.Reason);

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error occured when{0}", ex.Message);

                        }
                        break;

                    case "3":

                        try
                        {
                           
                            Console.WriteLine("Please Enter The Employee ID");
                            int empId = Convert.ToInt32(Console.ReadLine());
                            var retriveEmployeeById = employeeRetrive.SearchById(empId);

                            if (retriveEmployeeById != null)
                            {
                                Console.WriteLine("Employee ID : " + retriveEmployeeById.EmployeeId);
                                Console.WriteLine("Employee Name : " + retriveEmployeeById.EmployeeName);
                                Console.WriteLine("Employee Remark : " + retriveEmployeeById.RemarkText);
                                Console.WriteLine("Employee Remark Dade : " + retriveEmployeeById.RemarkDate);
                            }
                            else
                            {
                                Console.WriteLine("Employee Not Found!");

                            }

                        }
                        catch (FaultException ex)
                        {
                            if (ex.Code.Name == "Get EmployeeId Error")
                            {

                                Console.WriteLine("Handling Get Employee Error{0}", ex.Reason);

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error occured when{0}", ex.Message);

                        }
                        break;

                    case "4":

                        try
                        {
                           
                            Console.WriteLine("Enter the employee name");
                            string employeeName = Console.ReadLine();
                            var retriveEmployeeByName = employeeRetrive.SearchByName(employeeName);

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
                        }
                        catch (FaultException ex)
                        {
                            if (ex.Code.Name == "Get EmployeeName Error")
                            {

                                Console.WriteLine("Handling Get Employee Error{0}", ex.Reason);

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error occured when{0}", ex.Message);

                        }
                        break;

                    case "5":

                        try
                        {

                            Console.WriteLine("Please Enter The Employee ID");
                            int employeeID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please Enter Remark of Employee");
                            string remarkValue = Console.ReadLine();
                            employeeList.AddRemark(remarkValue, employeeID);

                        }
                        catch (FaultException ex)
                        {
                            if (ex.Code.Name == "Get EmployeeRemark Error")
                            {

                                Console.WriteLine("Handling Get Employee Error{0}", ex.Reason);

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error occured when{0}", ex.Message);

                        }
                        break;

                    case "6":

                        try
                        {
                            
                            Console.WriteLine("Please Enter Remark of Employee");
                            string getEmployeeByRemark = Console.ReadLine();
                            var retriveEmployeeByRemark = employeeRetrive.SearchByRemark(getEmployeeByRemark);

                            if (retriveEmployeeByRemark != null)
                            {
                                Console.WriteLine("Employee ID : " + retriveEmployeeByRemark.EmployeeId);
                                Console.WriteLine("Employee Name : " + retriveEmployeeByRemark.EmployeeName);
                                Console.WriteLine("Employee Remark : " + retriveEmployeeByRemark.RemarkText);
                                Console.WriteLine("Employee Remark Dade : " + retriveEmployeeByRemark.RemarkDate);
                            }
                            else
                            {
                                Console.WriteLine("Employee Not Found!");

                            }

                        }
                        catch (FaultException ex)
                        {
                            if (ex.Code.Name == "Add Remark Error")
                            {

                                Console.WriteLine("Handling Add Remark Error{0}", ex.Reason);

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error occured when{0}", ex.Message);

                        }
                        break;

                }

            }
        }

    }
}
