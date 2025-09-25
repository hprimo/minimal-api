using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTest
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
    public void TestandoSalvarAdministrador()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");
        // Arrange
        var adm = new Administrador();

        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act        
        administradorServico.Incluir(adm);

        //Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);        

    }
    
    public void TestandoBuscaPorIdAdministrador()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");
        // Arrange
        var adm = new Administrador();

        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // // Act        
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        //Assert
        Assert.AreEqual(1, admDoBanco.Id);
            
    }
}
