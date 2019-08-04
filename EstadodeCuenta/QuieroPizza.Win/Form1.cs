using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstadodeCuenta.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ClientesBL = new ClientesBL();
            var listadeClientes = ClientesBL.ObtenerClientes();

            listadeClientesBindingSource.DataSource = listadeClientes;
        }

        private void listadeProductosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
