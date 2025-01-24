using System.Text.Json.Serialization;

namespace _3._6Lesson__homework;

public class Music
{
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("mb")]
    public double MB { get; set; }

    [JsonPropertyName("authorName")]
    public string AuthorName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("quantityLikes")]
    public int QuantityLikes { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, MB: {MB}, AName: {AuthorName}, Des: {Description}, Ql: {QuantityLikes}";
    }
}
