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

        [TestInitialize]
        public void ClearEmployeeList()
        {

            var clearList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService");
            clearList.ClearEmployeeList();

        }

        /// <summary>
        /// Below test case for Creating new employee.
        /// then retrive employee to check the existing employee same or not.
        /// </summary>
        [TestMethod]

        public void CreateEmployeeShouldThrow()
        {
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                DateTime date = DateTime.Now;

              

                    
                employeeList.CreateEmployee(101, "Jayvant", "Bad", date);
                
                var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
                var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();

                if (retriveEmployee != null)
                {
                    foreach (var index in retriveEmployee)
                    {
                        Assert.AreEqual(index.EmployeeId, 101);
                        Assert.AreEqual(index.EmployeeName, "Jayvant");
                        Assert.AreEqual(index.RemarkText, "Bad");

                    }
                }
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

            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);

                employeeList.AddRemark("Good", 101);

                var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
                var retriveEmployee = employeeRetrive.SearchById(101);

                if (retriveEmployee != null)
                {
                    Assert.AreEqual(retriveEmployee.RemarkText, "Good");

                }

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
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                {
                    employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                    var retriveEmployee = employeeRetrive.SearchById(101);
                    if (retriveEmployee == null)
                    {
                        Assert.Fail("Employee Does not exist");
                    }
                }
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
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                {
                    employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);

                    var retriveEmployee = employeeRetrive.SearchByName("Jayvant");
                    if (retriveEmployee == null)
                    {
                        Assert.Fail("Employee Does not exist");

                    }

                }
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
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                        var retriveEmployee = employeeRetrive.SearchByRemark("Good");
                        if (retriveEmployee == null)
                        {
                            Assert.Fail("Employee Does not exist");

                        }
                    }
                }
            }
            catch (FaultException ex) {

                Assert.AreEqual(ex.Code.Name, "Get EmployeeRemark Error");
            }

        }
        /// <summary>
        /// Below test case for to get the All Employee.
        /// Check the length of employee
        /// </summary>
        [TestMethod]
        public void GetAllEmployeeShouldThrow()
        {
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                {
                    employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                    var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();
                    Assert.AreEqual(retriveEmployee.Length, 1);
                }
            }
        }

        /// <summary>
        /// Below test case to check the employee remark.
        /// </summary>
        [TestMethod]
        public void CheckEmployeeRemarkShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                        string remark = "Bad";
                        var retriveEmployee = employeeRetrive.SearchByRemark(remark);
                        Assert.AreEqual(retriveEmployee.RemarkText, remark);
                    }

                }
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Code.Name, "Get EmployeeRemark Error");
            }
        }

        /// <summary>
        /// Below test case to check the employee Name.
        /// </summary>
        [TestMethod]
        public void CheckEmployeeNameShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                        string empName = "Sunil";
                        var retriveEmployee = employeeRetrive.SearchByName(empName);
                        Assert.AreEqual(retriveEmployee.EmployeeName, empName);

                    }
                }
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Code.Name, "Get EmployeeName Error");
            }

        }

        /// <summary>
        /// Below test case to check the employee Id.
        /// </summary>
        [TestMethod]
        public void CheckEmployeeIdShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                        int empId = 110;
                        var retriveEmployee = employeeRetrive.SearchById(empId);
                        Assert.AreEqual(retriveEmployee.EmployeeId, empId);

                    }
                }
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Code.Name, "Get EmployeeId Error");
            }
        }

        [TestMethod]

        public void DeleteEmployeeShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {                    
                    employeeList.CreateEmployee(101, "Jayvant", "Bad", DateTime.Today);
                    employeeList.DeleteEmployee(102);
                    
                }
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Code.Name, "Delete Employee Error");
            }
        }


    }
}
