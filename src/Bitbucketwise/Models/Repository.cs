namespace Bitbucketwise.Models
{
    public class Repository
    {
        public Project Project { get; set; }
        public string Description { get; set; }
        public Origin Origin { get; set; }
        public string HierarchyId { get; set; }
        public string StatusMessage { get; set; }
        public bool Archived { get; set; }
        public bool Forkable { get; set; }
        public int Partition { get; set; }
        public Dictionary<string, Link[]> Links { get; set; }
        public string DefaultBranch { get; set; }
        public string Slug { get; set; }
        public string ScmId { get; set; }
        public string Scope { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string State { get; set; }
        public bool Public { get; set; }
    }
}
