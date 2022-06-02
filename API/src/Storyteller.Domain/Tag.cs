namespace Storyteller.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaleTag> Tales { get; set; }
    }
}
