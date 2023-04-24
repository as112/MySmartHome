using System.ComponentModel.DataAnnotations;

namespace MySmartHome.DAL.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
