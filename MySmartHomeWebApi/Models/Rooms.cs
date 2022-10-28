using MySmartHomeWebApi.Entities;

namespace MySmartHomeWebApi.Models
{
    public class Rooms : Entity
    {
        public IEnumerable<Lamps>? Lamps { get; set; }
        public IEnumerable<Sensors>? Sensors { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Rooms room &&
                   Id.Equals(room.Id) &&
                   Name == room.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
