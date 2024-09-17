using AutoMapper;
using ItemService.Dtos;
using ItemService.Models;

namespace ItemService.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<ItemCreateDto, Item>();
        CreateMap<Item, ItemReadDto>();
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<RestauranteReadDto, Restaurante>()
            .ForMember(dest => dest.IdExterno, opt => opt.MapFrom(src => src.Id));

    }
}
