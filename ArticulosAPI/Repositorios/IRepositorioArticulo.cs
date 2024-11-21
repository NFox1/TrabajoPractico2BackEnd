using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorios
{
    public interface IRepositorioArticulo
    {
        IEnumerable<Articulo> ObtenerTodos();
        Articulo ObtenerPorId(int id);
        void Agregar(Articulo articulo);
        void Actualizar(Articulo articulo);
        void Eliminar(int id);
    }
}
