using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorios
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        private readonly List<Articulo> _articulos;

        public RepositorioArticulo()
        {
            _articulos = new List<Articulo>();
        }

        public IEnumerable<Articulo> ObtenerTodos()
        {
            return _articulos;
        }

        public Articulo ObtenerPorId(int id)
        {
            var articulo = _articulos.FirstOrDefault(a => a.Id == id);
            if (articulo == null)
            {
                throw new KeyNotFoundException($"No se encontró un artículo con el ID {id}");
            }
            return articulo;
        }

        public void Agregar(Articulo articulo)
        {
            _articulos.Add(articulo);
        }

        public void Actualizar(Articulo articulo)
        {
            var articuloExistente = ObtenerPorId(articulo.Id);
            if (articuloExistente != null)
            {
                articuloExistente.Descripcion = articulo.Descripcion;
                articuloExistente.Marca = articulo.Marca;
                articuloExistente.Cantidad = articulo.Cantidad;
            }
        }

        public void Eliminar(int id)
        {
            var articulo = ObtenerPorId(id);
            if (articulo != null)
            {
                _articulos.Remove(articulo);
            }
        }
    }
}
