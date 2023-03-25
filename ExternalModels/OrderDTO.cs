namespace RestaurantWebAPI.ExternalModels
{
    public class OrderDTO
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public virtual UserDTO? User { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<OrderMenuDTO> OrderMenu { get; set; }
    }
}
