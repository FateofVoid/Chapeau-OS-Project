using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapeau_Restaurant
{
    public partial class DeviceManager : ChapeauForm
    {
        List<ChapeauForm> connectedScreens;
        // manages all connected devices (basicaly creates the forms as needed)
        public DeviceManager()
        {
            
            InitializeComponent();
            connectedScreens = new List<ChapeauForm>();
            connectedScreens.Add(new OrderForm());
            //connectedScreens.Add(new PaymentForm());
            connectedScreens.Add(new OrderProcessingUI("Chef"));
            connectedScreens.Add(new OrderProcessingUI("Barman"));


            diplayAllScreens();
        }

        public void diplayAllScreens()
        {
            foreach(ChapeauForm screen in connectedScreens)
            {
                LoginForm form = new LoginForm(screen);
                form.Show();
            }
        }
    }
}
