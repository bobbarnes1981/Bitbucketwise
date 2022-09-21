using System.Text.Json.Serialization;

namespace Bitbucketwise.Models
{
    public class Path
    {
        public string[] Components { get; set; }
        public string Parent { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        [JsonPropertyName("toString")]
        public string StringRepresentation { get; set; }
    }
}
