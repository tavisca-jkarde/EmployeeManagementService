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
        [FaultContract(typeof(FaultDetails))]
        void CreateEmployee(int id, string name, string remark, DateTime date);

        [OperationContract]
        [FaultContract(typeof(FaultDetails))]
        void AddRemark(string remark, int id);

        [OperationContract]
        void ClearEmployeeList();

        
    }

    [ServiceContract]
    public interface RetriveEmployeeService
    {

        [OperationContract]
        [FaultContract(typeof(FaultDetails))]
        List<EmployeeDetails> GetAllEmployeeDetails();

        [OperationContract (Name="SearchById")]
        [FaultContract(typeof(FaultDetails))]
        EmployeeDetails GetEmployeeDetails(int id);

        [OperationContract(Name = "SearchByName")]
        [FaultContract(typeof(FaultDetails))]
        EmployeeDetails GetEmployeeDetails(string name);

        [OperationContract(Name = "SearchByRemark")]
        [FaultContract(typeof(FaultDetails))]
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


    [DataContract]
    public class FaultDetails
    {               
        [DataMember]
        public string ExceptionMessage;

        [DataMember]
        public string InnerException;

    }       

}
