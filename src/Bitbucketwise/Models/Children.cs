namespace Bitbucketwise.Models
{
    public class Children
    {
        public int Size { get; set; }
        public int Limit { get; set; }
        public bool IsLastPage { get; set; }
        public PathInfo[] Values { get; set; }
        public int Start { get; set; }
    }
}
