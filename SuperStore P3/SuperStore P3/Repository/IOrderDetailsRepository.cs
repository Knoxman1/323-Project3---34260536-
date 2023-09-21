
using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetOrderDetailsById(int Id);
        void CreateOrderDetail(OrderDetail orderDetails);
        void UpdateOrderDetails(OrderDetail orderDetails);
        void DeleteOrderDetails(int Id);
        bool OrderDetailsExists(int id);
    }
}

