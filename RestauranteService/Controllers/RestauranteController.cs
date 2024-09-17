using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteService.Data;
using RestauranteService.Dtos;
using RestauranteService.ItemServiceHttpClient;
using RestauranteService.Models;
using RestauranteService.RabbitMqClient;

namespace RestauranteService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRestauranteRepository _repository;
    private readonly IItemServiceHttpClient _itemServiceHttpClient;
    private readonly IRabbitMqClient _rabbitMqClient;

    public RestauranteController(IMapper mapper, IRestauranteRepository repository, IItemServiceHttpClient itemServiceHttpClient, IRabbitMqClient rabbitMqClient)
    {
        _mapper = mapper;
        _repository = repository;
        _itemServiceHttpClient = itemServiceHttpClient;
        _rabbitMqClient = rabbitMqClient;
    }

    [HttpPost]
    public ActionResult<CreateRestauranteDto> CadastraRestaurante([FromBody] CreateRestauranteDto createRestauranteDto)
    {
        var restaurante = _mapper.Map<Restaurante>(createRestauranteDto);
        _repository.CadastraRestaurante(restaurante);
        _repository.SaveChanges();

        var readRestauranteDto = _mapper.Map<ReadRestauranteDto>(restaurante);

        //_itemServiceHttpClient.EnviaRestauranteParaItemService(readRestauranteDto);

        _rabbitMqClient.PublicaRestaurante(readRestauranteDto);

        return CreatedAtRoute(nameof(RetornaRestaurantePorId), new { restaurante.Id }, restaurante);

    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadRestauranteDto>> RetornaTodosOsRestaurantes()
    {
        var restaurantes = _repository.RetornaRestaurantes();
        return Ok(_mapper.Map<IEnumerable<ReadRestauranteDto>>(restaurantes));
    }

    [HttpGet("{id}", Name = "RetornaRestaurantePorId")]
    public ActionResult<ReadRestauranteDto> RetornaRestaurantePorId(int id)
    {
        var restaurante = _repository.RetornaRestaurantePorId(id);
        
        if(restaurante != null)
        {
            return Ok(_mapper.Map<ReadRestauranteDto>(restaurante));
        }
        
        return NotFound();
    }
}
