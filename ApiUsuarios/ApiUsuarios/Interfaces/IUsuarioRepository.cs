using ApiUsuarios.Models;

namespace ApiUsuarios.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByCarnetAsync(string carnet);
    }
}