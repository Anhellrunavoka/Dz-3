using System;

class Product {
    public int Num { get; private set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Kilkist { get; set; }
    private static int nextNum = 0; 

    public Product(string name, int price,int kil)
    {
        Num = ++nextNum;
        Name = name.ToLower();
        Price = price;
        Kilkist = kil;
    }
}
class Stock { 
    private Product [] products=new Product[100];
    private int product_count_now = 0;

    public void Add(string name, int price,int kil) {
        if(product_count_now < products.Length)
        {
            Product product = new Product(name, price,kil);
            products[product_count_now++]=product;
            Console.WriteLine($"Product added: {product}");
        }
        else
        {
            Console.WriteLine("Stock is full. Cannot add more products.");
        }
    }
    public void Delete_byNum(int num) {
        for (int i = 0; i < product_count_now; i++)
        {
            if (products[i].Num == num)
            {
                Console.WriteLine($"Product removed: {products[i].Name}");
                for (int j = i; j < product_count_now - 1; j++)
                {
                    products[j] = products[j + 1];
                }
                products[--product_count_now] = null;
                return;
            }
        }
        Console.WriteLine($"Product with ID {num} not found.");
    }
    public void Delete_byName(string name)
    {
        for (int i = 0; i < product_count_now; i++)
        {
            if (products[i].Name == name)
            {
                Console.WriteLine($"Product removed: {products[i].Name}");
                for (int j = i; j < product_count_now - 1; j++)
                {
                    products[j] = products[j + 1];
                }
                products[--product_count_now] = null;
                return;
            }
        }
        Console.WriteLine($"Product with Name {name} not found.");
    }
    public void Change_Kil(int num,int new_kil) {
        for (int i = 0; i < product_count_now; i++)
        {
            if (products[i].Num == num)
            {
                products[i].Kilkist = new_kil;
                Console.WriteLine($"Product updated: {products[i].Name}");
                return;
            }
        }
        Console.WriteLine($"Product with ID {num} not found.");
    }
    public void Change_Price(string name, int new_price)
    {
        for (int i = 0; i < product_count_now; i++)
        {
            if (products[i].Name == name)
            {
                products[i].Price = new_price;
                Console.WriteLine($"Product updated: {products[i].Name}");
                return;
            }
        }
        Console.WriteLine($"Product with ID {name} not found.");
    }
    public void PrintAll()
    {
        Console.WriteLine("Products: \n");
        for(int i = 0;i < product_count_now; i++)
        {
            Console.WriteLine($"{products[i].Num}.Name:{products[i].Name},Price:{products[i].Price} grn,Kilkist:{products[i].Kilkist}");
        }
    }

}
class Program {
    static void Main(string[] args) {
        Stock stock = new Stock();
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove by Number");
            Console.WriteLine("3. Remove by Name");
            Console.WriteLine("4. Update Kilkist");
            Console.WriteLine("5. Update Price");
            Console.WriteLine("6. Display All");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    int price = int.Parse(Console.ReadLine());
                    Console.Write("Enter product kilkist: ");
                    int quantity = int.Parse(Console.ReadLine());
                    stock.Add(name, price,quantity);
                    break;
                case "2":
                    Console.Write("Enter product  number to delete: ");
                    int deleteNum = int.Parse(Console.ReadLine());
                    stock.Delete_byNum(deleteNum);
                    break;
                case "3":
                    Console.Write("Enter product  name to delete: ");
                    string deleteName = Console.ReadLine();
                    stock.Delete_byName(deleteName);
                    break;
                case "4":
                    Console.Write("Enter product number to update: ");
                    int updateNum = int.Parse(Console.ReadLine());
                    Console.Write("Enter new kilkist: ");
                    int newKil = int.Parse(Console.ReadLine());
                    stock.Change_Kil(updateNum, newKil);
                    break;
                case "5":
                    Console.Write("Enter product number to update: ");
                    string updateName = Console.ReadLine();
                    Console.Write("Enter new kilkist: ");
                    int newPrice = int.Parse(Console.ReadLine());
                    stock.Change_Price(updateName, newPrice);
                    break;
                case "6":
                    stock.PrintAll();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
