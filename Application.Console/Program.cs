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

        Menu:
        var opcaoMenu = string.Empty;
        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Cadastrar Departamento");
        Console.WriteLine("2 - Listar todos departamentos");
        Console.Write("Escolha uma opção: ");
        opcaoMenu = Console.ReadLine() ?? string.Empty;
        switch (opcaoMenu)
        {
            case "1":
                await CadastrarDepartamento(departamentoRepository);
                Console.Clear();
                goto Menu;
            case "2":
                await ListarTodosDepartamentos(departamentoRepository);              
                goto Menu;
            default:
                Console.WriteLine("Opção inválida.");
                Console.Clear(); 
                goto Menu;
        }
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped(typeof(BaseRepository<AppDbContext>));
        services.AddScoped(typeof(DepartamentoRepository<AppDbContext>));
    }

    private static async Task CadastrarDepartamento(DepartamentoRepository<AppDbContext> departamentoRepository)
    {
        var querCadastrarDepartamento = true;

        while (querCadastrarDepartamento)
        {
            Console.Write("Deseja cadastrar departamento? (s/n): ");
            var resposta = Console.ReadLine();
            querCadastrarDepartamento = resposta?.ToLower() == "s";
            if (!querCadastrarDepartamento) break;

            var departamento = new Departamento();
            Console.WriteLine("Cadastro de Departamento");
            Console.Write("Nome: ");
            departamento.Nome = Console.ReadLine() ?? string.Empty;
            Console.Write("Descrição: ");
            departamento.Descricao = Console.ReadLine() ?? string.Empty;
            departamento.DataCricao = DateTime.Now;
            departamentoRepository.DbSet.Add(departamento);
        }
        await departamentoRepository.DbContext.SaveChangesAsync();
    }

    private static async Task ListarTodosDepartamentos(DepartamentoRepository<AppDbContext> departamentoRepository)
    {
        var departamentos = await departamentoRepository.SelecionarTodos();
        foreach (var dep in departamentos)
        {
            Console.WriteLine($"ID: {dep.ID} - Nome: {dep.Nome} - Descrição: {dep.Descricao}");
        }
    }
}