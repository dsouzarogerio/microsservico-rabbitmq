using ItemService.Models;

namespace ItemService.Data;

internal class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateItem(int restauranteId, Item item)
    {
        item.IdRestaurante = restauranteId;
        _context.Itens.Add(item);
    }

    public void CreateRestaurante(Restaurante restaurante)
    {
        _context.Restaurantes.Add(restaurante);
    }

    public bool ExisteRestauranteExterno(int restauranteIdExterno)
    {
        return _context.Restaurantes.Any(r => r.IdExterno == restauranteIdExterno);
    }

    public IEnumerable<Restaurante> GetAllRestaurantes()
    {
        return _context.Restaurantes.ToList();
    }

    public Item GetItem(int restauranteId, int id)
    {
        return _context.Itens
                        .Where(item => item.IdRestaurante == restauranteId && item.Id == id)
                        .FirstOrDefault();
    }

    public IEnumerable<Item> GetItensDeRestaurante(int restauranteId)
    {
        return _context.Itens.Where(item => item.IdRestaurante == restauranteId);
    }

    public bool RestauranteExiste(int restauranteId)
    {
        return _context.Restaurantes.Any(restaurante => restaurante.Id == restauranteId);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}