﻿using System;
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
        /// <summary>
        /// Create List for the Employee
        /// </summary>
        public List<EmployeeDetails> listEmployee = new List<EmployeeDetails>();


        /// <summary>
        /// To create Employee.
        /// If employee already exist then throw Fault exception.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <param name="name">Employee Name</param>
        /// <param name="remark">Employee Remark</param>
        /// <param name="date">Employee Remark Date</param>
        public void CreateEmployee(int id, string name, string remark, DateTime date)
        {
            try
            {
                if (listEmployee.Any(p => p.EmployeeId == id))
                {
                    throw new FaultException(new FaultReason("Employee Already Exist"), new FaultCode("Create Employee Error"));
                }
                else
                {

                    listEmployee.Add(new EmployeeDetails() { EmployeeId = id, EmployeeName = name, RemarkText = remark, RemarkDate = date });
                }

            }
            catch
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured Employee All ready Exist.";
                ex.InnerException = "Inner exception from Employee Management service.";
                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Create Employee Error"));
            }

        }

        /// <summary>
        /// Return Employee Record.
        /// </summary>
        /// <returns>All Employee Record</returns>
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
                    throw new Exception();
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

        /// <summary>
        /// Return Employee record by employee id.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>return that employee record if employee ID exist</returns>
        public EmployeeDetails GetEmployeeDetails(int id)
        {

            var getEmployeeById = listEmployee.FirstOrDefault(p => p.EmployeeId == id);

            try
            {
                if (getEmployeeById == null)
                {
                    throw new Exception();
                }
                else
                {
                    return getEmployeeById;

                }

            }
            catch 
            {

                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting employee record by EmployeeID.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get EmployeeId Error"));
            }
        }

        /// <summary>
        /// Return Employee record by employee name.
        /// </summary>
        /// <param name="id">Employee name</param>
        /// <returns>return that employee record if employee Name exist</returns>
        public EmployeeDetails GetEmployeeDetails(string name)
        {

            var getEmployeeByName = listEmployee.FirstOrDefault(p => p.EmployeeName == name);

            try
            {

                if (getEmployeeByName == null)
                {

                    throw new Exception();
                }
                else
                {

                    return getEmployeeByName;

                }
            }
            catch
            {

                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting employee record by Employee Name.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get EmployeeName Error"));
            }
        }


        /// <summary>
        /// Add  or change remark if employee id exist in database.
        /// </summary>
        /// <param name="remark">Employee remark</param>
        /// <param name="id">Employee Id</param>
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

        /// <summary>
        /// Return employee record by employee remark.
        /// </summary>
        /// <param name="remark">Employee Remark</param>
        /// <returns>Employee Record if Remark exist.</returns>
        public EmployeeDetails GetEmployeeDetailsByRemark(string remark)
        {

            var getEmployeeByRemark = listEmployee.FirstOrDefault(p => p.RemarkText == remark);

            try
            {
                if (getEmployeeByRemark == null)
                {
                    throw new Exception();

                }
                else
                {
                    return getEmployeeByRemark;
                }
            }
            catch (Exception)
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while getting employee record by Employee Remark.";
                ex.InnerException = "Inner exception from Employee Management service.";

                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Get EmployeeRemark Error"));
            }


        }

        /// <summary>
        /// To clear the employee list.
        /// </summary>
        public void ClearEmployeeList()
        {
            listEmployee.Clear();

        }

        /// <summary>
        /// To Delete Employee from employee list.
        /// </summary>

        public void DeleteEmployee(int id)
        {
            try
            {
                var itemToRemove = listEmployee.SingleOrDefault(p => p.EmployeeId == id);

                if (itemToRemove != null)
                {
                    listEmployee.Remove(itemToRemove);

                }
                else {

                    throw new Exception();
                }

            }
            catch (Exception)
             
            {
                FaultDetails ex = new FaultDetails();
                ex.ExceptionMessage = "Exception occured while delete employee";
                ex.InnerException = "Inner exception from Employee Management service.";
                throw new FaultException(new FaultReason(ex.ExceptionMessage), new FaultCode("Delete Employee Error"));

            }
        }
        
    }
}