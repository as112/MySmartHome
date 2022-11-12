using System.ComponentModel.DataAnnotations;

namespace MySmartHomeWebApi.Entities
{
    public class MqttEntity : Entity
    {
        private DateTime dateTimeUpdate;

        [Required]
        public string TopicUp { get; set; }
        public string? TopicDown { get; set; }
        public DateTime DateTimeUpdate { get => dateTimeUpdate; set => dateTimeUpdate = value.ToUniversalTime(); }
    }
}
