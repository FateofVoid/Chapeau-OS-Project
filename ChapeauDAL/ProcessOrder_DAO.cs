using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ChapeauModel;

namespace ChapeauDAL
{
    public class ProcessOrder_DAO : Base
    {
        public List<OrderItem> Db_Get_All_Food_Orders()
        {
            string query = " SELECT Orders.Id, MenuItem.Name,MenuItem.Sub_Type, Orders.Time " +
                           " FROM Orders " +
                           " JOIN OrderItem ON OrderItem.OrderId = Orders.Id " +
                           " JOIN MenuItem ON MenuItem.Id = OrderItem.ItemId " +
                           " WHERE MenuItem.Sub_Type <> 'SoftDrinks' AND MenuItem.Sub_Type <> 'HotDrinks' " +
                           " AND MenuItem.Sub_Type <> 'Beers' " +
                           " ORDER BY Orders.Time ";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<OrderItem> Db_Get_All_Drink_Orders()
        {
            string query = " SELECT Orders.Id, MenuItem.Name,MenuItem.Sub_Type, Orders.Time " +
                           " FROM Orders " +
                           " JOIN OrderItem ON OrderItem.OrderId = Orders.Id " +
                           " JOIN MenuItem ON MenuItem.Id = OrderItem.ItemId " +
                           " WHERE MenuItem.Sub_Type = 'SoftDrinks' OR MenuItem.Sub_Type = 'HotDrinks' " +
                           " OR MenuItem.Sub_Type = 'Beers' " +
                           " ORDER BY Orders.Time DESC ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<OrderItem> ReadTables(DataTable dataTable)
        {
            List<OrderItem> OrderItems = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                OrderItem order = new OrderItem()
                {
                    itemID = (int)dr["Id"],
                    name = Convert.ToString(dr["Name"]),
                    type = Convert.ToString(dr["Sub_Type"])
                };
                OrderItems.Add(order);
            }
            return OrderItems;
        }

        public void Db_Order_Status_Ready(int Id)
        {
            string query = " UPDATE dbo.Orders " +
                           " SET Status = 1 " +
                           " WHERE Id = " + Id + " ;";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
            //DeleteOrder(Id);
        }

        void DeleteOrder(int Id)
        {
            string query = " DELETE FROM dbo.OrderItem WHERE OrderId = " + Id + "; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
