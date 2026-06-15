using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementAPI.Models
{
    [Table("LeaveRequests")]
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

        public string? Status { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeModel? Employee { get; set; }
    }
}