using AutoMapper;
using WebAPI.Domain.DTOs.Request;
using WebAPI.Domain.DTOs.Response;

namespace WebAPI.Domain.Map;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category,CategoryResponse>();
        CreateMap<CategoryRequest, Category>();
    }
}
