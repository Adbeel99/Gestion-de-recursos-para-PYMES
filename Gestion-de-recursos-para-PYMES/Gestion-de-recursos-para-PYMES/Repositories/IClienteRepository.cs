using System.Collections.Generic;
using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public interface IClienteRepository
    {
        void Crear(Cliente cliente);
        void Editar(Cliente cliente);
        void Eliminar(int id);
        Cliente ObtenerPorId(int id);
        List<Cliente> ObtenerTodos();
    }
}
