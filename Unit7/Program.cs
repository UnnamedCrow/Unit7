﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Person(string log, string pas)
        {
            password = pas;
            login = log;
        }
    }
    class User : Person
    {
        private double balance;
        public double Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
                else
                    Console.WriteLine("Ooops! You have not enough money to by");
            }
        }
        public User(double mon) : base(Console.ReadLine(), Console.ReadLine())
        {
            if (mon >= 0)
                balance = mon;
            else
                Console.WriteLine("Ooops! User can't have negative balance");
        }
    }
    class Manager : Person
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 1000)
                    id = value;
                else
                    Console.WriteLine("Ooops! Manager ID mast be bigger than 1000");

            }
        }
        public Manager(int id) : base(Console.ReadLine(), Console.ReadLine())
        {
            if (id > 1000)
                this.id = id;
            else
                Console.WriteLine("Ooops! Manager ID mast be bigger than 1000");
        }
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
    class Product
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
        private string article;
        public string Article
        {
            get { return article; }
            set
            {
                if (value != null)
                    article = value;
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
        // Count of products in the shop
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (value >= 0)
                    count = value;
                else
                    Console.WriteLine("Ooops! Can't be negative amount of products");
            }
        }
    }
    // Shop with managers, users and products
    class Shop
    {
        // Manaders array
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
        }
        public Manager this[string index]
        {
            get
            {
                foreach (var manager in managers)
                {
                    if (index == manager.Login)
                    {
                        return manager;
                    }
                }
                Console.WriteLine("Ooops! Unknown manager you looking for");
                return null;
            }
        }
        // Array of users
        private User[] users;
        public User this[byte index]
        {
            get
            {
                if (index >= 0 && index < users.Length)
                    return users[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < users.Length)
                    users[index] = value;
            }
        }
        // Array of products
        private Product[] products;
        public Product this[short index]
        {
            get
            {
                if (index >= 0 && index < products.Length)
                    return products[index];
                else
                    return null;
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
         
            Console.ReadLine();

        }
    }
}
