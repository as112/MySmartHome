using System.ComponentModel.DataAnnotations;

namespace MySmartHome.DAL.Entities
{
    public class Entity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
