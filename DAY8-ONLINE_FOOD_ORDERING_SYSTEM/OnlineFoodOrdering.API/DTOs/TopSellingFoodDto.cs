namespace OnlineFoodOrdering.API.DTOs
{
    public class TopSellingFoodDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalSalesAmount { get; set; }
    }
}