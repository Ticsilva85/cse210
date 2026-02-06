using System;
using OnlineOrdering.models;

class Program
{
    static void Main(string[] args)
    {
        {
            // ===== ORDER 1 (BRAZIL) =====
            Address address1 = new Address(
                "Av. Paulista, 1578",
                "São Paulo",
                "SP",
                "Brazil"
            );

            Customer customer1 = new Customer("Carlos Silva", address1);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Notebook", "BR1001", 3.50m, 10));
            order1.AddProduct(new Product("Pen Pack", "BR1002", 7.25m, 4));
            order1.AddProduct(new Product("Highlighter", "BR1003", 2.10m, 6));

            DisplayOrder(order1);

            // ===== ORDER 2 (BRAZIL) =====
            Address address2 = new Address(
                "Rua Boa Viagem, 500",
                "Recife",
                "PE",
                "Brazil"
            );

            Customer customer2 = new Customer("Tiago Cavalcante", address2);

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Planner", "BR2001", 18.90m, 2));
            order2.AddProduct(new Product("Stapler", "BR2002", 12.40m, 1));

            DisplayOrder(order2);
        }

        static void DisplayOrder(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"TOTAL PRICE: ${order.GetTotalPrice():0.00}");
            Console.WriteLine("\n========================================\n");
        }
    }
}