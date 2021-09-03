using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauLogic;



namespace Chapeau_Restaurant
{
    public partial class OrderForm : ChapeauForm
    {
        Font titleFont = new Font("Rockwell", 15, FontStyle.Bold);
        Order_Service order_service = new Order_Service();
        PaymentForm paymentForm;
        List<TableView> tableViews;
        
        public OrderForm()
        {
            CreateTables();
            paymentForm = new PaymentForm(this);
            paymentForm.Hide();
            InitializeComponent();
        }

        
        private void pnlLunch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanelMenuItems.Controls.Clear();
            AddMenuSection("Lunch", "Main", "Lunch Main");
            AddMenuSection("Lunch", "Specials", "Specials");
            AddMenuSection("Lunch", "Bites", "Bites");
        }

        private void CreateLunchList()
        {

        }

        private void AddMenuSection(string category, string subCategory, string title)
        {
            List<ChapeauMenuItem> menuItems = order_service.GetMenuItems(category, subCategory);
            AddMenuSectionToUI(menuItems, title);
        }

        //this functions add a section(sub category) to the menu list
        //this will show a title and number of menu lines
        private void AddMenuSectionToUI(List<ChapeauMenuItem> menuItems, string title)
        {
            Label label = new Label();
            label.Text = title;
            label.Font = titleFont;
            flowLayoutPanelMenuItems.Controls.Add(label);

            
            foreach (ChapeauMenuItem item in menuItems)
            {
                OrderItem i = new OrderItem()
                {
                    name = item.name,
                    price = item.price,
                    itemID = item.itemID,
                    stockQuantity = item.stockQuantity
                };
                MenuViewLine menuViewLine = new MenuViewLine(i);
                flowLayoutPanelMenuItems.Controls.Add(menuViewLine);
            }
        }


        private void flowLayoutPanelMenuItems_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dinnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanelMenuItems.Controls.Clear();
            AddMenuSection("Dinner", "Starters", "Starters");
            AddMenuSection("Dinner", "Main", "Mains");
            AddMenuSection("Dinner", "Desserts", "Desserts");
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanelMenuItems.Controls.Clear();
            AddMenuSection("Drinks", "SoftDrinks", "Soft Drinks");
            AddMenuSection("Drinks", "HotDrinks", "Hot Drinks");
            AddMenuSection("Drinks", "Beers", "Beers");
            AddMenuSection("Drinks", "Wines", "Wines");
        }

        Order currentOrder;
        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrderDetails(currentOrder);
        }

        public void ShowOrderDetails(Order order)
        {
            currentOrder = order;
            //
            order_service.currentOrder = order;
            OrderDetails_menuStrip.Show();
            //this will show me the overview of orders. 
            flowLayoutPanelMenuItems.Controls.Clear();
            Label label = new Label();
            label.Width = 300;
            label.Text = "Order Overview";
            label.Font = titleFont;
            flowLayoutPanelMenuItems.Controls.Add(label);

            if (order.state == Status.Pending || order.state == Status.Processing || order.state == Status.Ready)
            {

                
                List<OrderItem> orders = order_service.GetOrderLines();
                //Retrieve all orders from the the model, and show it in the flowlayoutpanel
                foreach (OrderItem item in order.OrderItems)
                {
                    MenuViewLine menuViewLine = new MenuViewLine(item);
                    // We are creating a line for the order details section:
                    // We want these menu view lines to be removed when clicking "X", so mark them
                    menuViewLine.MarkedForClear = true;
                    flowLayoutPanelMenuItems.Controls.Add(menuViewLine);
                }

                Button btnSendOrder = new Button();
                btnSendOrder.Text = "Send Order";
                flowLayoutPanelMenuItems.Controls.Add(btnSendOrder);
                btnSendOrder.Click += BtnSendOrder_Click;

                Button btnPay = new Button();
                btnPay.Text = "Pay";
                flowLayoutPanelMenuItems.Controls.Add(btnPay);
                btnPay.Click += btnPay_Click;
            }
            else
            {
                Label emptylabel = new Label();
                emptylabel.Text = "no orders started";
                emptylabel.Width = 300;
                emptylabel.Height = 50;
                emptylabel.TextAlign = ContentAlignment.MiddleLeft;
                flowLayoutPanelMenuItems.Controls.Add(emptylabel);

                Button newOrder_btn = new Button();
                newOrder_btn.Text = "new order";
                flowLayoutPanelMenuItems.Controls.Add(newOrder_btn);
                newOrder_btn.Click += newOrder_btn_Click;
            }
            if (order.state == Status.Empty)
            {
                Button occupy_btn = new Button();
                occupy_btn.Text = "occupied";
                flowLayoutPanelMenuItems.Controls.Add(occupy_btn);
                occupy_btn.Click += occupy_btn_Click;
            }
            else if(order.state == Status.Occupied)
            {
                Button free_btn = new Button();
                free_btn.Text = "free table";
                flowLayoutPanelMenuItems.Controls.Add(free_btn);
                free_btn.Click += free_btn_Click;
            }
        }

        private void BtnSendOrder_Click(object sender, EventArgs e)
        {
            order_service.SendOrder();
            order_service.CreateNewOrder();
            flowLayoutPanelMenuItems.Controls.Clear();
            Label label = new Label();
            label.Width = 200;
            label.Text = "Order Sent!";
            label.Font = titleFont;
            flowLayoutPanelMenuItems.Controls.Add(label);
        }

        // sends order to payment form
        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                paymentForm.Show();
                Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void occupy_btn_Click(object sender, EventArgs e)
        {
            try
            {
                currentOrder.state = Status.Occupied;
                order_service.SaveOrder(currentOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void newOrder_btn_Click(object sender, EventArgs e)
        {
            try
            {
                paymentForm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void free_btn_Click(object sender, EventArgs e)
        {
            try
            {
                paymentForm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //*******************************************************************************************
        //Order Overview leveque Jesse
        private void CreateTables()
        {

            int count = 0;
            tableViews = new List<TableView>();
            for (int i = 0; i < 10; i++)
            {
                count++;
                TableView tableview = new TableView((i+1).ToString(), Status.Empty, "", this);
                
                tableViews.Add(tableview);
            }
            AddOrdersToTables();
        }
        private List<Order> GetOrders()
        {
            List<Order> orders = order_service.GetChapeauOrders();
            foreach(Order order in orders)
            {
                order.OrderItems = order_service.GetOrderItems(order.id);
                tableViews[order.table - 1].order = order;
            }

            return orders;
        }
        private void AddOrdersToTables()
        {
            List<Order> orders = GetOrders();
            foreach(Order order in orders)
            {
                order.OrderItems = order_service.GetOrderItems(order.id);
                tableViews[order.table-1].order = order;
                tableViews[order.table-1].changestate();
            }
            foreach (TableView table in tableViews)
            {
                if (table.order == null)
                {
                    table.order = new Order();
                }
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        public void LoadTables()
        {
            OrderDetails_menuStrip.Hide();
            flowLayoutPanelMenuItems.Controls.Clear();
            flowLayoutPanelMenuItems.WrapContents = true;

            foreach(TableView table in tableViews)
            {
                flowLayoutPanelMenuItems.Controls.Add(table);
            }
        }

        //public Order UpdateOrder(int orderID)
        //{
        //    Order order = order_service.UpdateOrder(orderID);
        //    order.OrderItems = order_service.GetOrderItems(order.id);
        //    return tableViews[order.table - 1].order = order;
        //}
    }
}
