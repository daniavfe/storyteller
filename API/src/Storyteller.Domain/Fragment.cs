namespace Storyteller.Domain
{
    public class Fragment
    {
        public Guid Id { get; set; }
        public Guid TaleId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ParentFragmentId { get; set; }
        public string Content { get; set; }
        public ICollection<Fragment> Fragments { get; set; }
        public ICollection<FragmentReaction> Reactions { get; set; }
        public Fragment ParentFragment { get; set; }
        public Tale Tale { get; set; }
        public User Creator { get; set; }
    }
}
