namespace Storyteller.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Tale> Tales { get; set; }
        public ICollection<Fragment> Fragments { get; set; }
    }
}
