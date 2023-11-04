using social_network_platform_server.Domain.AuditEntitys;
using social_network_platform_server.Domain.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace social_network_platform_server.Domain.Friends
{
    public class Friend : AuditEntity
    {
        public int MyProperty { get; set; }
        public Guid UserIdOne { get; set; }
        public Guid UserIdTwo { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        pending = 1,
        Declined = 2,
        Accepted = 3
    }

}
