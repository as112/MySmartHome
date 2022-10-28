using System.ComponentModel.DataAnnotations;

namespace MySmartHomeWebApi.Entities
{
    public class MqttEntity : Entity
    {
        [Required]
        public string TopicUp { get; set; }
        public string? TopicDown { get; set; }
        public DateTime DateTimeUpdate { get; set; }
    }
}
