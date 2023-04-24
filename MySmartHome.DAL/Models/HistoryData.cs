using MySmartHome.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace MySmartHome.DAL.Models
{
    public class HistoryData : BaseEntity
    {
        private DateTime dateTimeUpdate;

        [Required]
        public DateTime DateTimeUpdate { get => dateTimeUpdate; set => dateTimeUpdate = value.ToUniversalTime(); }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Topic { get; set; }

    }
}
