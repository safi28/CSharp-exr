using System;

public class Product
{

    string barcode;
    string productName;
    string group;
    string unit;
    string deliveryPrice;

    public Product()
    {
        Console.Write("Barcode: ");
        setProperty(ref barcode);
        Console.Write("Product: ");
        setProperty(ref productName);
        Console.Write("Group: ");
        setProperty(ref group);
        Console.Write("Unit: ");
        setProperty(ref unit);
        Console.Write("Delivery Price: ");
        setProperty(ref deliveryPrice);
    }

    private void setProperty(ref string read)
    {
        read = Console.ReadLine();
    }

    public string Group
    {
        get { return this.group; }
    }

    public static string Food(string group)
    {
        string type;
        if(group == "fruit" || group == "vegetable")
        {
            type = "Healthy food!";
        } else
        {
            type = "Unhealthy food!";
        }
        return type;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Select n products: ");
        int n = int.Parse(Console.ReadLine());
        Product[] product = new Product[n];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Select information about a product {i+1}");

            Product p = new Product();
            product[i] = p;
        }
        print("Please add search group");
        for(int i = 0; i < n; i++)
        {
            Console.Write(product[i].Group + ", ");
        }
        string group = Console.ReadLine();
        int count = 0;

        for(int i = 0; i < n; i++)
        {
            if(product[i].Group == group)
            {
                count++;
            }
        }
        print($"\n{count} products, from {group} are {Product.Food(group)}");
    }
    static void print(Object read)
    {
        Console.WriteLine(read);
    }
}
