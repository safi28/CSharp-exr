using System;
using System.Collections.Generic;
using System.Linq;

namespace PP
{
  
    class Program
    {

        static void Main(string[] args)
        {

            string[] data = Console.ReadLine().Split(", ").ToArray();
            List<string> list = new List<string>();
            List<int> tables = new List<int>();
            List<string> order = new List<string>();
            double totalPrice = 0;
            int counter = 0;
            int tableCounter = 0;

            double priceSalad = 0;
            int countSalad = 0;
            double totalPriceSalad = 0;
            double priceSoup = 0;
            int countSoup = 0;
            double totalPriceSoup = 0;
            double priceDessert = 0;
            int countDessert = 0;
            double totalPriceDessert = 0;
            double priceDrink = 0;
            double totalPriceDrink = 0;
            int countDrink = 0;
            double priceMeal= 0;
            int countMeal = 0;
            double totalPriceMeal = 0;

            while (data[0] != "Sale!")
            {
                data = Console.ReadLine().Split(", ").ToArray();
                var category = data[0];

                if (category == "Exit")
                {
                    break;
                }
                if (category == "Sale!")
                {
                    Console.WriteLine($"Total tables for the day: {tableCounter}\nTotal sales: {list.Count} - {totalPrice}\nIn categories:" +
                        $"\n - Salad: {countSalad} - {priceSalad}\n - Soup: {countSoup} - {priceSoup}" +
                        $"\n - Dessert: {countDessert} - {priceDessert}\n - Drinks: {countDrink} - {priceDrink}");
                    break;
                }


                if (category != "Salad" && category != "Soup" && category != "Dessert" && category != "Drink")
                {
                    int table = int.Parse(data[0]);
                     
                    if(tables.IndexOf(table) != -1)
                    {
                        tableCounter++;
                        tables.Add(table);
                    }
                    string name = data[1];
                    string item = data[2];
                    string meal = data[3];
                    order.Add(name);
                    order.Add(item);
                    order.Add(meal);

                    if (list.Contains(name) || list.Contains(item) || list.Contains(meal))
                    {
                        

                    } else
                    {
                        Console.WriteLine($"We don't have this meal!\nWe have {list[0]}, {list[1]}, {list[2]}");
                    }
                    if(name == "Salad" || item == "Salad" || meal == "Salad")
                    {
                        totalPriceSalad += priceSalad;
                        totalPrice += totalPriceSalad;
                        countSalad++;
                    } else if(order.Contains("Soup"))
                    {
                        totalPriceSoup += priceSoup;
                        totalPrice += totalPriceSoup;
                        countSoup++;
                    }
                    else if (order.Contains("Dessert"))
                    {
                        totalPriceDessert += priceDessert;
                        totalPrice += totalPriceDessert;
                        countDessert++;
                    }
                    else if (order.Contains("Drink"))
                    {
                        totalPriceDrink += priceDrink;
                        totalPrice += totalPriceDrink;
                        countDrink++;
                    }
                    else if (order.Contains("Meal"))
                    {
                        totalPriceMeal += priceMeal;
                        totalPrice += totalPriceMeal;
                        countMeal++;
                    }

                }
                else
                {
                    string name = data[1];
                    double quantity = int.Parse(data[2]);
                    double price = int.Parse(data[3]);


                    if (price <= 0 || price > 100)
                    {
                        throw new ArgumentException("Price is invalid!");
                    }
                    if (quantity <= 0 || quantity > 1000)
                    {
                        throw new ArgumentException("Quantity is invalid!");
                    }

                    if (category == "Meal")
                    {
                        quantity *= 1;
                        priceMeal = price;
                       
                    }
                    else if (category == "Dessert")
                    {
                        quantity *= 3;
                        priceDessert = price;
                    }
                    else if (category == "Drink")
                    {
                        quantity *= 1.5;
                        priceDrink = price;
                    } else if (category == "Soup")
                    {
                        priceSoup = price;
                    } else if(category == "Salad")
                    {
                        priceSalad = price;
                    }
                    for (int i = 0; i < data.Length; i++)
                    {
                        list.Add(data[i]);
                    }
                }
             
            }
    }
    }
}