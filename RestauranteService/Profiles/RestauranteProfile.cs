using AutoMapper;
using RestauranteService.Dtos;
using RestauranteService.Models;

namespace RestauranteService.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<CreateRestauranteDto, Restaurante>();
        CreateMap<Restaurante, ReadRestauranteDto>();
    }
}
