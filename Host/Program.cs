using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Chat.Service));

            host.Open();

            Console.WriteLine("Server started. . .");
            Console.ReadKey();

            host.Close();
        }
    }
}
