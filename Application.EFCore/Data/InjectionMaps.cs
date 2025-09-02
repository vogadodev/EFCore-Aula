using Application.Domain.Maps;
using Microsoft.EntityFrameworkCore;

namespace Application.EFCore.Data
{
    public static class InjectionMaps
    {
        public static void AddEntidadeMaps(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartamentoMap());
        }
        public static void AddDTOsMaps(ModelBuilder builder)
        {
            // Adicione aqui as configurações de mapeamento
        }
    }
}
