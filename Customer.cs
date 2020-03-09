using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.NET
{
    class Customer // использует объект Shop и итератор для его обхода, класс покупателя
    {
        public Card Card { get; set; }
        public double Sum { get; set; } = 0;
        public double? Money { get; set; }
        public Customer(double sum, double money)
        {
            Sum = sum;
            Money = money;
            Card = ChooseCard.SelectCard(Sum);
        }
        public void SeeProducts(Shop shop)//посмотреть все продукты
        {
            int i = 0;
            IProductIterator iterator = shop.CreateNumerator();
            while (iterator.HasNext())
            {
                Product product = iterator.Next();
                Console.WriteLine($"{++i}) {product}");
            }
        }
    }
}
