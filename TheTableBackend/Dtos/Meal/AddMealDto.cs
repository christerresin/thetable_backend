using TheTableBackend.Models;

namespace TheTableBackend.Dtos.Meal
{
    public class AddMealDto
    {
        public string? Title { get; set; }
        public string Description { get; set; } = "No description added for this meal";
        public string? VideoUrl { get; set; } = null;
        public string? ImageUrl { get; set; } = null;
        public MealType Type { get; set; } = MealType.Appetizer;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
    }
}
