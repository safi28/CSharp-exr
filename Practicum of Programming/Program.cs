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

            double totalPrice = 0;
            int tableCounter = 0;
            int countOrders = 0;

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
                    Console.WriteLine($"Total tables for the day: {tableCounter}\nTotal sales: {countOrders} - {Math.Round(totalPrice, 2)}lv.\nIn categories:" +
                        $"\n - Salad: {countSalad} - {totalPriceSalad}lv.\n - Soup: {countSoup} - {totalPriceSoup}lv." +
                        $"\n - Dessert: {countDessert} - {totalPriceDessert}lv.\n - Drinks: {countDrink} - {totalPriceDrink}lv.\n - Main meals: {countMeal} - {totalPriceMeal}");
                    break;
                }
                if (category == "Sale!")
                {
                    Console.WriteLine($"Total tables for the day: {tableCounter}\nTotal sales: {countOrders} - {totalPrice}lv.\nIn categories:" +
                        $"\n - Salad: {countSalad} - {totalPriceSalad}lv.\n - Soup: {countSoup} - {totalPriceSoup}lv." +
                        $"\n - Dessert: {countDessert} - {totalPriceDessert}lv.\n - Drinks: {countDrink} - {totalPriceDrink}lv.\n - Main meals: {countMeal} - {totalPriceMeal}");
                    break;
                }


                if (category != "Salad" && category != "Soup" && category != "Dessert" && category != "Drink" && category != "Meal")
                {
                    int table = int.Parse(data[0]);
                     
                    if(tables.IndexOf(table) == -1)
                    {
                        tableCounter++;
                        tables.Add(table);
                    }
                    string name = data[1];
                    string item = data[2];
                    string meal = data[3];
                 
                    if((name == "Salad" || item == "Salad" || meal == "Salad") && list.Contains("Salad"))
                    {
                        totalPriceSalad += priceSalad;
                        totalPrice += totalPriceSalad;
                        countSalad++;
                        countOrders++;
                    }
                    if ((name == "Soup" || item == "Soup" || meal == "Soup") && list.Contains("Soup"))
                    {
                        totalPriceSoup += priceSoup;
                        totalPrice += totalPriceSoup;
                        countSoup++;
                        countOrders++;
                    }

                    if ((name == "Dessert" || item == "Dessert" || meal == "Dessert") && list.Contains("Dessert"))
                    {
                        totalPriceDessert += priceDessert;
                        totalPrice += totalPriceDessert;
                        countDessert++;
                        countOrders++;
                    }

                    if ((name == "Drink" || item == "Drink" || meal == "Drink") && list.Contains("Drink"))
                    {
                        totalPriceDrink += priceDrink;
                        totalPrice += totalPriceDrink;
                        countDrink++;
                        countOrders++;
                    }

                    if ((name == "Meal" || item == "Meal" || meal == "Meal") && list.Contains("Meal"))
                    {
                        totalPriceMeal += priceMeal;
                        totalPrice += totalPriceMeal;
                        countMeal++;
                        countOrders++;
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

                    if (category == "Dessert")
                    {
                        quantity *= 3;
                        priceDessert += price;
                    }
                     if (category == "Drink")
                    {
                        quantity *= 1.5;
                        priceDrink += price;
                    }
                    if (category == "Soup")
                    {
                        priceSoup = price;
                    }
                    if (category == "Salad")
                    {
                        priceSalad += price;
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