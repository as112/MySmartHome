using System.ComponentModel.DataAnnotations;

namespace MySmartHomeWebApi.Entities
{
    public class Entity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
