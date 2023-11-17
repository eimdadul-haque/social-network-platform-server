using Microsoft.AspNetCore.Identity;
using social_network_platform_server.Domain.AuditEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Domain.Accounts
{
    public class ApplicationUser : IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
