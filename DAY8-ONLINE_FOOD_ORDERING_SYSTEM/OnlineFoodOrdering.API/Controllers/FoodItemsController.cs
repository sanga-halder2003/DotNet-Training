using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrdering.API.Models;
using OnlineFoodOrdering.API.Services;

namespace OnlineFoodOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;

        public FoodItemsController(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoodItems()
        {
            var foodItems = await _foodItemService.GetAllFoodItems();
            return Ok(foodItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodItemById(int id)
        {
            var foodItem = await _foodItemService.GetFoodItemById(id);

            if (foodItem == null)
            {
                return NotFound("Food item not found");
            }

            return Ok(foodItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodItem(FoodItem foodItem)
        {
            var createdFoodItem = await _foodItemService.AddFoodItem(foodItem);

            return CreatedAtAction(
                nameof(GetFoodItemById),
                new { id = createdFoodItem.FoodId },
                createdFoodItem
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodItem(int id, FoodItem foodItem)
        {
            var result = await _foodItemService.UpdateFoodItem(id, foodItem);

            if (result == false)
            {
                return NotFound("Food item not found");
            }

            return Ok("Food item updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            var result = await _foodItemService.DeleteFoodItem(id);

            if (result == false)
            {
                return NotFound("Food item not found");
            }

            return Ok("Food item deleted successfully");
        }



        [HttpGet("search")]
        public async Task<IActionResult> SearchFoodItems([FromQuery] string name)
        {
            var foodItems = await _foodItemService.SearchFoodItems(name);
            return Ok(foodItems);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetFoodItemsByCategory(int categoryId)
        {
            var foodItems = await _foodItemService.GetFoodItemsByCategory(categoryId);
            return Ok(foodItems);
        }
    }
}