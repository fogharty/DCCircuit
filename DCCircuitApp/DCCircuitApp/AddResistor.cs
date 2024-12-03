using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCCircuitApp
{
    public partial class AddResistor : Form
    {
        public AddResistor()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public AddResistor(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            double resistance, voltage, amperage;
            if (double.TryParse(input_resistance.Text, out resistance) && double.TryParse(input_voltage.Text, out voltage) && double.TryParse(input_amperage.Text, out amperage))
            {
                //this.mainForm.ResParams(new string[] {input_resistance.Text, input_voltage.Text, input_amperage.Text});
                Close();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
