using ArticulosAPI.Dto;

namespace ArticulosAPI.Repositorio
{
    public interface IRepositorio
    {
        Task<List<ArticuloDto>> GetArticulos();
        Task<ArticuloDto> GetArticuloById(int id);
        Task<ArticuloDto> CrearOActualizar(ArticuloDto articulo, int id = 0);
        Task<bool> EliminarArticulo(int id);
    }
}
