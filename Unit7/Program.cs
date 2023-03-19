using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Unit7
{
    public static class Helper<TArray>
    {
        private static int article;
        public static int Article
        {
            get { return article++; }
        }
        private static int number;
        public static int Number
        {
            get { return number++; }
        }

        /// Deleting one item, which equals NULL
        public static void CutOneItem(ref TArray[] OldArray, string Type)
        {
            for (int i = 0; i < OldArray.Length - 1; i++)
            {
                if (OldArray[i] == null)
                    OldArray[i] = OldArray[i + 1];
            }
            Array.Resize(ref OldArray, OldArray.Length - 1);
            Console.WriteLine("Deleted one item {0}", Type);
        }
        /// Counting sum of users products list
        public static double ListPrice(Product[] List)
        {
            double Price = 0;
            for (int i = 0; i < List.Length; i++)
            {
                Price += List[i].Price * List[i].Count;
            }
            return Price;
        }
        static Helper()
        {
            article = 0;
            number = 0;
        }
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
        // Users products list
        public Product[] productsList;
        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < productsList.Length)
                    return productsList[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < productsList.Length)
                    productsList[index] = value;
            }
        }
        // users money balance
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
            productsList = new Product[1];
            productsList[0] = null;
        }
        public void AddProduct(Product NewProduct)
        {
            if (productsList != null)
            {
                foreach (Product Prod in productsList)
                {
                    if (Prod.Name == NewProduct.Name && Prod.Article == NewProduct.Article)
                    {
                        Prod.Count += NewProduct.Count;
                        break;
                    }

                }
                Array.Resize(ref productsList, productsList.Length + 1);
                productsList[productsList.Length - 1] = NewProduct;
            }
            else
                Console.WriteLine("Ooops! Product list equals NULL! Fix this misunderstanding!");
        }
        public void AddProduct(Product[] NewProducts)
        {
            if (productsList != null)
            {
                foreach (Product Prod in productsList)
                    foreach (Product NewProd in NewProducts)
                    {
                        if (Prod.Name == NewProd.Name && Prod.Article == NewProd.Article)
                        {
                            Prod.Count += NewProd.Count;
                            break;
                        }
                        Array.Resize(ref productsList, productsList.Length + 1);
                        productsList[productsList.Length - 1] = NewProd;
                    }
            }
            else
                Console.WriteLine("Ooops! Product list equals NULL! Fix this misunderstanding!");
        }
        public void DeleteProduct(Product DelProd)
        {
            if (productsList != null)
            {
                for (int i = 0; i < productsList.Length; i++)
                {
                    if (productsList[i].Name == DelProd.Name && productsList[i].Article == DelProd.Article)
                    {
                        productsList[i].Count -= DelProd.Count;
                        if (productsList[i].Count == 0)
                        {
                            productsList[i] = null;
                            Helper<Product>.CutOneItem(ref productsList, "User");
                        }
                    }
                }
            }
            else
                Console.WriteLine("Ooops! Product list equals NULL! Fix this misunderstanding!");
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

        public bool CheckUsersBalance(User User)
        {
            if (User.productsList != null)
            {
                if (User.Balance >= Helper<Product>.ListPrice(User.productsList))
                {
                    Console.WriteLine("User can buy this");
                    return true;
                }
                else
                {
                    Console.WriteLine("User can't buy this");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Oops! Users product list is empty!");
                return false;
            }
        }
    }

    abstract public class Delivery
    {
        public string Address;
        public double Cost;
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
    public class Product
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
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
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
                {
                    Console.WriteLine("Ooops! Can't be negative amount of products");
                    count = 0;
                }
            }
        }
    }
    // Shop with managers, users and products
    class Shop
    {
        public string Name;
        // Managers array
        private Manager[] managers;
        public Manager this[short index]
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
        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < products.Length)
                    return products[index];
                else
                    return null;
            }
        }
        public Shop()
        {
            Name = null;
            managers = null;
            users = null;
            products = null;
        }
        public Shop(string name, User[] users, Product[] products) : this()
        {
            Console.WriteLine("Enter count of managers");
            int i = int.Parse(Console.ReadLine());
            Manager[] managers = new Manager[i];
            this.users = users;
            this.products = products;
        }
        public void DelItem(User[] OldArray, string Login)
        {
            if (OldArray != null)
            {
                for (int i = 0; i < OldArray.Length; i++)
                {
                    if (OldArray[i].Login == Login)
                    {
                        Helper<User>.CutOneItem(ref OldArray, "User");
                        return;
                    }
                }
            }
            else
                Console.WriteLine("This Array can't be empty");
        }
        public void DelItem(Manager[] OldArray, string Login)
        {
            if (OldArray != null)
            {
                for (int i = 0; i < OldArray.Length; i++)
                {
                    if (OldArray[i].Login == Login)
                    {
                        Helper<Manager>.CutOneItem(ref OldArray, "Manager");
                        return;
                    }
                }
            }
            else
                Console.WriteLine("This Array can't be empty");
        }
        public void DelItem(Product[] OldArray, string Article)
        {
            if (OldArray != null)
            {
                for (int i = 0; i < OldArray.Length; i++)
                {
                    if (OldArray[i].Article == Article)
                    {
                        Helper<Product>.CutOneItem(ref OldArray, "Product");
                        return;
                    }
                }
            }
            else
                Console.WriteLine("This Array can't be empty");
        }
    }
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;
        public int Number;
        public string Description;
        public Manager Manager;
        public User User;
        public bool Payment;
        public Product[] Products;
        public double Price = 0;
        public Product this[int index]
        {
            get
            {
                if (index > 0 && index < Products.Length)
                    return Products[index];
                else
                    return null;
            }
        }
        public Order(TDelivery delivery, int number, Manager manager, User user, Product[] products)
        {
            Delivery = delivery;
            Number = number;
            Description = Console.ReadLine();
            Manager = manager;
            User = user;
            Payment = false;
            Products = products;
            foreach (var item in Products)
            {
                Price += item.Price;
            }
            Price += delivery.Cost;
        }

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
