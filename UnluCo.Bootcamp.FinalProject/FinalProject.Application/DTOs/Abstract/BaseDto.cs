

using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public abstract class BaseDto
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("isactive")]
        public bool IsActive { get; set; } = true;

    }
}
