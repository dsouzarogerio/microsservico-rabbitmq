using ItemService.Models;

namespace ItemService.Data;

public interface IItemRepository
{
    void SaveChanges();

    void CreateItem(int restauranteId, Item item);
    Item GetItem(int restauranteId, int id);
    IEnumerable<Item> GetItensDeRestaurante(int restauranteId);

    void CreateRestaurante(Restaurante restaurante);
    IEnumerable<Restaurante> GetAllRestaurantes();
    bool RestauranteExiste(int restauranteId);
    bool ExisteRestauranteExterno(int restauranteIdExterno);

}
