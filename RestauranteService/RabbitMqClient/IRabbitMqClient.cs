using RestauranteService.Dtos;

namespace RestauranteService.RabbitMqClient;

public interface IRabbitMqClient
{
    void PublicaRestaurante(ReadRestauranteDto readRestauranteDto);
}
