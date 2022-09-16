namespace Bitbucketwise.Models
{
    public class Page<T>
    {
        public T[] Values { get; set; }
        public int Size { get; set; }
        public bool IsLastPage { get; set; }
        public int NextPageStart { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
    }
}
