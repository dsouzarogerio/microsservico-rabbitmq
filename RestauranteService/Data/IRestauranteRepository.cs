using RestauranteService.Models;

namespace RestauranteService.Data;

public interface IRestauranteRepository
{
    void SaveChanges();

    void CadastraRestaurante(Restaurante restaurante);
    IEnumerable<Restaurante> RetornaRestaurantes();
    Restaurante RetornaRestaurantePorId(int id);
}
