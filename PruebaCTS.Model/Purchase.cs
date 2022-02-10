using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaCTS.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public decimal PriceProduct { get; set; }
    }
}
