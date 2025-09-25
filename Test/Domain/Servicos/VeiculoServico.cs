using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        // var connectionString = configuration.GetConnectionString("MySql");

        // var options = new DbContextOptionsBuilder<DbContexto>()
        //     .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        //     .Options;

        return new DbContexto(configuration);
    }



    [TestMethod]
    public void TestandoIncluirVeiculo()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos;");
        // Arrange
        var veiculo = new Veiculo();

        veiculo.Nome = "testeVeiculo";
        veiculo.Marca = "teste";
        veiculo.Ano = 2025;

        var veiculoServico = new VeiculoServico(context);

        // Act        
        veiculoServico.Incluir(veiculo);

        //Assert
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());
        Assert.AreEqual("testeVeiculo", veiculo.Nome);
        Assert.AreEqual("teste", veiculo.Marca);
        Assert.AreEqual(2025, veiculo.Ano);        

    }
    
    public void TestandoBuscaPorIdVeiculo()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos;");
        // Arrange
        var veiculo = new Veiculo();

        veiculo.Nome = "testeVeiculo";
        veiculo.Marca = "teste";
        veiculo.Ano = 2025;

        var veiculoServico = new VeiculoServico(context);

        // // Act        
        veiculoServico.Incluir(veiculo);
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        //Assert
        Assert.AreEqual(1, veiculoDoBanco.Id);
            
    }
}
