using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Unit7
{
    static class Helper<TArray>
    {
        /// Generate and store unique value for Managers ID
        private static int id;
        public static int Id
        {
            get { return id++; }
        }
        /// Generate and store unique value for Products Article
        private static int article;
        public static int Article
        {
            get { return article++; }
        }
        /// Generate and store unique value for Orders number
        private static int number;
        public static int Number
        {
            get { return number++; }
        }
        /// Deleting one item, which equals NULL
        public static void CutOneItem<TArray>(ref TArray[] OldArray, string Type)
        {
            for (int i = 0; i < OldArray.Length - 1; i++)
            {
                if (OldArray[i] == null)
                    OldArray[i] = OldArray[i + 1];
            }
            Array.Resize(ref OldArray, OldArray.Length - 1);
            Console.WriteLine("Deleted one item {0}", Type);
        }
        /// Add one item into array
        public static void AddOneItem<TArray>(ref TArray[] OldArray, TArray NewItem)
        {
            Array.Resize(ref OldArray, OldArray.Length + 1);
            OldArray[OldArray.Length - 1] = NewItem;
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
        /// Check User for pay posibility
        public static bool CheckUsersBalance(User User)
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
        /// Static constructor
        static Helper()
        {
            article = 0;
            number = 0;
            id = 1000;
        }
    }
    /// Class dicribes abstract entity Person
    abstract class Person
    {
        /// Persons login
        private string login;
        public virtual string Login
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
        /// Persons password
        protected string password;
        public abstract string Password
        {
            get;
            set;
        }
        /// Operator == for class Person
        public static bool operator ==(Person a, Person b)
        {
            if (a.Login == b.Login)
                return true;
            else
                return false;
        }
        /// Operator != for class Person
        public static bool operator !=(Person a, Person b)
        {
            if (a.Login != b.Login)
                return true;
            else
                return false;
        }
        /// Constructor
        public Person()
        {
            Console.WriteLine("Enter Login");
            password = Console.ReadLine();
            Console.WriteLine("Enter Password");
            login = Console.ReadLine();
        }
    }
    /// Class discribes entity User
    class User : Person
    {
        public override string Password
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
        /// Users products list
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
        /// Users money balance
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
        /// Constructor
        public User(double mon) : base()
        {
            if (mon >= 0)
                balance = mon;
            else
                Console.WriteLine("Ooops! User can't have negative balance");
            productsList = new Product[1];
            productsList[0] = null;
        }
        /// Add one product in users product list
        public void AddProduct(Product NewProduct)
        {
            if (productsList != null)
            {
                foreach (Product Prod in productsList)
                {
                    if (Prod == NewProduct)
                    {
                        Prod.Count += NewProduct.Count;
                        break;
                    }

                }
                Helper<Product>.AddOneItem(ref productsList, NewProduct);
            }
            else
                Console.WriteLine("Ooops! Product list equals NULL! Fix this misunderstanding!");
        }
        /// Add array of products in users product list
        public void AddProduct(Product[] NewProducts)
        {
            if (productsList != null)
            {
                foreach (Product Prod in productsList)
                    foreach (Product NewProd in NewProducts)
                    {
                        if (Prod == NewProd)
                        {
                            Prod.Count += NewProd.Count;
                            break;
                        }
                        Helper<Product>.AddOneItem(ref productsList, NewProd);
                    }
            }
            else
                Console.WriteLine("Ooops! Product list equals NULL! Fix this misunderstanding!");
        }
        /// Delete one concrete product from users product list
        public void DeleteProduct(Product DelProd)
        {
            if (productsList != null)
            {
                for (int i = 0; i < productsList.Length; i++)
                {
                    if (productsList[i] == DelProd)
                    {
                        productsList[i].Count -= DelProd.Count;
                        if (productsList[i].Count == 0)
                        {
                            productsList[i] = null;
                            Helper<Product>.CutOneItem<Product>(ref productsList, "Product");
                        }
                    }
                }
            }
            else
                Console.WriteLine("Ooops! Product list equals NULL! Fix this misunderstanding!");
        }
    }
    /// Class dicribes entity Manager
    class Manager : Person
    {
        public override string Login
        {
            get => base.Login;

            set
            {
                if (value.Contains("M_"))
                    base.Login = value;
                else
                    Console.WriteLine("Ooops! Wrong login");
            }
        }
        public override string Password
        {
            get { return password; }
            set
            {
                if (value != null && value.Length > 10)
                    password = value;
                else
                    Console.WriteLine("Ooops! Password can't be empty or shorter 10 letters");
            }
        }
        
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 1000)
                    id = value;
                else
                {
                    Console.WriteLine("Ooops! Manager ID mast be bigger than 1000. Id was generated automaticly.");
                    id = Helper<Manager>.Id;
                }


            }
        }
        /// Constructor without params
        public Manager() : base()
        {
            id = Helper<Manager>.Id;
        }
        /// Constructor with one param
        public Manager(int id) : this()
        {
                this.id = id;
        }
        /// Operator == for class Manager
        public static bool operator ==(Manager a, Manager b)
        {
            if (a.id == b.id)
                return true;
            else
                return false;
        }
        /// Operator != for class Manager
        public static bool operator !=(Manager a, Manager b)
        {
            if (a.id != b.id)
                return true;
            else return false;
        }
    }
    /// Decribes abstract entity Delivery
    abstract public class Delivery
    {
        public string ShopAddress;
        public virtual double Cost
        {
            get 
            {
                return ShopAddress.Length - DeliveryAddress.Length;
            }
        }
        public string DeliveryAddress;
    }
    /// Delivery from shop to the user home by courier
    class HomeDelivery : Delivery
    {

        public override double Cost => base.Cost * 2.1;
    }
    /// Delivery from shop to the pickpoint
    class PickPointDelivery : Delivery
    {
        public override double Cost => base.Cost* 2.1;
    }
    /// Delivery from one shop to the another shop
    class ShopDelivery : Delivery
    {
        public override double Cost => base.Cost * 0.2;
    }
    /// Describes entity Product
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
        /// Article of product can't bee empty
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
        /// Prise of products can't bee cheper than 0.01
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
        /// Count of products in the shop
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
        /// Operator == for class Product
        public static bool operator ==(Product a, Product b)
        {
            if (a.article == b.article && a.name == b.name)
                return true;
            else
                return false;
        }
        /// Operater != for class Product
        public static bool operator !=(Product a, Product b)
        {
            if (a.article != b.article || a.name != b.name)
                return true;
            else
                return false;
        }
    }
    /// Shop with managers, users and products
    class Shop<TType>
    {
        public string Name;
        public string Adress;
        /// Managers array
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
        /// Array of users
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
        /// Array of products
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
        /// Base constructor
        public Shop()
        {
            Name = null;
            Adress = null;
            managers = null;
            users = null;
            products = null;
        }
        /// Second constructor
        public Shop(string Name, string Adress, User[] users, Product[] products) : this()
        {
            this.Name = Name;
            this.Adress = Adress;
            Console.WriteLine("Enter count of managers");
            int i = int.Parse(Console.ReadLine());
            Manager[] managers = new Manager[i];
            this.users = users;
            this.products = products;
        }
        public void DelItem<TTYpe>(TType Item)
        {
            /// Delete User from users list
            if (Item is User User)
            {
                if (users != null)
                {
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] == User)
                        {
                            users[i] = null;
                            Helper<User>.CutOneItem(ref users, "User");
                            return;
                        }
                    }
                }
                else
                    Console.WriteLine("Ooops! Users list is empty!");
            }
            /// Delete Manager from managers list
            if (Item is Manager Manager)
            {
                if (managers != null)
                {
                    for (int i = 0; i < managers.Length; i++)
                    {
                        if (managers[i] == Manager)
                        {
                            managers[i] = null;
                            Helper<Manager>.CutOneItem(ref managers, "Manager");
                            return;
                        }
                    }
                }
                else
                    Console.WriteLine("Ooops! Manager list is empty!");
            }
            /// Delete Product from products list
            if (Item is Product Product)
            {
                if (products != null)
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i] == Product)
                        {
                            if (products[i].Count > Product.Count)
                                products[i].Count -= Product.Count;
                            else
                            {
                                products[i] = null;
                                Helper<Product>.CutOneItem(ref products, "Product");
                                return;
                            }
                        }
                    }
                }
                else
                    Console.WriteLine("Ooops! Users list is empty!");
            }
            else
                Console.WriteLine("Ooops! Wrong Item Type!");
        }
        public bool CheckUser()
        {
            return true;
            return false;
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
        public Order(TDelivery delivery, int number, Manager manager, User user)
        {
            Delivery = delivery;
            Number = number;
            Description = Console.ReadLine();
            Manager = manager;
            User = user;
            Payment = false;
            Products = user.productsList;
            foreach (var item in Products)
            {
                Price += item.Price;
            }
            Price += delivery.Cost;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
}
