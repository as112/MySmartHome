using System.ComponentModel.DataAnnotations;

namespace MySmartHomeWebApi.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
