using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeeService : AddEmployeeService, RetriveEmployeeService
    {

        public List<EmployeeDetails> listEmployee = new List<EmployeeDetails>();

        public void CreateEmployee(int id, string name, string remark, DateTime date)
        {
            try
            {
                if (listEmployee.Any(p => p.EmployeeId == id))
                {
                    throw new FaultException(new FaultReason("Employee Already Exist"), new FaultCode("Duplicate Employee"));
                }
                else {

                    listEmployee.Add(new EmployeeDetails() { EmployeeId = id, EmployeeName = name, RemarkText = remark, RemarkDate = date });
                }
                
            }
            catch
            {

                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured Employee Allready Exist.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Create Employee Error"));
            }

        }

        public List<EmployeeDetails> GetAllEmployeeDetails()
        {
            try
            {

                if (listEmployee.Count != 0)
                {
                    return listEmployee;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting all employee record.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get All Employee Error"));
            }
        }

        public EmployeeDetails GetEmployeeDetails(int id)
        {
            try
            {
                return listEmployee.FirstOrDefault(p => p.EmployeeId == id);
            }
            catch
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting employee record by EmployeeID.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get EmployeeId Error"));
            }
        }

        public EmployeeDetails GetEmployeeDetails(string name)
        {
            try
            {
                return listEmployee.FirstOrDefault(p => p.EmployeeName == name);
            }
            catch
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting employee record by Employee Name.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get EmployeeName Error"));
            }
        }

        public void AddRemark(string remark, int id)
        {
            try
            {
                var index = listEmployee.FindIndex(p => p.EmployeeId == id);

                if (index != -1)
                {
                    listEmployee[index].RemarkText = remark;

                }

            }
            catch
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while add remark";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Add Remark Error"));

            }

        }

        public EmployeeDetails GetEmployeeDetailsByRemark(string remark)
        {
            try
            {
                return listEmployee.FirstOrDefault(p => p.RemarkText == remark);
            }
            catch
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting employee record by Employee Remark.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get EmployeeRemark Error"));
            }
        }

    }
}