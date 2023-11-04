using social_network_platform_server.Domain.Accounts;
using social_network_platform_server.Domain.AuditEntitys;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_network_platform_server.Domain.Notifications
{
    public class Notification : AuditEntity<Guid>
    {
        public int MyProperty { get; set; }

        public string Content { get; set; }

        public DateTime NotificationDate { get; set; }

        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
