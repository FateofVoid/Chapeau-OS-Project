using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Item
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public String Sub_Type { get; set; }
        public double Vat
        {
            get
            {
                if (Type == "Alcoholic")
                { return Price * 0.21; }
                else
                {
                    return Price * 0.9;
                }
            }
        }
    }
}
