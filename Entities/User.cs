using System.ComponentModel.DataAnnotations;

namespace RestaurantWebAPI.Entities
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(150)]
        public string FirstName { get; set; }

        [MaxLength(150)]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Password { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool? Deleted { get; set; }
    }
}
