using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7
{
    public static class Helper
    {

    }
    abstract class Person
    {
        private string login;
        public string Login 
        { 
            get { return login; }
            set
            {
                if (value != null)
                    login = value;
                else
                    Console.WriteLine("Ooops! Login can't be empty");
            }   
        }
        private string password;
        public string Password
        {
            get { return password; } 
            set 
            {
                if (value != null)
                    password = value;
                else
                    Console.WriteLine("Ooops! Password can't be empty");
            }
        }
    }
    class User : Person
    {

    }
    class Manager : Person
    {

    }

    abstract class Delivery
    {
        public string Address;
    }

    class HomeDelivery : Delivery
    {
        /* ... */
    }

    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    class ShopDelivery : Delivery
    {
        /* ... */
    }
    class Product <TArticle>
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                    name = value;
                else
                    Console.WriteLine("Ooops! Name of product can't be empty");
            }
        }
        // Article of product can't bee empty
        private TArticle articlee;
        public TArticle Articlee
        {
            get { return articlee; }
            set
            {
                if (value != null)
                    articlee = value;
                else
                    Console.WriteLine("Ooops! Article can't bee empty");
            }
        }
        // Prise of products can't bee cheper than 0.01
        private double prise;
        public double Prise
        {
            get { return prise; }
            set
            {
                if (value > 0)
                    prise = value;
                else
                    Console.WriteLine("Ooops! Prise can't be cheaper than 0.01");
            }
        }
        public string Description;
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (value <= count)
                    count -= value;
                else
                    Console.WriteLine("Ooops! You can by only {0} product units", count);
            }
        }
    }
    class Shop
    {
        private Manager[] managers;
        public Manager this[int index]
        {
            get
            {
                if (index >= 0 && index < managers.Length)
                    return managers[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < managers.Length)
                    managers[index] = value;
            }
        }
    }
    class Order<TDelivery,
    TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product<int> prod = new Product<int>();
            prod.Count = 10;
            Console.ReadLine();
            
        }
    }
}
