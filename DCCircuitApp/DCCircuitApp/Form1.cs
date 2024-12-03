using DCCircuitApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DCCircuitApp.Elements;
using static DCCircuitApp.Meters;
using static DCCircuitApp.CalcMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DCCircuitApp
{
    public partial class Form1 : Form
    {
        public Dictionary<PictureBox, Knot> knots;
        public Dictionary<PictureBox, Label> knots_params;
        public Dictionary<PictureBox, string> knots_orientation;
        public Form1()
        {
            InitializeComponent();
            knots = new Dictionary<PictureBox, Knot>()
            {
                [knot0] = new Knot(0),
                [knot1] = new Knot(1),
                [knot2] = new Knot(2),
                [knot3] = new Knot(3),
                [knot4] = new Knot(4),
                [knot5] = new Knot(5),
                [knot6] = new Knot(6),
                [knot7] = new Knot(7),
                [knot8] = new Knot(8),
                [knot9] = new Knot(9),
                [knot10] = new Knot(10),
                [knot11] = new Knot(11),
                [knot12] = new Knot(12),
                [knot13] = new Knot(13),
                [knot14] = new Knot(14),
                [knot15] = new Knot(15),
                [knot16] = new Knot(16),
                [knot17] = new Knot(17),
                [knot18] = new Knot(18),
            };
            knots_orientation = knots.Keys.Zip(new String[19] { "UL", "Horizontal", "UM", "Horizontal", "UR", "Vertical", "Vertical", "Vertical", "Vertical", "Vertical", "Vertical", "Vertical", "Vertical", "Vertical", "DL", "Horizontal", "DM", "Horizontal", "DR" }, (key, value) => new { Key = key, Value = value }).ToDictionary(item => item.Key, item => item.Value);
            knots_params = knots.Keys.Zip(new Label[19] { knot0_params, knot1_params, knot2_params, knot3_params, knot4_params, knot5_params, knot6_params, knot7_params, knot8_params, knot9_params, knot10_params, knot11_params, knot12_params, knot13_params, knot14_params, knot15_params, knot16_params, knot17_params, knot18_params }, (key, value) => new { Key = key, Value = value }).ToDictionary(item => item.Key, item => item.Value);
            foreach (var param in knots_params.Values)
            {
                param.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var knot in knots.Keys)
            {
                knot.AllowDrop = true;
            }
        }

        private string GetKnotOrientation(PictureBox knot)
        {
            return knots_orientation[knot];
        }

        private void ShowKnots(bool all = false)
        {
            foreach (var knot in knots.Keys)
            {
                if (knots[knot].IsEmpty() && all)
                {
                    knot.Visible = true;
                }
                else if (knots[knot].IsEmpty() && (GetKnotOrientation(knot) == "Vertical" || GetKnotOrientation(knot) == "Horizontal"))
                {
                    knot.Visible = true;
                }
            }
        }

        private void HideKnots()
        {
            foreach (var knot in knots.Keys)
            {
                if (knots[knot].IsEmpty())
                {
                    knot.Visible = false;
                }
            }
        }

        /*public void ResParams (string[] p)
        {
            res_currentR.Text = p[0];
            res_currentU.Text = p[1];
            res_currentI.Text = p[2];
        }

        private void resistor_Click(object sender, EventArgs e)
        {
            var res1 = new AddResistor(this);
            res1.ShowDialog();
        }*/

        private void element_MouseDown(object sender, MouseEventArgs e)
        {
            ShowKnots();
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
            HideKnots();
        }

        private void lamp_MouseDown(object sender, MouseEventArgs e)
        {
            ShowKnots(true);
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
            HideKnots();
        }

        private void knot_DragEnter(object sender, DragEventArgs e)
        {
            if (knots[((PictureBox)sender)].IsEmpty()) ((PictureBox)sender).Image = Resources.knot1;
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void knot_DragLeave(object sender, EventArgs e)
        {
            if (knots[((PictureBox)sender)].IsEmpty()) ((PictureBox)sender).Image = Resources.knot0;
        }

        private void knot_DragDrop(object sender, DragEventArgs e)
        {
            Image getPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            if (getPicture.Equals(resistor.Image))
            {
                if (knots_orientation[((PictureBox)sender)] == "Vertical") { ((PictureBox)sender).Image = Resources.resistorrot; }
                else { ((PictureBox)sender).Image = Resources.resistor; }
                double res, maxU, maxI;
                if (double.TryParse(res_R.Text, out res) && double.TryParse(res_maxU.Text, out maxU) && double.TryParse(res_maxI.Text, out maxI))
                {

                    knots[((PictureBox)sender)].CurrentElement = new Resistor(res, maxU, maxI);
                    knots_params[((PictureBox)sender)].Text = knots[((PictureBox)sender)].CurrentElement.DisplayParams();
                }
            }
            else if (getPicture.Equals(lamp.Image))
            {
                ((PictureBox)sender).Image = Resources.lamp0;
                double res, maxU, minI, maxI;
                if (double.TryParse(lamp_R.Text, out res) && double.TryParse(lamp_maxU.Text, out maxU) && double.TryParse(lamp_minI.Text, out minI) && double.TryParse(lamp_maxI.Text, out maxI))
                {

                    knots[((PictureBox)sender)].CurrentElement = new Lamp(res, maxU, minI, maxI);
                    knots_params[((PictureBox)sender)].Text = knots[((PictureBox)sender)].CurrentElement.DisplayParams();
                }
            }
            else if (getPicture.Equals(_switch.Image))
            {
                if (knots_orientation[((PictureBox)sender)] == "Vertical") { ((PictureBox)sender).Image = Resources._switchrot; }
                else { ((PictureBox)sender).Image = Resources._switch; }
                knots[((PictureBox)sender)].CurrentElement = new Switch();
                knots_params[((PictureBox)sender)].Text = knots[((PictureBox)sender)].CurrentElement.DisplayParams();
            }
            else if (getPicture.Equals(dc.Image))
            {
                double U;
                if (double.TryParse(dc_U.Text, out U))
                {
                    if (knots.Keys.Count(knot => knots[knot].CurrentElement.GetType() == typeof(DC)) != 0)
                    {
                        IEnumerable<PictureBox> existingDC = from knot in knots.Keys where knots[knot].CurrentElement.GetType() == typeof(DC) select knot;
                        foreach (PictureBox knot in existingDC)
                        {
                            knot.Image = Resources.knot0;
                            knots[knot].CurrentElement = new EmptyElement();
                            knots_params[knot].Text = "";
                        }
                    }
                    if (knots_orientation[((PictureBox)sender)] == "Vertical") { ((PictureBox)sender).Image = Resources.batteryrot; }
                    else { ((PictureBox)sender).Image = Resources.battery; }
                    knots[((PictureBox)sender)].CurrentElement = new DC(U);
                    knots_params[((PictureBox)sender)].Text = knots[((PictureBox)sender)].CurrentElement.DisplayParams();
                }
            }
            else if (getPicture.Equals(amperemeter.Image))
            {
                if (knots_orientation[((PictureBox)sender)] == "Vertical") { ((PictureBox)sender).Image = Resources.amperemeterrot; }
                else { ((PictureBox)sender).Image = Resources.amperemeter; }
                knots[((PictureBox)sender)].CurrentElement = new Amperemeter();
            }
            if (knots[((PictureBox)sender)].IsEmpty()) ((PictureBox)sender).Image = Resources.knot0;
        }

        private void knot_Click(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Resources.knot0;
            knots[((PictureBox)sender)].CurrentElement = new EmptyElement();
            knots_params[((PictureBox)sender)].Text = "";
            HideKnots();
        }

        private void bin_Click(object sender, EventArgs e)
        {
            foreach (var knot in knots.Keys)
            {
                knot.Image = Resources.knot0;
                knots[knot].CurrentElement = new EmptyElement();
                knots_params[knot].Text = "";
                HideKnots();
            }
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            double U = CalcAll(knots.Values.ToArray());
            label_U.Text = $"U = {Math.Round(U, 2)} В";
            foreach(var knot in knots_params.Keys)
            {
                if (knots[knot].CurrentElement.GetType() == typeof(Amperemeter))
                {
                    knots_params[knot].Text = knots[knot].CurrentElement.DisplayParams();
                }
                else if (knots[knot].CurrentElement.GetType() == typeof(Lamp))
                {
                    if (((Lamp)knots[knot].CurrentElement).IsLighting())
                    {
                        knot.Image = Resources.lamp1;
                    }
                    else
                    {
                        knot.Image = Resources.lamp0;
                    }
                }
                if (knots[knot].CurrentElement.BurnedUp())
                {
                    knot.Image = Resources.fire;
                }
            }
        }
    }
}
