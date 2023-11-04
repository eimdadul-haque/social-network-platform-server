using social_network_platform_server.Domain.AuditEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Domain.Messages
{
    public class Message : AuditEntity
    {
        public Guid SenderID { get; set; }
        public Guid RecipientID { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
    }
}