using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Crear(Cliente cliente)
        {
            _clienteRepository.Crear(cliente);
        }

        public void Editar(Cliente cliente)
        {
            _clienteRepository.Editar(cliente);
        }

        public void Eliminar(int id)
        {
            _clienteRepository.Eliminar(id);
        }

        public Cliente ObtenerPorId(int id)
        {
            return _clienteRepository.ObtenerPorId(id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.ObtenerTodos();
        }
    }
}
