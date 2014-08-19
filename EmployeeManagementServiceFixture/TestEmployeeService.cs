using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagementServiceFixture.EmployeeService;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EmployeeManagementServiceFixture
{
    [TestClass]
    public class TestEmployeeService 
    {

        /// <summary>
        /// Below test case for Creating new employee.
        /// then retrive employee to check the existing employee same or not.
        /// </summary>
        [TestMethod]
        
        public void CreateEmployeeShouldThrow()
        {
            var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService");
            DateTime date = DateTime.Now;

            employeeList.CreateEmployee(101, "Jayvant", "Bad", date);

            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
            var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();

            if (retriveEmployee != null)
            {
                foreach (var index in retriveEmployee)
                {
                    Assert.AreEqual(index.EmployeeId,101);
                    Assert.AreEqual(index.EmployeeName, "Jayvant");
                    Assert.AreEqual(index.RemarkText,"Bad");
                   
                }
            }
            else
            {
                throw new FaultException(new FaultReason("Employee Does not exist"), new FaultCode("103"));
            }
                       
        }

        /// <summary>
        /// Below test case for Add remark.
        /// Then get employee through employee ID.
        /// Then check the the remark of that employee.
        /// </summary>
        [TestMethod]
        public void AddRemarkShouldThrow() 
        {
            var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService");
            employeeList.AddRemark("Good", 101);

            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
            var retriveEmployee = employeeRetrive.SearchById(101);

            if (retriveEmployee != null)
            {
                Assert.AreEqual(retriveEmployee.RemarkText, "Good");

            }
            else
            {
                throw new FaultException(new FaultReason("Employee Does not exist"), new FaultCode("103"));
            }

        }

        /// <summary>
        /// Below test case for to get the Employee through EmployeeId.
        /// If employee Id does exist in database, it will pass.
        /// If employee Id does not exist in database, it will fail.
        /// </summary>
        [TestMethod]
        public void GetEmployeeDetailsByIdShouldThrow() 
        {
            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
            var retriveEmployee = employeeRetrive.SearchById(101);
            if (retriveEmployee == null)
            {
                throw new FaultException(new FaultReason("Employee Does not exist"), new FaultCode("104"));
            }
        }

        /// <summary>
        /// Below test case for to get the Employee through Employee Name.
        /// If employee Name does exist in database, it will pass.
        /// If employee Name does not exist in database, it will fail.
        /// </summary>
        [TestMethod]
        public void GetEmployeeDetailsByNameShouldThrow()
        {
            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
            var retriveEmployee = employeeRetrive.SearchByName("Jayvant");
            if (retriveEmployee == null)
            {
                throw new FaultException(new FaultReason("Employee Does not exist"), new FaultCode("105"));

            }
        }
        
        /// <summary>
        /// Below test case for to get the Employee through Employee Remark.
        /// If employee Remark does exist in database, it will pass.
        /// If employee Remark does not exist in database, it will fail.
        /// </summary>
        [TestMethod]
        public void GetEmployeeDetailsByRemarkShouldThrow()
        {
            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
            var retriveEmployee = employeeRetrive.SearchByRemark("Good");
            if (retriveEmployee == null)
            {
                //Assert.Fail("Employee Does not exist");
                throw new FaultException(new FaultReason("Employee Does not exist"), new FaultCode("106"));

            }

        }
        /// <summary>
        /// Below test case for to get the All Employee.
        /// Check the length of employee
        /// </summary>
        [TestMethod]
        public void GetAllEmployeeShouldThrow()
        {
            var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
            var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();

            Assert.AreEqual(retriveEmployee.Length, 1);

        }



        
    }
}
