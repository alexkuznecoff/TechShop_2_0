using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop_2_0.Models
{
    public class SalesReportData
    {
        public int SalesCount { get; set; } //количесво продаж
        public double Income { get; set; }  //доход

        public int  AddsCount { get; set; } // количесво закупок
        public double Spends { get; set; }  //затраты 

    }
}
