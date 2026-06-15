using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrdering.API.Models
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }

        public string RequestUrl { get; set; }

        public string HttpMethod { get; set; }

        public DateTime RequestTime { get; set; }

        public DateTime ResponseTime { get; set; }
    }
}