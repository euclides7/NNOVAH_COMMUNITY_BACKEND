using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class PermissionGroup : BaseEntity
    {
        public string Description { get; set; }
        public int UserType { get; set; }
        public string Form { get; set; }
        public string FormChild { get; set; }
     
    }
}
