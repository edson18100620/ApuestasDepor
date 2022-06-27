namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Partido = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Partido> Partido { get; set; }
    }
}
