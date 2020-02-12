using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop_2_0.Models
{
    class Tablet : Product
    {
        public bool IsSimCardSupported { get; set; }


        public override void Print(bool isInLinePrint)
        {
            if (isInLinePrint)
            {
                var simCardInfo = IsSimCardSupported ? "Sim" : "";

                Console.WriteLine($"{Id}, {Manufacturer} , {ModelName} : ({ProductionYear} year)  :  { simCardInfo} - {Price}$");
            }
            else
            {
                PrintSingle();
                Console.WriteLine($"Support Sim : {IsSimCardSupported}");
            }
        }
    }
}
