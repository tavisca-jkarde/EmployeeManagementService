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
   
    public class EmployeeService : AddEmployeeService, RetriveEmployeeService
    {

        public  List<EmployeeDetails> listEmployee = new List<EmployeeDetails>();
       
        public void CreateEmployee(int id , string name , string remark , DateTime date)
        {
            listEmployee.Add(new EmployeeDetails() { EmployeeId = id, EmployeeName = name, RemarkText = remark , RemarkDate = date });
            
        }

        public List<EmployeeDetails> GetAllEmployeeDetails()
        {

            if (listEmployee != null)
            {
                return listEmployee;
            }
            else 
            {
                return null;
            }

        }

        public EmployeeDetails GetEmployeeDetails(int id)
        {

            return listEmployee.FirstOrDefault(p => p.EmployeeId == id);


        }

        public EmployeeDetails GetEmployeeDetails(string name)
        {

            return listEmployee.FirstOrDefault(p => p.EmployeeName == name);

        }
    }
}
