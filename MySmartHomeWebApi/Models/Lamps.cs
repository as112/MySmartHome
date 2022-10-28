using MySmartHomeWebApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySmartHomeWebApi.Models
{
    public class Lamps : MqttEntity
    {
        public bool Status { get; set; }
        public string? RoomName { get; set; }

        public override string ToString() => Name;
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            Lamps? lamp = obj as Lamps;
            if(lamp == null) return false;
            return this.TopicUp == lamp.TopicUp && this.TopicDown == lamp.TopicDown;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TopicUp);
        }
    }
}
