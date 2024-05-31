namespace Domain.Entities
{
    public class Organization
    {
        public Organization()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SlugTenant { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
