using Application.Domain.Entidades;
using Application.EFCore.Data;
using Application.EFCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        var departamentoRepository = serviceProvider.GetRequiredService<DepartamentoRepository<AppDbContext>>();

        var querCadastrar = true;

        while (querCadastrar)
        {
            Console.Write("Deseja cadastrar outro departamento? (s/n): ");
            var resposta = Console.ReadLine();
            querCadastrar = resposta?.ToLower() == "s";
            if (!querCadastrar) break;

            var departamento = CadastrarDepartamento();
            departamentoRepository.DbSet.Add(departamento);
            await departamentoRepository.DbContext.SaveChangesAsync();
           
        }
        var departamentos = await departamentoRepository.SelecionarTodos();
        foreach (var dep in departamentos)
        {
            Console.WriteLine($"ID: {dep.ID} - Nome: {dep.Nome}");
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped(typeof(BaseRepository<AppDbContext>));
        services.AddScoped(typeof(DepartamentoRepository<AppDbContext>));
    }

    private static Departamento CadastrarDepartamento()
    {     
            var departamento = new Departamento();
            Console.WriteLine("Cadastro de Departamento");
            Console.Write("Nome: ");
            departamento.Nome = Console.ReadLine() ?? string.Empty;
            Console.Write("Descrição: ");
            departamento.Descricao = Console.ReadLine() ?? string.Empty;
            return departamento;             
    }
}