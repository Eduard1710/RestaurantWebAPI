using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebAPI.Entities
{
    public class Menu
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [MaxLength(100)]
        public string MenuName { get; set; }
        [Required]
        public float Price { get; set; }
        public List<OrderMenu> OrderMenu { get; set; }
        public bool? Deleted { get; set; }

    }
}
