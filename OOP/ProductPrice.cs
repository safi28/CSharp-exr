using System;

namespace ProductPrice
{
    class Product
    {
        string barcode;
        string productName;
        string group;
        string unit;
        decimal deliveryPrice;

        public Product(string barcode, string productName, string group, string unit, decimal deliveryPrice)
        {
            this.barcode = barcode;
            this.productName = productName;
            this.group = group;
            this.unit = unit;
            this.deliveryPrice = deliveryPrice;
        }

        public string barcode
        {
            get { return this.barcode; }
            set { this.barcode = value; }
        }

        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }

        public string Group
        {
            get { return this.group; }
            set { this.group = value; }
        }

        public string Unit
        {
            get { return this.unit; }
            set { this.unit = value; }
        }

        public decimal DeliveryPrice
        {
            get { return this.deliveryPrice; }
            set { this.deliveryPrice = value; }
        }

        public void PrintProduct(string label)
        {
            Console.WriteLine("{0}", label);
            Console.WriteLine($"Barcode of the product: {this.barcode}");
            Console.WriteLine($"Name of the product: {this.productName}");
            Console.WriteLine($"Group of the product: {this.group}");
            Console.WriteLine($"Unit: {this.unit}");
            Console.WriteLine($"Delivery price: {this.deliveryPrice}");

        }

        public decimal FinalPrice(decimal deliveryPrice = 0)
        {
            if(deliveryPrice == 0)
                deliveryPrice = DeliveryPrice;
                return deliveryPrice * 1.2M;            
        }

        class Program
        {
            static void Main(string[] args)
            {
                Product cake = new Product("01010", "Cake", "Sugar", "kg", 3.5M);
                Product hotdog = new Product("02020", "HotDog", "Meat", "kg", 1.5M);

                cake.PrintProduct("Product 1____");
                hotdog.PrintProduct("Product 2___");
                string productGroup = Console.ReadLine();
                Console.WriteLine("Select a group:");
                int kg = 0;

                if(cake.Group == productGroup)
                {
                    Console.WriteLine($"Price: ${cake.DeliveryPrice}lv., price with DDS :" + $"{cake.FinalPrice()} lv.");
                    kg++;
                }

                if (hotdog.Group == productGroup)
                {
                    Console.WriteLine($"Price: ${hotdog.DeliveryPrice}lv., price with DDS :" + $"{hotdog.FinalPrice()} lv.");
                    kg++;
                }

                Console.WriteLine($"${kg} products, which are in group {productGroup}");
            }
        }



    }
}
