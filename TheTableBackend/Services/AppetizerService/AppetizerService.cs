using AutoMapper;
using TheTableBackend.Data;

namespace TheTableBackend.Services.AppetizerService
{
    public class AppetizerService : IAppetizerService
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;
        private MealType mealType = MealType.Appetizer;

        public AppetizerService(IMapper mapper, IMealRepository mealRepository)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
        }
        public async Task<ServiceResponse<GetMealDto>> AddNewAppetizer(AddMealDto newAppetizer)
        {
            var serviceResponse = new ServiceResponse<GetMealDto>();
            Meal appetizer = _mapper.Map<Meal>(newAppetizer);
            await _mealRepository.AddNewMeal(appetizer);

            serviceResponse.Data = _mapper.Map<GetMealDto>(appetizer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMealDto>>> GetAllAppetizers()
        {
            var serviceResponse = new ServiceResponse<List<GetMealDto>>();
            var dbAppetizers = await _mealRepository.GetAllMeals(mealType);
            serviceResponse.Data = dbAppetizers.Select(a => _mapper.Map<GetMealDto>(a)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMealDto>> GetAppetizerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetMealDto>();
            Meal appetizer = await _mealRepository.GetMealById(id);
            serviceResponse.Data = _mapper.Map<GetMealDto>(appetizer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMealDto>> UpdateAppetizer(UpdateMealDto updatedAppetizer)
        {
            var serviceResponse = new ServiceResponse<GetMealDto>();

            try
            {
                // REFACTOR THIS LOGIC
                Meal appetizer = await _mealRepository.UpdateMeal(_mapper.Map<Meal>(updatedAppetizer));

                appetizer.Title = updatedAppetizer.Title;
                appetizer.Description = updatedAppetizer.Description;
                appetizer.ImageUrl = updatedAppetizer.ImageUrl;
                appetizer.VideoUrl = updatedAppetizer.VideoUrl;
                appetizer.Type = updatedAppetizer.Type;
                appetizer.LastEdited = DateTime.Now;


                serviceResponse.Data = _mapper.Map<GetMealDto>(appetizer);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetMealDto>> DeleteAppetizer(int id)
        {
            var serviceResponse = new ServiceResponse<GetMealDto>();

            try
            {
                Meal appetizerToDelete = new Meal() { Id = id };
                await _mealRepository.DeleteMeal(appetizerToDelete);

                serviceResponse.Data = _mapper.Map<GetMealDto>(appetizerToDelete);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
