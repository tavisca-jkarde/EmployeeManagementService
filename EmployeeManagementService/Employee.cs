using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface AddEmployeeService
    {
        [OperationContract]
        void CreateEmployee(int id, string name, string remark, DateTime date);

        [OperationContract]
        void AddRemark(string remark, int id);

        
    }

    [ServiceContract]
    public interface RetriveEmployeeService
    {

        [OperationContract]
        List<EmployeeDetails> GetAllEmployeeDetails();

        [OperationContract (Name="SearchById")]
        EmployeeDetails GetEmployeeDetails(int id);

        [OperationContract(Name = "SearchByName")]
        EmployeeDetails GetEmployeeDetails(string name);

        [OperationContract(Name = "SearchByRemark")]
        EmployeeDetails GetEmployeeDetailsByRemark(string remark);
        
     }

    [DataContract]
    public class EmployeeDetails
    {
        [DataMember]
        public int EmployeeId { get; set; }
        
        [DataMember]
        public string EmployeeName { get; set; }

        [DataMember]
        public string RemarkText { get; set; }

        [DataMember]
        public DateTime RemarkDate { get; set; }

    }
}
