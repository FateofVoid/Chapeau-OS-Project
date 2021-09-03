using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChapeauModel
{
    public class OrderItem
    {
        public int itemID;
        public int quantity;
        public string name;
        public decimal price;
        public string comment;
        public string type;
        public string subType;
        public int stockQuantity;

        public OrderItem()
        {
        }
        

        public double Vat
        {
            get
            {
                if (type == "Alcoholic")
                { return (double)price * 0.21; }
                else
                {
                    return (double)price * 0.9;
                }
            }
        }
    }
}