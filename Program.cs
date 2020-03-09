using System;
using System.Collections.Generic;

namespace lab1.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = Shop.LaunchShop("Computer Shop!");
            //Shop shop1 = Shop.LaunchShop("sassssssssss");

            Console.WriteLine($"Welcome to {shop.Title}");
            //Console.WriteLine($"Welcome to {shop1.Title}");

            Customer customer = new Customer(4000, 100000);

            while (true)
            {
                customer.SeeProducts(shop);
                Console.Write("Enter item to buy: ");
                int key = Convert.ToInt32(Console.ReadLine());
                customer.Money -= shop[key - 1].Price * (1 - (customer.Card?.Discount ?? 0));
                customer.Sum += shop[key - 1].Price;
                
                Console.WriteLine($"You spend: {shop[key - 1].Price * (1 - (customer.Card?.Discount ?? 0))}$");
                Console.WriteLine($"Your balance: {customer.Money}$");
                Console.WriteLine($"Total purchase amount: {customer.Sum}$");
                //customer.SelectCard(customer.Sum);
                customer.Card = ChooseCard.SelectCard(customer.Sum);

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
