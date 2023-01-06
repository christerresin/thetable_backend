namespace TheTableBackend.Interfaces
{
    public interface IMealRepository
    {
        Task<Meal> AddNewMeal(Meal newMainCourse);
        Task<List<Meal>> GetAllMeals(MealType mealType);
        Task<Meal> GetMealById(int id);
        Task<Meal> UpdateMeal(Meal updatedMeal);
        Task<Meal> DeleteMeal(Meal deleteMeal);
    }
}
