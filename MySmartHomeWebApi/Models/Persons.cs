
using MySmartHomeWebApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySmartHomeWebApi.Models
{
    public class Persons : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Roles Role { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            var user = obj as Persons;
            return Email == user?.Email && Password == user?.Password;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email, Password);
        }
    }
    public enum Roles
    {
        Administrators,
        Users
    }
}
