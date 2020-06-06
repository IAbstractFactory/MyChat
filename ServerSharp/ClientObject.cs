using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Sockets;
using System.Text;

namespace ServerSharp
{
    public class ClientObject
    {
        public string Name { get; private set; }
        public ClientObject(string name) { Name = name; }
    }
}
