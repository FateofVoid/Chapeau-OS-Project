using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class Order_Service
    {
        Order_DAO order_db = new Order_DAO();

        public Order currentOrder = new Order();
        Random random = new Random();
        public List<Order> GetChapeauOrders()
        {
            List<Order> orders = order_db.GetChapeauOrders();
            return orders;
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            return order_db.GetOrderItems(orderId);
        }

        public List<ChapeauMenuItem> GetChapeauMenuItems(string category, string subCategory)
        {
            List<ChapeauMenuItem> Menuitems = order_db.Db_Menu_Items(category,subCategory);
            return Menuitems;
        }

        public void SaveOrder(Order order/*int orderID, List<OrderItem> orderLines,int status, decimal tip, string feedback*/)
        {
            order_db.Db_Insert_Order(order);

            foreach (KeyValuePair<int,OrderItem> item in order.OrderLines)
            {
                for (int i = 0; i < item.Value.quantity; i++)
                {
                    order_db.Db_Insert_Order_Item(order.id, item.Value.itemID);
                }
            }
        }

        public void SendOrder()
        {
            currentOrder.OrderItems =GetOrderLines();
            // call function in the logic layer
            // This function passes:
            // 1. OrderId, which is a unique ID for this order
            // 2. A list of items
            //    Each item in this list has an item id and a quantity

            // Create a unique order ID by using the current time(stamp)
            // PS we know this is not 100% guranateed, but will do for now
            int orderID = random.Next();
            SaveOrder(currentOrder);
        }

        public void CreateNewOrder()
        {
            currentOrder = new Order();
        }

        public List<ChapeauMenuItem> GetMenuItems(string category, string subCategory)
        {
            List<ChapeauMenuItem> chapeauMenuItems = GetChapeauMenuItems(category, subCategory);
            return chapeauMenuItems;
        }

        // Returns te current quantity of the specified item
        public int GetItemQuantity(int itemId)
        {
            int quantity = currentOrder.GetQuantity(itemId);
            return quantity;
        }

        public void DataChanged(OrderItem order)
        {
            currentOrder.SetOrderLineData(order);
        }

        public List<OrderItem> GetOrderLines()
        {
            return currentOrder.OrderItems;
        }
    }
}
