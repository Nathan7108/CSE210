using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName() => name;
    public string GetProductId() => productId;
    public decimal GetPrice() => price;
    public int GetQuantity() => quantity;

    public decimal GetTotalCost()
    {
        return price * quantity;
    }
}

public class Address
{
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName() => name;
    public Address GetAddress() => address;

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Product product1 = new Product("Laptop", "P1001", 999.99m, 1);
        Product product2 = new Product("Mouse", "P1002", 19.99m, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        Address address2 = new Address("456 Maple Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        Product product3 = new Product("Keyboard", "P2001", 49.99m, 1);
        Product product4 = new Product("Monitor", "P2002", 149.99m, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("\n" + order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}