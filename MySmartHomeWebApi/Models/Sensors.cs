using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySmartHomeWebApi.Models
{
    [Index(nameof(DateTimeUpdate))]
    [Index(nameof(Name))]
    public class Sensors : MqttEntity
    {
        public string? Value { get; set; }
        public string? RoomName { get; set; }

        public override string ToString() => Name;
        public override bool Equals(object? obj)
        {
            return obj is Sensors sensor &&
                   Id.Equals(sensor.Id) &&
                   TopicUp == sensor.TopicUp;
        }

        public override int GetHashCode() => HashCode.Combine(Id, TopicUp);

    }
}
