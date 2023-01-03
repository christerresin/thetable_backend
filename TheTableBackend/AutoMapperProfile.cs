using AutoMapper;

namespace TheTableBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Meal, GetMealDto>();
        }
    }
}
