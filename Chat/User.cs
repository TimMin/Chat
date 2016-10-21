using System;
using System.Runtime.Serialization;

namespace Chat
{
    [DataContract]
    public class User
    {
        public string UserName { get; set; }
    }
}
