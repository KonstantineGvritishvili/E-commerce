using E_Commerce;
using System.Transactions;

public class Program
{
    static Shop shop = new Shop();
    static List<User> users = new List<User>();
    static Buy buy = new Buy();
    static User currentUser;

    static void Main()
    {
        Seed();
        Console.WriteLine("Welcome to the Shop!!!!!");

        while (true)
        {
            if (currentUser == null)
            {
                Console.WriteLine("1.Login ");
                Console.WriteLine("2.Register ");
                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;

                }
            }


            else
            {
                if (currentUser.UserType == UserType.Admin)
                {
                    AdminMenu();
                }
                else if (currentUser.UserType == UserType.Customer)
                {
                    CustomerMenu();
                }
            }

            
        }
    }

    static void Seed()
    {
        users.Add(new User { UserId = 1, Money = 150, Password = "admin", UserType = UserType.Admin, Username = "admin" });
        users.Add(new User { UserId = 2, Money = 250, Password = "customer", UserType = UserType.Customer, Username = "customer" });

        shop.Products.Add(new Product { ProductId = 1, ProductManufacturer = "Chocholate", ProductName = "Kinder", Price = 12.5m, Date = DateTime.Now, Quantity = 5 });
        shop.Products.Add(new Product { ProductId = 2, ProductManufacturer = "Beverage", ProductName = "Coke", Price = 11.5m, Date = DateTime.Now, Quantity = 15 });
    }

    static void Register()
    {
        Console.WriteLine("Enter Username: ");
        string username = Console.ReadLine();

        Console.WriteLine("Enter Password: ");
        string password = Console.ReadLine();

        Console.WriteLine("Enter money: ");
        decimal money = decimal.Parse(Console.ReadLine());

        User newUser = new User
        {
            UserId = users.Count + 1,
            UserType = UserType.Customer,
            Username = username,
            Password = password,
            Money = money
        };

        users.Add(newUser);
        currentUser = newUser;


        Console.WriteLine("You registered");
    }

    static void Login()
    {
        Console.WriteLine("Enter Username: ");
        string username = Console.ReadLine();

        Console.WriteLine("Enter Password: ");
        string password = Console.ReadLine();

        currentUser = users.FirstOrDefault(user => user.Username == username && user.Password == password);

        if (currentUser == null)
        {
            Console.WriteLine("Invalid username or password.");
        }
        else
        {
            Console.WriteLine("Login successful!");
        }
    }

    static void AddProduct()
    {
        Console.WriteLine("Enter Product Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Product Manufacturer: ");
        string manufacturer = Console.ReadLine();

        Console.WriteLine("Enter Product Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Product Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Product newProduct = new Product
        {
            ProductId = shop.Products.Count + 1,
            ProductName = name,
            ProductManufacturer = manufacturer,
            Price = price,
            Quantity = quantity,
            Date = DateTime.Now
        };

        shop.Products.Add(newProduct);
        Console.WriteLine("Product added successfully!");
    }


    static void AdminMenu()
    {
        Console.WriteLine("1.ShowProduct ");
        Console.WriteLine("2.Add Product ");
        Console.WriteLine("3.Delete Product ");
        Console.WriteLine("4.update product ");
        Console.WriteLine("5.Show sold products ");
        Console.WriteLine("6.Logout ");

        int choise = int.Parse(Console.ReadLine());

        switch(choise)
        {
            case 1:
                shop.ShowProducts();
                break;
            case 2:
                AddProduct();
                break;
            case 3:
                DeleteProduct();
                break;
            case 4:
                UpdateProduct();
                break;
            case 5:
                buy.ShowSoldProducts();
                break;
            case 6:
                currentUser = null;
                break;
        }
    }
    static void CustomerMenu()
    {
        Console.WriteLine("1.Show Product ");
        Console.WriteLine("2.Buy Product ");
        Console.WriteLine("3.Show Total price ");
        Console.WriteLine("4.Logout ");

        int choise = int.Parse(Console.ReadLine());


        switch (choise)
        {
            case 1:
                shop.ShowProducts();
                break;
            case 2:
                BuyProduct();
                break;
            case 3:
                Console.WriteLine($"Total price is: {shop.TotalPrice()}");
                break;
            case 4:
                currentUser = null;
                break;
        }

    }


    static void DeleteProduct()
    {
        shop.ShowProducts();
        Console.WriteLine("enter product to delete: ");
        int id = int.Parse(Console.ReadLine());
        shop.DeleteProduct(id);
    }

    static void UpdateProduct()
    {
        shop.ShowProducts();
        Console.Write("Enter product Id to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter new product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter new  Product manufacturer: ");
        string manufacturer = Console.ReadLine();

        Console.Write("Enter new Product Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter New Product Quantity");
        int quantity = int.Parse(Console.ReadLine());

        Product product = new Product
        {
            ProductId = id,
            ProductName = name,
            ProductManufacturer = manufacturer,
            Quantity = quantity,
            Date = DateTime.Now

        };



    }

    static void BuyProduct()
    {
        shop.ShowProducts();
        Console.WriteLine("Enter Product ID to buy: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Quantity to buy: ");
        int quantity = int.Parse(Console.ReadLine());

        foreach(var product in shop.Products)
        {
            if( product.ProductId == id && currentUser.Money >= product.Price * quantity)
            {
                currentUser.Money -= product.Price * quantity;
                buy.BuyProduct(product, currentUser.UserId, quantity);
                return;
            }
        }

        Console.WriteLine("Not enough money or product not found");

    }

}
