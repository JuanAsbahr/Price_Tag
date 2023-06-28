using System;
using System.Globalization;
using System.Collections.Generic;
using Price_Tag.Entities;


internal class Program
{
    private static void Main(string[] args)
    {
        List<Product> list = new List<Product>();

        Console.Write("Enter the number of products: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();

        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine($"Product #{i} Data");
            Console.Write("Common, used or imported (c/u/i)? ");
            char prod = char.Parse(Console.ReadLine());
            Console.Write("Product: ");
            string product = Console.ReadLine();
            Console.Write("Price: $");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (prod == 'c')
            {
                list.Add(new Product(product, price));
            }
            else if (prod == 'u')
            {
                Console.Write("Manufacture Date (dd/mm/yyyy): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                list.Add(new UsedProduct(product, price, date));                
            }
            else
            {
                Console.Write("Customs fee: $");
                double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new ImportedProduct(product, price, customsFee));
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("PRICE TAGS");
        foreach (Product product in list)
        {
            Console.WriteLine(product.PriceTag());
        }

    }
}