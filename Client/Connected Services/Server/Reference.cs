﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Server {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/Messeger")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Loger", Namespace="http://schemas.datacontract.org/2004/07/Messeger")]
    [System.SerializableAttribute()]
    public partial class Loger : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordHashField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordHash {
            get {
                return this.PasswordHashField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordHashField, value) != true)) {
                    this.PasswordHashField = value;
                    this.RaisePropertyChanged("PasswordHash");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageDTO", Namespace="http://schemas.datacontract.org/2004/07/Messeger.DTO")]
    [System.SerializableAttribute()]
    public partial class MessageDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ChatIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] ReciversIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SenderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
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
        public int ChatId {
            get {
                return this.ChatIdField;
            }
            set {
                if ((this.ChatIdField.Equals(value) != true)) {
                    this.ChatIdField = value;
                    this.RaisePropertyChanged("ChatId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateTime {
            get {
                return this.DateTimeField;
            }
            set {
                if ((this.DateTimeField.Equals(value) != true)) {
                    this.DateTimeField = value;
                    this.RaisePropertyChanged("DateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] ReciversId {
            get {
                return this.ReciversIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ReciversIdField, value) != true)) {
                    this.ReciversIdField = value;
                    this.RaisePropertyChanged("ReciversId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SenderId {
            get {
                return this.SenderIdField;
            }
            set {
                if ((this.SenderIdField.Equals(value) != true)) {
                    this.SenderIdField = value;
                    this.RaisePropertyChanged("SenderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="LogerDTO", Namespace="http://schemas.datacontract.org/2004/07/Messeger.DTO")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.Server.UserDTO))]
    public partial class LogerDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDTO", Namespace="http://schemas.datacontract.org/2004/07/Messeger.DTO")]
    [System.SerializableAttribute()]
    public partial class UserDTO : Client.Server.LogerDTO {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SurName {
            get {
                return this.SurNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurNameField, value) != true)) {
                    this.SurNameField = value;
                    this.RaisePropertyChanged("SurName");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Server.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        Client.Server.CompositeType GetDataUsingDataContract(Client.Server.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Client.Server.CompositeType> GetDataUsingDataContractAsync(Client.Server.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewUser", ReplyAction="http://tempuri.org/IService1/AddNewUserResponse")]
        bool AddNewUser(Client.Server.Loger login, string email, string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewUser", ReplyAction="http://tempuri.org/IService1/AddNewUserResponse")]
        System.Threading.Tasks.Task<bool> AddNewUserAsync(Client.Server.Loger login, string email, string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReloadEmailUser", ReplyAction="http://tempuri.org/IService1/ReloadEmailUserResponse")]
        bool ReloadEmailUser(Client.Server.Loger Userloger, string Email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReloadEmailUser", ReplyAction="http://tempuri.org/IService1/ReloadEmailUserResponse")]
        System.Threading.Tasks.Task<bool> ReloadEmailUserAsync(Client.Server.Loger Userloger, string Email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReloadPhonelUser", ReplyAction="http://tempuri.org/IService1/ReloadPhonelUserResponse")]
        bool ReloadPhonelUser(Client.Server.Loger Userloger, string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReloadPhonelUser", ReplyAction="http://tempuri.org/IService1/ReloadPhonelUserResponse")]
        System.Threading.Tasks.Task<bool> ReloadPhonelUserAsync(Client.Server.Loger Userloger, string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewChat", ReplyAction="http://tempuri.org/IService1/AddNewChatResponse")]
        bool AddNewChat(Client.Server.Loger login, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewChat", ReplyAction="http://tempuri.org/IService1/AddNewChatResponse")]
        System.Threading.Tasks.Task<bool> AddNewChatAsync(Client.Server.Loger login, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetChatList", ReplyAction="http://tempuri.org/IService1/GetChatListResponse")]
        string[] GetChatList(Client.Server.Loger Userloger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetChatList", ReplyAction="http://tempuri.org/IService1/GetChatListResponse")]
        System.Threading.Tasks.Task<string[]> GetChatListAsync(Client.Server.Loger Userloger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMessages", ReplyAction="http://tempuri.org/IService1/GetMessagesResponse")]
        Client.Server.MessageDTO[] GetMessages(Client.Server.Loger Userloger, int chatID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMessages", ReplyAction="http://tempuri.org/IService1/GetMessagesResponse")]
        System.Threading.Tasks.Task<Client.Server.MessageDTO[]> GetMessagesAsync(Client.Server.Loger Userloger, int chatID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserLogin", ReplyAction="http://tempuri.org/IService1/UserLoginResponse")]
        bool UserLogin(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserLogin", ReplyAction="http://tempuri.org/IService1/UserLoginResponse")]
        System.Threading.Tasks.Task<bool> UserLoginAsync(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserExists", ReplyAction="http://tempuri.org/IService1/UserExistsResponse")]
        bool UserExists(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserExists", ReplyAction="http://tempuri.org/IService1/UserExistsResponse")]
        System.Threading.Tasks.Task<bool> UserExistsAsync(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PushMessage", ReplyAction="http://tempuri.org/IService1/PushMessageResponse")]
        bool PushMessage(string text, Client.Server.Loger loger, int ChatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PushMessage", ReplyAction="http://tempuri.org/IService1/PushMessageResponse")]
        System.Threading.Tasks.Task<bool> PushMessageAsync(string text, Client.Server.Loger loger, int ChatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLoginById", ReplyAction="http://tempuri.org/IService1/GetLoginByIdResponse")]
        string GetLoginById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLoginById", ReplyAction="http://tempuri.org/IService1/GetLoginByIdResponse")]
        System.Threading.Tasks.Task<string> GetLoginByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserListByFindMode", ReplyAction="http://tempuri.org/IService1/GetUserListByFindModeResponse")]
        Client.Server.LogerDTO[] GetUserListByFindMode(string findstring);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserListByFindMode", ReplyAction="http://tempuri.org/IService1/GetUserListByFindModeResponse")]
        System.Threading.Tasks.Task<Client.Server.LogerDTO[]> GetUserListByFindModeAsync(string findstring);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserProfile", ReplyAction="http://tempuri.org/IService1/GetUserProfileResponse")]
        Client.Server.UserDTO GetUserProfile(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserProfile", ReplyAction="http://tempuri.org/IService1/GetUserProfileResponse")]
        System.Threading.Tasks.Task<Client.Server.UserDTO> GetUserProfileAsync(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RenameUser", ReplyAction="http://tempuri.org/IService1/RenameUserResponse")]
        bool RenameUser(Client.Server.Loger loger, string name, string surname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RenameUser", ReplyAction="http://tempuri.org/IService1/RenameUserResponse")]
        System.Threading.Tasks.Task<bool> RenameUserAsync(Client.Server.Loger loger, string name, string surname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEmail", ReplyAction="http://tempuri.org/IService1/GetEmailResponse")]
        string GetEmail(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEmail", ReplyAction="http://tempuri.org/IService1/GetEmailResponse")]
        System.Threading.Tasks.Task<string> GetEmailAsync(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPhone", ReplyAction="http://tempuri.org/IService1/GetPhoneResponse")]
        string GetPhone(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPhone", ReplyAction="http://tempuri.org/IService1/GetPhoneResponse")]
        System.Threading.Tasks.Task<string> GetPhoneAsync(Client.Server.Loger loger);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Client.Server.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Client.Server.IService1>, Client.Server.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Client.Server.CompositeType GetDataUsingDataContract(Client.Server.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Client.Server.CompositeType> GetDataUsingDataContractAsync(Client.Server.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public bool AddNewUser(Client.Server.Loger login, string email, string phone) {
            return base.Channel.AddNewUser(login, email, phone);
        }
        
        public System.Threading.Tasks.Task<bool> AddNewUserAsync(Client.Server.Loger login, string email, string phone) {
            return base.Channel.AddNewUserAsync(login, email, phone);
        }
        
        public bool ReloadEmailUser(Client.Server.Loger Userloger, string Email) {
            return base.Channel.ReloadEmailUser(Userloger, Email);
        }
        
        public System.Threading.Tasks.Task<bool> ReloadEmailUserAsync(Client.Server.Loger Userloger, string Email) {
            return base.Channel.ReloadEmailUserAsync(Userloger, Email);
        }
        
        public bool ReloadPhonelUser(Client.Server.Loger Userloger, string phone) {
            return base.Channel.ReloadPhonelUser(Userloger, phone);
        }
        
        public System.Threading.Tasks.Task<bool> ReloadPhonelUserAsync(Client.Server.Loger Userloger, string phone) {
            return base.Channel.ReloadPhonelUserAsync(Userloger, phone);
        }
        
        public bool AddNewChat(Client.Server.Loger login, string name) {
            return base.Channel.AddNewChat(login, name);
        }
        
        public System.Threading.Tasks.Task<bool> AddNewChatAsync(Client.Server.Loger login, string name) {
            return base.Channel.AddNewChatAsync(login, name);
        }
        
        public string[] GetChatList(Client.Server.Loger Userloger) {
            return base.Channel.GetChatList(Userloger);
        }
        
        public System.Threading.Tasks.Task<string[]> GetChatListAsync(Client.Server.Loger Userloger) {
            return base.Channel.GetChatListAsync(Userloger);
        }
        
        public Client.Server.MessageDTO[] GetMessages(Client.Server.Loger Userloger, int chatID) {
            return base.Channel.GetMessages(Userloger, chatID);
        }
        
        public System.Threading.Tasks.Task<Client.Server.MessageDTO[]> GetMessagesAsync(Client.Server.Loger Userloger, int chatID) {
            return base.Channel.GetMessagesAsync(Userloger, chatID);
        }
        
        public bool UserLogin(Client.Server.Loger loger) {
            return base.Channel.UserLogin(loger);
        }
        
        public System.Threading.Tasks.Task<bool> UserLoginAsync(Client.Server.Loger loger) {
            return base.Channel.UserLoginAsync(loger);
        }
        
        public bool UserExists(Client.Server.Loger loger) {
            return base.Channel.UserExists(loger);
        }
        
        public System.Threading.Tasks.Task<bool> UserExistsAsync(Client.Server.Loger loger) {
            return base.Channel.UserExistsAsync(loger);
        }
        
        public bool PushMessage(string text, Client.Server.Loger loger, int ChatId) {
            return base.Channel.PushMessage(text, loger, ChatId);
        }
        
        public System.Threading.Tasks.Task<bool> PushMessageAsync(string text, Client.Server.Loger loger, int ChatId) {
            return base.Channel.PushMessageAsync(text, loger, ChatId);
        }
        
        public string GetLoginById(int id) {
            return base.Channel.GetLoginById(id);
        }
        
        public System.Threading.Tasks.Task<string> GetLoginByIdAsync(int id) {
            return base.Channel.GetLoginByIdAsync(id);
        }
        
        public Client.Server.LogerDTO[] GetUserListByFindMode(string findstring) {
            return base.Channel.GetUserListByFindMode(findstring);
        }
        
        public System.Threading.Tasks.Task<Client.Server.LogerDTO[]> GetUserListByFindModeAsync(string findstring) {
            return base.Channel.GetUserListByFindModeAsync(findstring);
        }
        
        public Client.Server.UserDTO GetUserProfile(Client.Server.Loger loger) {
            return base.Channel.GetUserProfile(loger);
        }
        
        public System.Threading.Tasks.Task<Client.Server.UserDTO> GetUserProfileAsync(Client.Server.Loger loger) {
            return base.Channel.GetUserProfileAsync(loger);
        }
        
        public bool RenameUser(Client.Server.Loger loger, string name, string surname) {
            return base.Channel.RenameUser(loger, name, surname);
        }
        
        public System.Threading.Tasks.Task<bool> RenameUserAsync(Client.Server.Loger loger, string name, string surname) {
            return base.Channel.RenameUserAsync(loger, name, surname);
        }
        
        public string GetEmail(Client.Server.Loger loger) {
            return base.Channel.GetEmail(loger);
        }
        
        public System.Threading.Tasks.Task<string> GetEmailAsync(Client.Server.Loger loger) {
            return base.Channel.GetEmailAsync(loger);
        }
        
        public string GetPhone(Client.Server.Loger loger) {
            return base.Channel.GetPhone(loger);
        }
        
        public System.Threading.Tasks.Task<string> GetPhoneAsync(Client.Server.Loger loger) {
            return base.Channel.GetPhoneAsync(loger);
        }
    }
}
