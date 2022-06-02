namespace Storyteller.Domain
{
    public class FragmentReaction
    {
        public Guid FragmentId { get; set; }
        public Guid ReactionId { get; set; }

        public Fragment Fragment { get; set; }
        public Reaction Reaction { get; set; }
    }
}
