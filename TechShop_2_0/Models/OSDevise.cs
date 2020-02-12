using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop_2_0.Models
{
    class OSDevise : Product
    {
        public OperationSystem OSType { get; set; }

        public override void Print(bool IsInlinePrint)
        {
            if (IsInlinePrint)
            {
                
                Console.WriteLine($"{Id}, {Manufacturer} , {ModelName} : ({ProductionYear} year) :  {OSType} - {Price}$");

            }
            else
            {
                PrintSingle();
                Console.WriteLine($"Operation system:  {OSType}");
            }

        }
    }
}
