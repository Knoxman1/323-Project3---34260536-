 
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(SuperStoreContext superStoreContext) : base(superStoreContext)
        {
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _superStoreContext.OrderDetails.ToList();
        }

        public OrderDetail GetOrderDetailsById(int Id)
        {
            return _superStoreContext.OrderDetails.FirstOrDefault(x => x.OrderDetailsId == Id);
        }

        public void CreateOrderDetail(OrderDetail orderDetails)
        {
            if (orderDetails == null)
            {
                throw new ArgumentNullException($"{nameof(orderDetails)} cannot be created.");
            }

            _superStoreContext.OrderDetails.Add(orderDetails);
            _superStoreContext.SaveChanges();
        }

        public void UpdateOrderDetails(OrderDetail orderDetails)
        {
            if (orderDetails == null)
            {
                throw new ArgumentNullException($"{nameof(orderDetails)} cannot be updated.");
            }

            _superStoreContext.OrderDetails.Update(orderDetails);
            _superStoreContext.SaveChanges();
        }

        public void DeleteOrderDetails(int Id)
        {
            var OrderDetailsDelete = _superStoreContext.OrderDetails.FirstOrDefault(x => x.OrderDetailsId == Id);
            if (OrderDetailsDelete != null)
            {
                _superStoreContext.OrderDetails.Remove(OrderDetailsDelete);
                _superStoreContext.SaveChanges();
            }
        }

        public bool OrderDetailsExists(int id)
        {
            // Implement logic to check if order details with the specified id exists.
            throw new NotImplementedException();
        }
    }
}

