using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class ProcessOrder_Service
    {
        ProcessOrder_DAO ProcessOrder_db = new ProcessOrder_DAO();

        public List<OrderItem> Get_All_Orders(bool food) 
        {
            try
            {
                List<OrderItem> OrderItems;
                if (food)
                {
                    OrderItems = ProcessOrder_db.Db_Get_All_Food_Orders();
                }

                else
                    OrderItems = ProcessOrder_db.Db_Get_All_Drink_Orders();

                return OrderItems;
            }
            catch (Exception e)
            {
                throw new Exception("couldn't connect to the database");
            }
        }

        public void Order_Status_Ready(int Order_Id)
        {
            ProcessOrder_db.Db_Order_Status_Ready(Order_Id);
        }


    }
}
