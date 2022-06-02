namespace Storyteller.Domain
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<FragmentReaction> Fragments { get; set; }
    }
}
