using System.Text.Json.Serialization;

namespace Backend.Models.Responses
{
    public class BaseUserResponse
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
