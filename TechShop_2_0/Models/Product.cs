using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop_2_0.Models
{
    public abstract class Product
    {
        /// <summary>
        /// Product Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Manufacturer(Apple, Samsung...)
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Product Mobile Name(IPhone 11Pro, Samsung Galaxy...)
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Year of production 
        /// </summary>
        public int ProductionYear { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public double Price { get; set; }

        public abstract void Print(bool IsInLinePrint);

        protected void PrintSingle()
        {
            Console.WriteLine("Product info :");
            Console.WriteLine($"Id:              {Id}");
            Console.WriteLine($"Manufacturer:    {Manufacturer}");
            Console.WriteLine($"Model name:      {ModelName}");
            Console.WriteLine($"Prodaction year: {ProductionYear}");
            Console.WriteLine($"Price:           {Price} $");
        }
        
    }
}
