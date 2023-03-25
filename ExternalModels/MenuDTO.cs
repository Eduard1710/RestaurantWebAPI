using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebAPI.ExternalModels
{
    public class MenuDTO
    {
        public Guid ID { get; set; }
        public Guid CategoryID { get; set; }
        public CategoryDTO? Category { get; set; }
        public string MenuName { get; set; }
        public float Price { get; set; }
        //public List<OrderMenuDTO> OrderMenu { get; set; }
    }
}
