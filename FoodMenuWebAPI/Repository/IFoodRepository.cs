using FoodMenuWebAPI.Model;

namespace FoodMenuWebAPI.Repository
{
    public interface IFoodRepository
    {
        void InsertOrder(Order order);
        List<Order> FetchAllOrdersForCustomer();
        Order FetchSpecificOrderDetails();
        void UpdateOrder(Order order);
        void UpdateFoodQuantityInOrder(int orderId, int quantity);
        void DeleteOrder(int orderId);
            
    }
}
