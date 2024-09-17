using RestauranteService.Models;

namespace RestauranteService.Data;

public class RestauranteRepository : IRestauranteRepository
{
    private readonly AppDbContext _context;

    public RestauranteRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CadastraRestaurante(Restaurante restaurante)
    {
        if(restaurante == null)
        {
            throw new ArgumentNullException(nameof(restaurante));
        }

        _context.Restaurantes.Add(restaurante);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public IEnumerable<Restaurante> RetornaRestaurantes() => _context.Restaurantes.ToList();

    public Restaurante RetornaRestaurantePorId(int id) => _context.Restaurantes.FirstOrDefault(r => r.Id == id);
}
