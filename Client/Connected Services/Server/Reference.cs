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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.Server.User))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Messeger")]
    [System.SerializableAttribute()]
    public partial class User : Client.Server.Loger {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/Messeger")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.Server.Sender SenderField;
        
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
        public Client.Server.Sender Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Sender", Namespace="http://schemas.datacontract.org/2004/07/Messeger.Model")]
    [System.SerializableAttribute()]
    public partial class Sender : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.Server.Message[] MessagesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.Server.User UserField;
        
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
        public Client.Server.Message[] Messages {
            get {
                return this.MessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.MessagesField, value) != true)) {
                    this.MessagesField = value;
                    this.RaisePropertyChanged("Messages");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.Server.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
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
        bool AddNewChat(Client.Server.Loger login, string name, int[] participants);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewChat", ReplyAction="http://tempuri.org/IService1/AddNewChatResponse")]
        System.Threading.Tasks.Task<bool> AddNewChatAsync(Client.Server.Loger login, string name, int[] participants);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetChatList", ReplyAction="http://tempuri.org/IService1/GetChatListResponse")]
        string[] GetChatList(Client.Server.Loger Userloger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetChatList", ReplyAction="http://tempuri.org/IService1/GetChatListResponse")]
        System.Threading.Tasks.Task<string[]> GetChatListAsync(Client.Server.Loger Userloger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMessages", ReplyAction="http://tempuri.org/IService1/GetMessagesResponse")]
        Client.Server.Message[] GetMessages(Client.Server.Loger Userloger, int chatID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMessages", ReplyAction="http://tempuri.org/IService1/GetMessagesResponse")]
        System.Threading.Tasks.Task<Client.Server.Message[]> GetMessagesAsync(Client.Server.Loger Userloger, int chatID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ThisLoginIsUnique", ReplyAction="http://tempuri.org/IService1/ThisLoginIsUniqueResponse")]
        bool ThisLoginIsUnique(string Login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ThisLoginIsUnique", ReplyAction="http://tempuri.org/IService1/ThisLoginIsUniqueResponse")]
        System.Threading.Tasks.Task<bool> ThisLoginIsUniqueAsync(string Login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserExists", ReplyAction="http://tempuri.org/IService1/UserExistsResponse")]
        bool UserExists(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserExists", ReplyAction="http://tempuri.org/IService1/UserExistsResponse")]
        System.Threading.Tasks.Task<bool> UserExistsAsync(Client.Server.Loger loger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PushMessage", ReplyAction="http://tempuri.org/IService1/PushMessageResponse")]
        bool PushMessage(Client.Server.Message message, Client.Server.Loger loger, int ChatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PushMessage", ReplyAction="http://tempuri.org/IService1/PushMessageResponse")]
        System.Threading.Tasks.Task<bool> PushMessageAsync(Client.Server.Message message, Client.Server.Loger loger, int ChatId);
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
        
        public bool AddNewChat(Client.Server.Loger login, string name, int[] participants) {
            return base.Channel.AddNewChat(login, name, participants);
        }
        
        public System.Threading.Tasks.Task<bool> AddNewChatAsync(Client.Server.Loger login, string name, int[] participants) {
            return base.Channel.AddNewChatAsync(login, name, participants);
        }
        
        public string[] GetChatList(Client.Server.Loger Userloger) {
            return base.Channel.GetChatList(Userloger);
        }
        
        public System.Threading.Tasks.Task<string[]> GetChatListAsync(Client.Server.Loger Userloger) {
            return base.Channel.GetChatListAsync(Userloger);
        }
        
        public Client.Server.Message[] GetMessages(Client.Server.Loger Userloger, int chatID) {
            return base.Channel.GetMessages(Userloger, chatID);
        }
        
        public System.Threading.Tasks.Task<Client.Server.Message[]> GetMessagesAsync(Client.Server.Loger Userloger, int chatID) {
            return base.Channel.GetMessagesAsync(Userloger, chatID);
        }
        
        public bool ThisLoginIsUnique(string Login) {
            return base.Channel.ThisLoginIsUnique(Login);
        }
        
        public System.Threading.Tasks.Task<bool> ThisLoginIsUniqueAsync(string Login) {
            return base.Channel.ThisLoginIsUniqueAsync(Login);
        }
        
        public bool UserExists(Client.Server.Loger loger) {
            return base.Channel.UserExists(loger);
        }
        
        public System.Threading.Tasks.Task<bool> UserExistsAsync(Client.Server.Loger loger) {
            return base.Channel.UserExistsAsync(loger);
        }
        
        public bool PushMessage(Client.Server.Message message, Client.Server.Loger loger, int ChatId) {
            return base.Channel.PushMessage(message, loger, ChatId);
        }
        
        public System.Threading.Tasks.Task<bool> PushMessageAsync(Client.Server.Message message, Client.Server.Loger loger, int ChatId) {
            return base.Channel.PushMessageAsync(message, loger, ChatId);
        }
    }
}
