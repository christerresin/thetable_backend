namespace TheTableBackend.Interfaces
{
    public interface IAppetizerService
    {
        Task<ServiceResponse<List<GetMealDto>>> GetAllAppetizers();
        Task<ServiceResponse<GetMealDto>> GetAppetizerById(int id);
        Task<ServiceResponse<GetMealDto>> AddNewAppetizer(AddMealDto appetizer);
        Task<ServiceResponse<GetMealDto>> UpdateAppetizer(UpdateMealDto updatedAppetizer);
        Task<ServiceResponse<GetMealDto>> DeleteAppetizer(int id);
    }
}
