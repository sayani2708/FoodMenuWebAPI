using FoodMenuWebAPI.Model;

namespace FoodMenuWebAPI.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        List<Order> RetriveAllOrdersForCustomer();
        Order RetriveSpecificOrderDetails();
        void ModifyOrder(Order order);
        void ModifyFoodQuantityInOrder(int orderId, int quantity);
        void CancelOrder(int orderId);
    }
}
