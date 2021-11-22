// * Init-only setters
// Previously, instantiating objects with immutable data had to be done in the constructor by passing values as parameters.
// Now, it has been simplified to use the syntax init.
// It initailizes the immutable data during object creation which allows developers to create immutable properties.

// Usual Format:
class Customers
{
    public int CustomerId { get; }
    public string CustomerName { get; set; }

    public Customers(int customerId)
    {
        CustomerId = customerId;
    }

    static void Main(string[] args)
    {
        var customers = new Customers(1045)
        {
            CustomerName = "Tyson"
        };

        //customerid cannot be set as the property is immutable.
        //customers.CustomerId = 1099;
    }
}

// Using init-only setters:
class CustomersInit
{
    public int CustomerId { get; init; }
    public string CustomerName { get; set; }

    static void Main(string[] args)
    {
        var customers = new CustomersInit()
        {
            CustomerId = 1045,
            CustomerName = "Tyson"
        };

        //customerid cannot be set as the property is immutable.
        //customers.CustomerId = 1099;
    }
}

// * Records
// Records allow us to handle an object like a value rather than a collection of properties.
// As the records mostly deal with immutable state, they are flexible and also best used for data, rather than functionalities.

// The following is with expression to create a new record that inherits values from another record.

// Usual format:
class SalesOrder
{
    public int OrderId { get; init; }
    public string ProductName { get; init; }
    public int Quantity { get; init; }

    static void Main(string[] args)
    {
        SalesOrder order = new SalesOrder { OrderId = 1, ProductName = "Mobile", Quantity = 2 };

        //now we need to change "ProductName"
        SalesOrder newOrder = new SalesOrder { OrderId = order.OrderId, ProductName = "Laptop", Quantity = order.Quantity };
    }
}

// Using records:
public record SalesOrderRecord
{
    public int OrderId { get; init; }
    public string ProductName { get; init; }
    public int Quantity { get; init; }

    static void Main(string[] args)
    {
        SalesOrderRecord order = new() { OrderId = 1, ProductName = "Mobile", Quantity = 2 };

        //using with expression
        SalesOrderRecord newOrder = order with { ProductName = "Laptop" };
    }
}

// * Top-level statements
// This feature helps software developers exclude unwanted code from a program.
// Top-level statements can replace all the boilerplate code (repeating code) with a single line.

// Usual format:
//using System;
//namespace CSharp9
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Welcome to Syncfusion!");
//        }
//    }
//}

// Using top-level statements: (basically this file uses the top-level statement feature)
//using System;
//Console.WriteLine("Welcome to Syncfusion!");

// * Pattern matching
// If you’re a regular user of C#, you might know that pattern matching is one of the features introduced in C# 7.0.
// It helps us extract information from a value.
// C# 9.0 contains many new patterns, but here relational and logical patterns are shown.

// Relational patterns: These patterns work with relational operators such as <, <=, >, and >=.

// Logical patterns: These patterns work with logical operators like and, or, and not.
public class SalesOrderSecond
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int TotalCost { get; set; }

    public double GetTotalCost() => TotalCost switch
    {
        500 or 600 => 10,
        < 1000 => 10 * 1.5,
        <= 10000 => 10 * 3,
        _ => 10 * 5
    };
}

class CSharpFeatures
{
    static void Main(string[] args)
    {
        SalesOrderSecond newOrderforCustomer1 = new() { OrderId = 1, ProductName = "Camera", Quantity = 1, TotalCost = 5000 };
        newOrderforCustomer1.GetTotalCost();
        SalesOrderSecond newOrderforCustomer2 = new() { OrderId = 2, ProductName = "Pen", Quantity = 1, TotalCost = 500 };
        newOrderforCustomer2.GetTotalCost();
    }
}

// ** Conclusion
// With these features, C# 9.0 helps programmers easily work with data (records),
// shape code (pattern matching), and reduce code (top-level statements).
// If you want to know more about the new features in the C# 9.0 official release, please read https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#.