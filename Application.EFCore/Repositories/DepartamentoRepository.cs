using Application.Domain.Entidades;
using Application.EFCore.Data;
namespace Application.EFCore.Repositories
{
    public class DepartamentoRepository<T> : BaseRepository<Departamento> where T : AppDbContext   
    {
        public DepartamentoRepository(T dbContext) : base(dbContext)
        {
        }
    }
}
