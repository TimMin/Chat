using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Chat;

namespace Client
{
    class Program
    {
            static void Main(string[] args)
            {
                var channel = new DuplexChannelFactory<IService>(new ChatClientImpl(), "ServiceEndpoint");
                var server = channel.CreateChannel();
                server.Login(Environment.UserName);
                Console.WriteLine("Enter '!q' to  exit.");

                string message = Console.ReadLine();
                while (message != "!q")
                {
                    if (!(message == null || message == String.Empty))
                        server.SendMessage(message);
                    message = Console.ReadLine();
                }


                channel.Close();
            }
        }

        class ChatClientImpl : IClient
        {

            public void ReceiveMessage(string userName, string message)
            {
                Console.WriteLine("{0}: {1}", userName, message);
            }

        }
    
}
