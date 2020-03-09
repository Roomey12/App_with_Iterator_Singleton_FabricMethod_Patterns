using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.NET
{
    //abstract class Card // абстрактный класс для карт
    //{
    //    public virtual double Discount { get; }
    //    public Card()
    //    {
    //        Console.WriteLine($"You have a {GetType().Name}!");
    //        Console.WriteLine($"Your discount is: {Discount}");
    //    }
    //}

    //class TubeCard : Card // класс простой карты
    //{
    //    public override double Discount { get; } = 0.05;
    //}

    //class TransistorCard : Card // класс средней карты
    //{
    //    public override double Discount { get; } = 0.1;
    //}

    //class IntegratedCard : Card //класс хорошей карты
    //{
    //    public override double Discount { get; } = 0.15;
    //}

    abstract class Developer
    {
        abstract public Card Create();
    }

    class TubeCardDeveloper : Developer
    {
        public override Card Create()
        {
            return new TubeCard();
        }
    }

    class TransistorCardDeveloper : Developer
    {
        public override Card Create()
        {
            return new TransistorCard();
        }
    }

    class IntegratedCardDeveloper : Developer
    {
        public override Card Create()
        {
            return new IntegratedCard();
        }
    }

    abstract class Card
    {
        public virtual double Discount { get; }
        public override string ToString() => $"Card: {GetType().Name};\t Discount: {Discount}";
    }

    class TubeCard : Card
    {
        public override double Discount { get; } = 0.05;
        public TubeCard()
        {
            Console.WriteLine("Tube Card earned.");
        }
    }
    class TransistorCard : Card
    {
        public override double Discount { get; } = 0.1;

        public TransistorCard()
        {
            Console.WriteLine("Integrated Card earned.");
        }
    }

    class IntegratedCard : Card
    {
        public override double Discount { get; } = 0.15;

        public IntegratedCard()
        {
            Console.WriteLine("Integrated Card earned.");
        }
    }

    class ChooseCard
    {
        private static Card Card { get; set; }
        public static Card SelectCard(double sum)
        {
            if (sum >= 5000 && sum <= 12500)
            {
                Developer dev = new TubeCardDeveloper();
                Card = dev.Create();
            }
            else if (sum >= 12500 && sum <= 25000)
            {
                Developer dev = new TransistorCardDeveloper();
                Card = dev.Create();
            }
            else if (sum >= 25000)
            {
                Developer dev = new IntegratedCardDeveloper();
                Card = dev.Create();
            }
            else
            {
                Console.WriteLine("You don't have enough accumulation to get a card!");
            }

            return Card;
        }
    }
}
