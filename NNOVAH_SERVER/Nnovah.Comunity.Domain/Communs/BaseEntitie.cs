namespace Nnovah.Comunity.Domain.Communs
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public int State { get; set; }
        public int User { get; set; }

    }
}
