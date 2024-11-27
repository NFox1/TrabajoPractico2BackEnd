using ArticulosAPI.Data;
using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorios
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        private readonly ApplicationDbContext _context;

        public RepositorioArticulo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Articulo> ObtenerTodos()
        {
            return _context.Articulos.ToList();
        }

        public Articulo ObtenerPorId(int id)
        {
            var articulo = _context.Articulos.Find(id);
            if (articulo == null)
            {
                throw new KeyNotFoundException($"No se encontró un artículo con el ID {id}");
            }
            return articulo;
        }

        public void Agregar(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            _context.SaveChanges();
        }

        public void Actualizar(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var articulo = ObtenerPorId(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                _context.SaveChanges();
            }
        }
    }
}