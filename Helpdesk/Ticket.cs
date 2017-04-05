using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.IO;

namespace Helpdesk
{
    class Ticket
    {
        string message { get; set; }
        string topic { get; set; }
        int userId { get; }
        DateTime creationTime { get; }
        DateTime closed { get; set; }

        public Ticket(string topic, string message, int userId )
        {
            this.message = message;
            this.topic = topic;
            this.userId = userId;
        }

        public void Post()
        {

        }
   
    }

}
