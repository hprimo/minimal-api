using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;

namespace Test.Mocks
{
    public class VeiculoServicoMock : IVeiculoServico
    {
        private static List<Veiculo> veiculos = new List<Veiculo>()
        {
            new Veiculo {
                Id = 1,
                Nome = "Kicks",
                Marca = "Nissan",
                Ano = 2020
            },
            new Veiculo {
                Id = 2,
                Nome = "Nivus",
                Marca = "Volkswagen",
                Ano = 2023
            }
        };

        public void Apagar(Veiculo veiculo)
        {
            var veiculoExistente = BuscaPorId(veiculo.Id);
            
            if (veiculoExistente == null)
            {
                return; 
            }

            veiculos.Remove(veiculoExistente);

        }

        public Veiculo Atualizar(Veiculo veiculo)
        {
            var veiculoExistente = BuscaPorId(veiculo.Id);
            
            if (veiculoExistente == null)
            {
                return null; 
            }

            veiculoExistente.Nome = veiculo.Nome;
            veiculoExistente.Marca = veiculo.Marca;
            veiculoExistente.Ano = veiculo.Ano;

            veiculos.Add(veiculoExistente);
            return veiculo;

        }

        public Veiculo BuscaPorId(int? id)
        {
            return veiculos.Find(a => a.Id == id);
        }

        public Veiculo Incluir(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count() + 1;
            veiculos.Add(veiculo);

            return veiculo;
        }

        public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
        {
            return veiculos;
        }
    }
}