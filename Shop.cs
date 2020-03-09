using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.NET
{

    //конкретная реализация IProductNumerable. Хранит элементы, которые надо будет перебирать
    class Shop : IProductNumerable // Класс магазина, реализующий паттерн Singleton и вспомогающий класс для паттера Iterator
    {
        public static Shop LaunchShop(string shopTitle)
        {
            if (instance == null)
                instance = new Shop(shopTitle);
            return instance;
        }
        public string Title { get; set; }
        private static Shop instance;

        public Shop(string shopTitle)
        {
            Title = shopTitle;

            products = new Product[]
            {
                new RAM ("Kingston SODIMM DDR3L", 670),
                new RAM ("HyperX Predator DDR4D", 850),
                new GPU ("Nvidia Geforce 1660TI", 950),
                new GPU ("AMD Radeon RX200 Kyle-4", 800),
                new CPU ("Intel Core i7-6000DL 50", 650),
                new CPU ("Intel Core i9-7000HQ 60", 980)
            };
        }

        private Product[] products;

        public int Count
        {
            get { return products.Length; }
        }
        public Product this[int index]
        {
            get
            {
                if (index > Count || index < 0)
                {
                    throw new IndexException($"Index {index} is out of range!");
                }
                else
                {
                    return products[index];
                }
            }
        }
        public IProductIterator CreateNumerator()
        {
            return new ShopNumerator(this);
        }
    }
    class ShopNumerator : IProductIterator // конкретная реализация итератора для обхода объекта IProductNumerable
    {
        IProductNumerable aggregate;
        int index = 0;
        public ShopNumerator(IProductNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }
        public Product Next()
        {
            return aggregate[index++];
        }
    }
}
