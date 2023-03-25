using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebAPI.Entities
{
    public class Order
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }
        public List<OrderMenu> OrderMenu { get; set; }
        public bool? Deleted { get; set; }

    }
}
