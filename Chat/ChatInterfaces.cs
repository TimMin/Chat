using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private Dictionary<IClient, User> users = new Dictionary<IClient, User>();

        public void SendMessage(string message)
        {
            var client = OperationContext.Current.GetCallbackChannel<IClient>();
            User user;
            users.TryGetValue(client, out user);
            foreach (var otherClient in users.Keys)
            {
                if (otherClient != client)
                otherClient.ReceiveMessage(user.UserName, message);
            }
        }

        public void Login(string userName)
        {
            var client = OperationContext.Current.GetCallbackChannel<IClient>();
            User user = new User { UserName = userName };
            users[client] = user;
            Console.WriteLine(userName + " entered");
        }



    }

}
