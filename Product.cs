using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab1.NET
{
    interface IProductIterator // определяет интерфейс для обхода составных объектов
    {
        bool HasNext();
        Product Next();
    }

    interface IProductNumerable // определяет интерфейс для создания объекта-итератора
    {
        IProductIterator CreateNumerator();
        int Count { get; }
        Product this[int index] { get; }
    }

    abstract class Product // абстрактный класс детали пк
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public Product(string model, double price)
        {
            Model = model;
            Price = price;
        }
        public override string ToString()//перегрузка метода ТоСтринг, для более удобного вывода информации
        {
            return $"Type: {GetType().Name};\t\tModel: {Model};\t\tPrice: {Price}$";
        }
    }

    class RAM : Product // Класс Оперативной памяти
    {
        public RAM(string model, double price)
            : base(model, price) { }
    }

    class GPU : Product // Класс видеокарты
    {
        public GPU(string model, double price)
            : base(model, price) { }
    }

    class CPU : Product // класс процесора
    {
        public CPU(string model, double price)
            : base(model, price) { }
    }
}
