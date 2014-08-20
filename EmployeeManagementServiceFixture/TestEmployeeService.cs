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
        private TestContext _testContextInstance;

        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        /// <summary>
        /// To clear the employee list before run any test case.
        /// </summary>
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
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void CreateEmployeeShouldThrow()
        {
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                DateTime date = DateTime.Today;

                var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
                var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();

                if (retriveEmployee != null)
                {
                    foreach (var index in retriveEmployee)
                    {
                        Assert.AreEqual(index.EmployeeId, employeeId);
                        Assert.AreEqual(index.EmployeeName, employeeName);
                        Assert.AreEqual(index.RemarkText, employeeRemark);

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
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void AddRemarkShouldThrow()
        {

            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                DateTime date = DateTime.Today;

                var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);

                employeeList.AddRemark("Good", employeeId);

                var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService");
                var retriveEmployee = employeeRetrive.SearchById(employeeId);

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
        
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void GetEmployeeDetailsByIdShouldThrow()
        {
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                {
                    DateTime date = DateTime.Today;

                    var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                    var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                    var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                    employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                    var retriveEmployee = employeeRetrive.SearchById(employeeId);
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
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void GetEmployeeDetailsByNameShouldThrow()
        {
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                {
                    DateTime date = DateTime.Today;

                    var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                    var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                    var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                    employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                    string employeeNameValue = "Jayvant";
                    var retriveEmployee = employeeRetrive.SearchByName(employeeNameValue);
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
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void GetEmployeeDetailsByRemarkShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        DateTime date = DateTime.Today;
                        var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                        var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                        var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                        employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                        string remark = "Good";
                        var retriveEmployee = employeeRetrive.SearchByRemark(remark);
                        if (retriveEmployee == null)
                        {
                            Assert.Fail("Employee Does not exist");

                        }
                    }
                }
            }
            catch (FaultException ex)
            {

                Assert.AreEqual(ex.Code.Name, "Get EmployeeRemark Error");
            }

        }
        /// <summary>
        /// Below test case for to get the All Employee.
        /// Check the length of employee
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void GetAllEmployeeShouldThrow()
        {
            using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
            {
                using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                {
                    DateTime date = DateTime.Today;
                    var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                    var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                    var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                    employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                    var retriveEmployee = employeeRetrive.GetAllEmployeeDetails();
                    Assert.AreEqual(retriveEmployee.Length, 1);
                }
            }
        }

        /// <summary>
        /// Below test case to check the employee remark.
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void CheckEmployeeRemarkShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        DateTime date = DateTime.Today;
                        var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                        var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                        var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                        employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                        string remark = "";
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
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void CheckEmployeeNameShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        DateTime date = DateTime.Today;
                        var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                        var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                        var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                        employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                        string employeeNameValue = "";
                        var retriveEmployee = employeeRetrive.SearchByName(employeeNameValue);
                        Assert.AreEqual(retriveEmployee.EmployeeName, employeeNameValue);

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
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]

        public void CheckEmployeeIdShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    using (var employeeRetrive = new RetriveEmployeeServiceClient("WSHttpBinding_RetriveEmployeeService"))
                    {
                        DateTime date = DateTime.Today;
                        var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                        var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                        var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                        employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                        int employeeIdValue = 0;
                        var retriveEmployee = employeeRetrive.SearchById(employeeIdValue);
                        Assert.AreEqual(retriveEmployee.EmployeeId, employeeIdValue);

                    }
                }
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Code.Name, "Get EmployeeId Error");
            }
        }


        /// <summary>
        /// Below test case for to delete employee if Employee id exist.
        /// if employee id does not exist then should throw exception.
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"EmployeeDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"EmployeeDataSource.xml",
                   "Employee",
                    DataAccessMethod.Sequential)]
        public void DeleteEmployeeShouldThrow()
        {
            try
            {
                using (var employeeList = new AddEmployeeServiceClient("BasicHttpBinding_AddEmployeeService"))
                {
                    DateTime date = DateTime.Today;
                    var employeeId = Convert.ToInt32(_testContextInstance.DataRow["EmployeeId"].ToString());
                    var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                    var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();

                    employeeList.CreateEmployee(employeeId, employeeName, employeeRemark, date);
                    int employeeID = 101;
                    employeeList.DeleteEmployee(employeeID);

                }
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Code.Name, "Delete Employee Error");
            }
        }


    }
}
