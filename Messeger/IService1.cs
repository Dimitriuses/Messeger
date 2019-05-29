using Messeger.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Messeger
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        bool AddNewUser(Loger login, string email, string phone);
        //string HelloResponse(string name);
        [OperationContract]
        bool ReloadEmailUser(Loger Userloger, string Email);
        [OperationContract]
        bool ReloadPhonelUser(Loger Userloger, string phone);
        [OperationContract]
        bool AddChatToParticipants(Loger loger, int[] participants, int chatId);
        [OperationContract]
        bool AddNewChat(Loger login, string name);
        //decimal SimpleCalculator(decimal a, decimal b, char @operator);

        [OperationContract]
        List<string> GetChatList(Loger Userloger);
        //Message GetMessageById(int id);
        [OperationContract]
        List<UserDTO> GetChatParticipant(Loger loger, int chatId);
        [OperationContract]
        List<MessageDTO> GetMessages(Loger Userloger, int chatID);
        //bool Add(Message message);
        [OperationContract]
        bool UserLogin(Loger loger);
        [OperationContract]
        bool UserExists(Loger loger);
        [OperationContract]
        bool PushMessage(string text, Loger loger,int ChatId);
        [OperationContract]
        string GetLoginById(int id);
        [OperationContract]
        List<UserDTO> GetUserListByFindMode(string findstring);
        [OperationContract]
        UserDTO GetUserProfile(Loger loger);
        [OperationContract]
        bool RenameUser(Loger loger, string name, string surname);
        [OperationContract]
        string GetEmail(Loger loger);
        [OperationContract]
        string GetPhone(Loger loger);
        //[OperationContract]
        //bool UploadFile(Loger loger, RemoteFileInfo fileInfo, int ChatId);
        // TODO: Add your service operations here
    }




    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


    [ServiceContract]
    public interface ITransferService
    {
        [OperationContract]
        RemoteFileInfo DownloadFile(DownloadRequest request);

        [OperationContract]
        void UploadFile(RemoteFileInfo request);
    }
    [MessageContract]
    public class DownloadRequest
    {
        [MessageBodyMember]
        public string FileName;
    }

    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
