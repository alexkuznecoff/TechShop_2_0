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
        public double Balance = 1000; // USD

        public List<Product> Products { get; set; }

        public Store()
        {
            Products = new List<Product>();
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

        public void SellProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
                return;

            Balance += product.Price;
            Products.Remove(product);
        }
    }
}
