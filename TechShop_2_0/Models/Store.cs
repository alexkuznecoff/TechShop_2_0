using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop_2_0.Models
{
    public class Store
    {
        public double Balance = 10000; // USD

        private List<Product> Products { get; set; }

        private SalesReportData SalesReport { get; set; }

        public Store()
        {
            Products = new List<Product>();

            SalesReport = new SalesReportData();

            var lines = File.ReadAllLines("SampleData.txt");  

            foreach (var line in lines)
            {
                var firstSymbol = line[0];
                var lineItems = line.Split(';');

                switch (firstSymbol)
                {
                    case 'L':
                        Enum.TryParse(lineItems[6], out OperationSystem laptopOS);

                        var laptop = new Laptop
                        {
                            Id = int.Parse(lineItems[1]),
                            Manufacturer = lineItems[2],
                            ModelName = lineItems[3],
                            ProductionYear = int.Parse(lineItems[4]),
                            Price = double.Parse(lineItems[5]),
                            OSType = laptopOS
                        };
                        Products.Add(laptop);
                        break;

                    case 'M':
                        Enum.TryParse(lineItems[6], out OperationSystem mobilePhoneOSType);

                        var mobilePhone = new MobilePhone
                        {
                            Id = int.Parse(lineItems[1]),
                            Manufacturer = lineItems[2],
                            ModelName = lineItems[3],
                            ProductionYear = int.Parse(lineItems[4]),
                            Price = double.Parse(lineItems[5]),
                            OSType = mobilePhoneOSType
                        };
                        Products.Add(mobilePhone);
                        break;

                    case 'T':

                        var tablet = new Tablet
                        {
                            Id = int.Parse(lineItems[1]),
                            Manufacturer = lineItems[2],
                            ModelName = lineItems[3],
                            ProductionYear = int.Parse(lineItems[4]),
                            Price = double.Parse(lineItems[5]),
                            IsSimCardSupported = bool.Parse(lineItems[6])
                        };
                        Products.Add(tablet);
                        break;
                }
            }
        }

        public void AddProduct(Product product)
        {
            if (Balance < product.Price)
            {
                return;
            }

            SalesReport.AddsCount++;
            SalesReport.Spends += product.Price;

            product.Price *= 1.2;
            Products.Add(product);
            Balance -= product.Price;
        }

        public void SellProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
                return;

            SalesReport.SalesCount++;
            SalesReport.Income += product.Price;

            Balance += product.Price;
            Products.Remove(product);  
        }

        public List<Product> FindProducts(string filter)
        {
            List<Product> findProducts = new List<Product>();

            foreach(var product in Products)
            {
                if(product.Id.ToString().Contains(filter)|| product.Manufacturer.Contains(filter)
                    || product.ModelName.Contains(filter)||product.ProductionYear.ToString().Contains(filter)
                    || product.Price.ToString().Contains(filter))
                {
                    findProducts.Add(product);
                   // return findProducts;
                }
            }
            return findProducts;
        }

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetProduct(int productId)
        {
            return Products.FirstOrDefault(p => p.Id == productId);
        }

        public SalesReportData GetSalesReport()
        {
            return SalesReport;
        }
    }
}
