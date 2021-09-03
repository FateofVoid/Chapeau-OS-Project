using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class PaymentService
    {
        Order_DAO paymentdb = new Order_DAO();

        public List<Item> GetOrderItems(int orderId)
        {
            try
            {
                List<Item> Items = paymentdb.MakeOrderItemsList(orderId);
                return Items;
            }
            catch (Exception e)
            {
                // something went wrong connecting to the database
                List<Item> Items = new List<Item>();
                var i = new Item();
                i.Id = -1;
                i.Name = "üknown????";
                i.Type = "uknown????";
                Items.Add(i);
                return Items;

                throw new Exception("Application couldn't connect to the database.");
            }

        }

        public void UpdateOrderStatusAndTip(int orderId, double tip)
        {
            paymentdb.UpdateOrderStatusAndTip(orderId,tip);
        }
    }
}
