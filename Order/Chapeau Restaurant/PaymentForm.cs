using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauLogic;

namespace Chapeau_Restaurant
{
    public partial class PaymentForm : ChapeauForm
    {
        PaymentService ps;
        Order order;
        double tip;

        OrderForm orderForm;
        public PaymentForm(OrderForm orderForm)
        {
            InitializeComponent();
            this.orderForm = orderForm;

        }

        private void ConfirmPaymentBtn_Click(object sender, EventArgs e)
        {
            tip = double.Parse(TipTxtBox.Text);
            ps = new PaymentService();
            ps.UpdateOrderStatusAndTip(order.id, tip);
            Choosepayment choosepayment = new Choosepayment();
            choosepayment.ShowDialog();

        }

        private void PrintBillBtn_Click(object sender, EventArgs e)
        {
            order.id = int.Parse(OrderIdTxtBox.Text);
             ps = new PaymentService();
           List<Item> items= ps.GetOrderItems(order.id);
            BillGridView.AutoGenerateColumns = true;
            BillGridView.DataSource = items;
            Double priceNoVat=0, priceWithVat=0, Vat=0;
            foreach (var item in items)
            {
                priceNoVat += item.Price;
                Vat += item.Vat;
            }
            priceWithVat = priceNoVat + Vat;
            VatLbl.Text += Vat.ToString();
            PriceNoVatLbl.Text += priceNoVat.ToString();
            TotalPriceLbl.Text += priceWithVat.ToString();
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
