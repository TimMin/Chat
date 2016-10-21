using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat
{
    public interface IClient
    {

        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string userName, string message);
    }

    [ServiceContract(CallbackContract = typeof(IClient))]
    public interface IService
    {
        [OperationContract]
        void Login(string userName);


        [OperationContract]
        void SendMessage(string message);

    }
}
