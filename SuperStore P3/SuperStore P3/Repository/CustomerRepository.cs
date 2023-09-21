 
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        protected readonly SuperStoreContext _superStoreContext;

        public CustomerRepository(SuperStoreContext superStoreContext) : base(superStoreContext)
        {
            _superStoreContext = superStoreContext ?? throw new ArgumentNullException(nameof(superStoreContext));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _superStoreContext.Customers.ToList();
        }

        public Customer GetCustomerById(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException($"{nameof(Id)} cannot be null.");
            }

            return _superStoreContext.Customers.FirstOrDefault(x => x.CustomerId == Id);
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException($"{nameof(customer)} cannot be null.");
            }

            _superStoreContext.Customers.Add(customer);
            _superStoreContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException($"{nameof(customer)} cannot be null.");
            }

            _superStoreContext.Customers.Update(customer);
            _superStoreContext.SaveChanges();
        }

        public void DeleteCustomer(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException($"{nameof(Id)} cannot be null.");
            }

            var customerDelete = _superStoreContext.Customers.FirstOrDefault(x => x.CustomerId == Id);
            if (customerDelete != null)
            {
                _superStoreContext.Customers.Remove(customerDelete);
                _superStoreContext.SaveChanges();
            }
        }

        public bool CustomerExists(int id)
        {
            return _superStoreContext.Customers.Any(c => c.CustomerId == id);
        }
    }
}
