namespace RestaurantWebAPI.ExternalModels
{
    public class OrderMenuDTO
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid MenuID { get; set; }
        public OrderDTO? Order { get; set; }
        public MenuDTO? Menu { get; set; }
    }
}
