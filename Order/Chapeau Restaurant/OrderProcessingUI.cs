using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauLogic;
using ChapeauModel;

namespace Chapeau_Restaurant
{
    public partial class OrderProcessingUI : ChapeauForm
    {
        ProcessOrder_Service ProcessOrder;
        Order order;
        StockViewUI stock;
        public OrderProcessingUI(string jobType)
        {
            stock = new StockViewUI(this);
            stock.Hide();
            InitializeComponent();
            ProcessOrder = new ProcessOrder_Service();
            
            currentUser = new User();
            currentUser.jobType = jobType;

        }

        private void OrderProcessingUI_Load(object sender, EventArgs e)
        {
            order = new Order();
            LoadOrdersList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrdersList();
        }

        void LoadOrdersList()
        {
            //logged in as chef by default
            order.OrderItems = ProcessOrder.Get_All_Orders(IsChef(currentUser.jobType));

            listViewORDERS.Clear();
            listViewORDERS.GridLines = true;
            listViewORDERS.View = View.Details;
            listViewORDERS.Columns.Add("Order ID", 100, HorizontalAlignment.Left);
            listViewORDERS.Columns.Add("Item Name", 150, HorizontalAlignment.Left);
            listViewORDERS.Columns.Add("Sub Type", 100, HorizontalAlignment.Left);
            listViewORDERS.Columns.Add("Time", 100, HorizontalAlignment.Left);

            foreach (OrderItem OI in order.OrderItems)
            {
                ListViewItem Ord = new ListViewItem(OI.itemID.ToString());
                Ord.Tag = OI;
                Ord.SubItems.Add(OI.name);
                Ord.SubItems.Add(OI.type);
                Ord.SubItems.Add(order.date.ToString());
                listViewORDERS.Items.Add(Ord);
            }
            OrdStatusbtn.BackColor = Color.Aqua;
            OrdStatusbtn.Text = "CHANGE ORDER STATUS";
        }
        
        private bool IsChef(string jobtype)
        {
            if (jobtype == "Chef")
                return true;
            else
                return false;
        }

        private void OrdStatusbtn_Click(object sender, EventArgs e)
        {

            if (listViewORDERS.SelectedItems.Count >= 1)
            {
                //btncounter++;
                OrderItem OI = (OrderItem)listViewORDERS.SelectedItems[0].Tag;
                ProcessOrder.Order_Status_Ready(OI.itemID);
                

                OrdStatusbtn.BackColor = Color.LawnGreen;

                if (listViewORDERS.SelectedItems.Count == 1)
                {
                    OrdStatusbtn.Text = "ORDER READY";
                    MessageBox.Show("Selected Order removed from order's list", "Order status changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

                else
                {
                    OrdStatusbtn.Text = "ORDERS READY";
                    MessageBox.Show("Selected Orders removed from order's list", "Order status changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
            else
            {
                MessageBox.Show("Please select atleast 1 order to mark as READY", "No Order Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OrdStatusbtn.BackColor = Color.Aqua;
                OrdStatusbtn.Text = "CHANGE ORDER STATUS";
            }

            listViewORDERS.SelectedItems.Clear();
            LoadOrdersList();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock.Show();
            Hide();
        }
    }
}
