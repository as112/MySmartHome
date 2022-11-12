using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace MySmartHomeWebApi.Models
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
