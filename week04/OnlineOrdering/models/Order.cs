using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.models
{
    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;
        
        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal GetTotalPrice()
        {
            decimal productsTotal = 0m;
            foreach (Product p in _products)
            {
                productsTotal += p.GetTotalCost();
            }

            decimal shippingCost = _customer.LivesInBrazil() ? 5m : 35m;
            return productsTotal + shippingCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PACKING LABEL");
            sb.AppendLine("--------------------");

            foreach (Product p in _products)
            {
                sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
            }

            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SHIPPING LABEL");
            sb.AppendLine("--------------------");
            sb.AppendLine(_customer.GetName());
            sb.AppendLine(_customer.GetShippingAddress());

            return sb.ToString();
        }
    }
}