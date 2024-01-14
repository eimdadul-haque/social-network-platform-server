using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts
{
    public class AuditEntityDto<Tkey>
    {
        public Tkey? Id { get; set; }
        public DateTime Created { get; set; } = new();
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
