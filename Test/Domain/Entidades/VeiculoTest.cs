using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act        
            veiculo.Id = 1;
            veiculo.Nome = "SF90 Stradale";
            veiculo.Marca = "Ferrari";
            veiculo.Ano = 2024;

            //Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("SF90 Stradale", veiculo.Nome);
            Assert.AreEqual("Ferrari", veiculo.Marca);
            Assert.AreEqual(2024, veiculo.Ano);
        }
    }
}