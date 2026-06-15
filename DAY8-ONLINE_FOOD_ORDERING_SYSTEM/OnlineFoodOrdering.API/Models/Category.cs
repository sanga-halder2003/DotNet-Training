using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineFoodOrdering.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<FoodItem>? FoodItems { get; set; }
    }
}