namespace Application.Domain.Entidades
{
    public class Departamento
    {
        public Guid ID { get; set; }
        public string Nome { get; set; } = string.Empty!;
        public string Descricao { get; set; } = string.Empty!;
    }
}
