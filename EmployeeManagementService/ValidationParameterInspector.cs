using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace EmployeeManagementService
{
    public class ValidationParameterInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {


        }

        public object BeforeCall(string operationName, object[] inputs)
        {

            if (operationName == "CreateEmployee")
            {
                int employeeId = Convert.ToInt32(inputs[0]);
                if (employeeId <= -1)
                    throw new FaultException(new FaultReason("Negative Id cannot exist as employee Id"), new FaultCode("122"));

            }

            if (operationName == "SearchByName")
            {

                string name = Convert.ToString(inputs[0]);

                if (name == null)
                    throw new FaultException(new FaultReason("Employee name should not be null"), new FaultCode("Get EmployeeName Error"));
            }

            if (operationName == "SearchById")
            {
                int employeeId = Convert.ToInt32(inputs[0]);
                if (employeeId <= 0)
                {
                    throw new FaultException(new FaultReason("Employee Id should not be less that zero"), new FaultCode("Get EmployeeId Error"));
                }
                else if (employeeId == null)
                {
                    throw new FaultException(new FaultReason("Employee Id should not be null"), new FaultCode("Get EmployeeId Error"));
                }
            }

            if (operationName == "SearchByRemark")
            {
                string remark = Convert.ToString(inputs[0]);
                if (remark == null || remark == "")
                {
                    throw new FaultException(new FaultReason("Employee name should not be null"), new FaultCode("Get EmployeeRemark Error"));
                }
            }
            if (operationName == "DeleteEmployee")
            {
                int employeeId = Convert.ToInt32(inputs[0]);
                if (employeeId <= 0)
                {
                    throw new FaultException(new FaultReason("Employee Id should not be less that zero"), new FaultCode("Delete Employee Error"));
                }
                else if (employeeId == null)
                {
                    throw new FaultException(new FaultReason("Employee Id should not be null"), new FaultCode("Delete Employee Error"));
                }
            }

            return null;
        }
    }
}