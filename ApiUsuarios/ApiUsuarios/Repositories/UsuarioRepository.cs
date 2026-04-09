using Microsoft.EntityFrameworkCore;
using ApiUsuarios.Data;
using ApiUsuarios.Interfaces;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MiBaseContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByCarnetAsync(string carnet)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Carnet == carnet && x.Borrado == false);
        }
    }
}