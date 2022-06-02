namespace Storyteller.Domain
{
    public class Tale
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Language { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<TaleTag> Tags { get; set; }
        public User Creator { get; set; }
        public ICollection<Fragment> Fragments { get; set; }
        
    }
}
