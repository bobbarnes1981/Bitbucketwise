namespace Bitbucketwise.Models
{
    public class RemoteFile
    {
        public int Start { get; set; }
        public int Size { get; set; }
        public bool IsLastPage { get; set; }
        public TextLine[] Lines { get; set; }
    }
    public class TextLine
    {
        public string Text { get; set; }
    }
}
