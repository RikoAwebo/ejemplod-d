using AutoMapper;
using ApiUsuarios.DTOs;
using ApiUsuarios.Interfaces;
using ApiUsuarios.Models;

namespace ApiUsuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _unitOfWork.Usuarios.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);

            if (usuario == null)
                return null;

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> AddAsync(UsuarioCreateDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            await _unitOfWork.Usuarios.AddAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto)
        {
            if (id != dto.Id)
                return false;

            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);

            if (usuario == null)
                return false;

            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Carnet = dto.Carnet;
            usuario.FechaNacimiento = dto.FechaNacimiento;

            _unitOfWork.Usuarios.Update(usuario);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);

            if (usuario == null)
                return false;

            await _unitOfWork.Usuarios.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}