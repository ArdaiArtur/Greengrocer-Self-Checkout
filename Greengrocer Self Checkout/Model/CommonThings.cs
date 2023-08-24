using System;
using System.Collections.Generic;
using System.Text;

namespace Greengrocer_Self_Checkout.Comand
{
    public class CommonThings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
        public DateTime Date { get; set; }
        public string ItemType { get; set; }    
    }
}
