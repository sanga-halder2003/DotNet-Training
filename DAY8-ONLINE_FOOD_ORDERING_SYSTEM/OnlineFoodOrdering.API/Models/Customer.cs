using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineFoodOrdering.API.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
    }
}