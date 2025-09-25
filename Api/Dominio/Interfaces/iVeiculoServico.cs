using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Dominio.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null);
        Veiculo? BuscaPorId(int? id);
        Veiculo Incluir(Veiculo veiculo);
        Veiculo? Atualizar(Veiculo veiculo);
        void Apagar(Veiculo veiculo);
    }
}