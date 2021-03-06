﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop_2_0.Models;

namespace TechShop_2_0
{
    class Program
    {
        private static Store store;

        static void Main(string[] args)
        {
            store = new Store();

            while (true)
            {
                ShowMenuItems();
                var option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        ShowItemsList();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        SellProduct();
                        break;
                    case 4:
                        FindProduct();
                        break;
                    case 5:
                        ShowSalesReport();
                        break;
                    case 6:
                        ShowsStatistics();
                        break;
                    default:
                        ShowMenuItems();
                        continue;
                }
                Console.WriteLine("\n Press any key to return....");
                Console.ReadKey();
                ShowMenuItems();
            }

        }

        private static void ShowItemsList()
        {
            var products = store.GetAllProducts();

            foreach (var product in products)
            {
                product.Print(true);
            }
        }

        private static void ShowsStatistics()
        {
            throw new NotImplementedException();
        }

        private static void ShowSalesReport()
        {
            var report = store.GetSalesReport();

            Console.Clear();

            Console.WriteLine("Sales report :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Income = {report.Income} $  , Operations {report.SalesCount}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Spends = {report.Spends}$ , Operations {report.AddsCount}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Current balance = {store.Balance}$");

        }

        private static void FindProduct()
        {
            Console.Clear();
            Console.Write("Please, enter search filter :");
            var filter = Console.ReadLine();
            var resultProducts = store.FindProducts(filter);

            if (resultProducts == null)
            {
                Console.WriteLine("Nothing was found...");
                return;
            }

            Console.WriteLine("Products Found :");
            foreach (var resultProduct in resultProducts)
            {
                resultProduct.Print(false);
            }
        }

        private static void SellProduct()
        {
            Console.Clear();
            ShowItemsList();

            Console.Write("\nPlease, enter product id to sell :");
            var productId = int.Parse(Console.ReadLine());
            var product = store.GetProduct(productId);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine($"Product with id {productId} was not found");
                return;
            }

            Console.Clear();
            product.Print(false);
            Console.WriteLine("Are you sure (Y/N)");
            var answer = Console.ReadLine() == "Y";

            if (answer)
            {
                store.SellProduct(productId);
            }
            //Console.Clear();

        }

        private static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("What new product type do you want to add ? (L. laptop | M. mobole phone | T. tablet |) ");
            var productType = Console.ReadLine();

            if (productType != "L" && productType != "M" && productType != "T")
            {
                Console.WriteLine("Error...Wrong input...press any key to continue...");
                Console.ReadKey();
            }

            //Console.WriteLine("Enter new product info :");
            //var product = new Product();

            //Console.Write("Id:");
            //product.Id = int.Parse(Console.ReadLine());

            //Console.Write("Manufacturer: ");
            //product.Manufacturer = Console.ReadLine();

            //Console.Write("Model name: ");
            //product.ModelName = Console.ReadLine();

            //Console.Write("Price ($): ");
            //product.Price = double.Parse(Console.ReadLine());   



            switch (productType)
            {

                case "L":

                    Console.WriteLine("Enter new laptop info :");
                    var laptop = new Laptop();

                    Console.Write("Id:");
                    laptop.Id = int.Parse(Console.ReadLine());

                    Console.Write("Manufacturer: ");
                    laptop.Manufacturer = Console.ReadLine();

                    Console.Write("Model name: ");
                    laptop.ModelName = Console.ReadLine();

                    Console.WriteLine("Production year:");
                    laptop.ProductionYear = int.Parse(Console.ReadLine());

                    Console.Write("Price ($): ");
                    laptop.Price = double.Parse(Console.ReadLine());

                    Console.Write("Operation system: ");
                    Enum.TryParse(Console.ReadLine(), out OperationSystem laptopOS);
                    laptop.OSType = laptopOS;
                    store.AddProduct(laptop);

                    break;

                case "M":

                    Console.WriteLine("Enter new mobile phone info :");
                    var mobilePhone = new MobilePhone();

                    Console.Write("Id:");
                    mobilePhone.Id = int.Parse(Console.ReadLine());

                    Console.Write("Manufacturer: ");
                    mobilePhone.Manufacturer = Console.ReadLine();

                    Console.Write("Model name: ");
                    mobilePhone.ModelName = Console.ReadLine();

                    Console.WriteLine("Production year:");
                    mobilePhone.ProductionYear = int.Parse(Console.ReadLine());

                    Console.Write("Price ($): ");
                    mobilePhone.Price = double.Parse(Console.ReadLine());

                    Console.Write("Operation system: ");
                    Enum.TryParse(Console.ReadLine(), out OperationSystem mobilePhoneOs);
                    mobilePhone.OSType = mobilePhoneOs;
                    store.AddProduct(mobilePhone);

                    break;

                case "T":

                    Console.WriteLine("Enter new tablet info :");
                    var tablet = new Tablet();

                    Console.Write("Id:");
                    tablet.Id = int.Parse(Console.ReadLine());

                    Console.Write("Manufacturer: ");
                    tablet.Manufacturer = Console.ReadLine();

                    Console.Write("Model name: ");
                    tablet.ModelName = Console.ReadLine();

                    Console.WriteLine("Production year:");
                    tablet.ProductionYear = int.Parse(Console.ReadLine());

                    Console.Write("Price ($): ");
                    tablet.Price = double.Parse(Console.ReadLine());

                    Console.Write("The tablet has Sim card ? (Y/N)");
                    var IsSimCardSupported = Console.ReadLine() == "Y";
                    tablet.IsSimCardSupported = IsSimCardSupported;
                    store.AddProduct(tablet);

                    break;
            }
        }

        static void ShowMenuItems()
        {
            Console.Clear();
            Console.WriteLine($"Your balance : {store.Balance}");
            Console.WriteLine("Please, select option :");
            Console.WriteLine();
            Console.WriteLine("Storage: ");
            Console.WriteLine("1. Get All items");
            Console.WriteLine("2. Add item");
            Console.WriteLine();
            Console.WriteLine("Shop:");
            Console.WriteLine("3. Sell Device");
            Console.WriteLine("4. Find Device");
            Console.WriteLine();
            Console.WriteLine("Manege: ");
            Console.WriteLine("5. Sales Report");          // Отчет по продажам
            Console.WriteLine("6. Statistics");
            Console.WriteLine("Enter a number and press enter :");
        }
    }
}
