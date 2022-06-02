namespace Storyteller.Domain
{
    public class TaleTag
    {
        public Guid TaleId { get; set; }
        public Guid TagId { get; set; }

        public Tale Tale { get; set; }
        public Tag Tag { get; set; }
    }
}
