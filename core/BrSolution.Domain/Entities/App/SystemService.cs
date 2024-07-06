namespace BrSolution.Domain.Entities.App
{
    public class SystemService : IEntity
    {
        public int Id { get; set; }

        public string EncryptedName { get; set; }

        public string TypeName { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public ICollection<RoleSystemService> RoleSystemServices { get; set; }

    }
}
