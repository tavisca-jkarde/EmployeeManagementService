﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagementServiceFixture.EmployeeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class FaultDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExceptionMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InnerExceptionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExceptionMessage {
            get {
                return this.ExceptionMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ExceptionMessageField, value) != true)) {
                    this.ExceptionMessageField = value;
                    this.RaisePropertyChanged("ExceptionMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InnerException {
            get {
                return this.InnerExceptionField;
            }
            set {
                if ((object.ReferenceEquals(this.InnerExceptionField, value) != true)) {
                    this.InnerExceptionField = value;
                    this.RaisePropertyChanged("InnerException");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmployeeDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class EmployeeDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RemarkDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkTextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmployeeId {
            get {
                return this.EmployeeIdField;
            }
            set {
                if ((this.EmployeeIdField.Equals(value) != true)) {
                    this.EmployeeIdField = value;
                    this.RaisePropertyChanged("EmployeeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeName {
            get {
                return this.EmployeeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeNameField, value) != true)) {
                    this.EmployeeNameField = value;
                    this.RaisePropertyChanged("EmployeeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RemarkDate {
            get {
                return this.RemarkDateField;
            }
            set {
                if ((this.RemarkDateField.Equals(value) != true)) {
                    this.RemarkDateField = value;
                    this.RaisePropertyChanged("RemarkDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RemarkText {
            get {
                return this.RemarkTextField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkTextField, value) != true)) {
                    this.RemarkTextField = value;
                    this.RaisePropertyChanged("RemarkText");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.AddEmployeeService")]
    public interface AddEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/AddEmployeeService/CreateEmployeeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeManagementServiceFixture.EmployeeService.FaultDetails), Action="http://tempuri.org/AddEmployeeService/CreateEmployeeFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        void CreateEmployee(int id, string name, string remark, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddEmployeeService/AddRemark", ReplyAction="http://tempuri.org/AddEmployeeService/AddRemarkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeManagementServiceFixture.EmployeeService.FaultDetails), Action="http://tempuri.org/AddEmployeeService/AddRemarkFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        void AddRemark(string remark, int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AddEmployeeServiceChannel : EmployeeManagementServiceFixture.EmployeeService.AddEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddEmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeManagementServiceFixture.EmployeeService.AddEmployeeService>, EmployeeManagementServiceFixture.EmployeeService.AddEmployeeService {
        
        public AddEmployeeServiceClient() {
        }
        
        public AddEmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AddEmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddEmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddEmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CreateEmployee(int id, string name, string remark, System.DateTime date) {
            base.Channel.CreateEmployee(id, name, remark, date);
        }
        
        public void AddRemark(string remark, int id) {
            base.Channel.AddRemark(remark, id);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.RetriveEmployeeService")]
    public interface RetriveEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RetriveEmployeeService/GetAllEmployeeDetails", ReplyAction="http://tempuri.org/RetriveEmployeeService/GetAllEmployeeDetailsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeManagementServiceFixture.EmployeeService.FaultDetails), Action="http://tempuri.org/RetriveEmployeeService/GetAllEmployeeDetailsFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails[] GetAllEmployeeDetails();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RetriveEmployeeService/SearchById", ReplyAction="http://tempuri.org/RetriveEmployeeService/SearchByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeManagementServiceFixture.EmployeeService.FaultDetails), Action="http://tempuri.org/RetriveEmployeeService/SearchByIdFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails SearchById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RetriveEmployeeService/SearchByName", ReplyAction="http://tempuri.org/RetriveEmployeeService/SearchByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeManagementServiceFixture.EmployeeService.FaultDetails), Action="http://tempuri.org/RetriveEmployeeService/SearchByNameFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails SearchByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RetriveEmployeeService/SearchByRemark", ReplyAction="http://tempuri.org/RetriveEmployeeService/SearchByRemarkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeManagementServiceFixture.EmployeeService.FaultDetails), Action="http://tempuri.org/RetriveEmployeeService/SearchByRemarkFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails SearchByRemark(string remark);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface RetriveEmployeeServiceChannel : EmployeeManagementServiceFixture.EmployeeService.RetriveEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RetriveEmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeManagementServiceFixture.EmployeeService.RetriveEmployeeService>, EmployeeManagementServiceFixture.EmployeeService.RetriveEmployeeService {
        
        public RetriveEmployeeServiceClient() {
        }
        
        public RetriveEmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RetriveEmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetriveEmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetriveEmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails[] GetAllEmployeeDetails() {
            return base.Channel.GetAllEmployeeDetails();
        }
        
        public EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails SearchById(int id) {
            return base.Channel.SearchById(id);
        }
        
        public EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails SearchByName(string name) {
            return base.Channel.SearchByName(name);
        }
        
        public EmployeeManagementServiceFixture.EmployeeService.EmployeeDetails SearchByRemark(string remark) {
            return base.Channel.SearchByRemark(remark);
        }
    }
}
