using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DCCircuitApp.Elements;
using static DCCircuitApp.Meters;

namespace DCCircuitApp
{
    public class Knot
    {
        public int Id { get; private set; }
        public Element CurrentElement { get; set; }
        public double I {  get; private set; }
        public Knot (int id)
        {
            Id = id;
            CurrentElement = new EmptyElement();
        }

        public bool IsEmpty()
        {
            return (CurrentElement.GetType() == typeof(EmptyElement));
        }

    }
}
