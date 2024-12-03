using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DCCircuitApp.Meters;

namespace DCCircuitApp
{
    public class Elements
    {
        public abstract class Element
        {
            public double Value { get; set; }
            public double Resistance { get; set; }
            public double MaxVoltage { get; set; }
            public double MaxAmperage { get; set; }
            public virtual string DisplayParams()
            {
                return $"R = {Resistance} Ом\nU <= {MaxVoltage} В\nI <= {MaxAmperage} А";
            }
            public bool BurnedUp()
            {
                if (Value > MaxAmperage) { return true; }
                return false;
            }
        }

        public class EmptyElement: Element
        {
            public EmptyElement()
            {
                Resistance = 0;
                MaxVoltage = double.MaxValue;
                MaxAmperage = double.MaxValue;
            }
            public override string DisplayParams()
            {
                return "";
            }
        }

        public class Resistor: Element
        {
            public Resistor(double res, double maxu, double maxi)
            {
                Resistance = res;
                MaxVoltage = maxu;
                MaxAmperage = maxi;
            }
        }

        public class Lamp: Element
        {
            public double MinAmperage { get; set; }
            public Lamp(double res, double maxu, double mini, double maxi)
            {
                Resistance = res;
                MaxVoltage = maxu;
                MinAmperage = mini;
                MaxAmperage = maxi;
            }
            public override string DisplayParams()
            {
                return $"R = {Resistance} Ом\nU <= {MaxVoltage} В\nI >= {MinAmperage} А\nI <= {MaxAmperage} А";
            }
            public bool IsLighting()
            {
                if (Value >= MinAmperage && Value <= MaxAmperage) { return true; }
                else { return false; }
            }
        }

        public class Switch: Element
        {
            public Switch()
            {
                Resistance = 0;
                MaxVoltage = double.MaxValue;
                MaxAmperage = double.MaxValue;
            }
            public override string DisplayParams()
            {
                return "";
            }
        }

        public class DC: Element
        {
            public double Voltage { get; set; }
            public DC(double voltage)
            {
                Voltage = voltage;
                Resistance = 0;
                MaxVoltage = double.MaxValue;
                MaxAmperage = double.MaxValue;
            }
            public override string DisplayParams()
            {
                return $"U = {Voltage} В";
            }
        }

        public class Amperemeter : Element
        {
            public Amperemeter() 
            {
                Resistance = 0;
                MaxVoltage = double.MaxValue;
                MaxAmperage = double.MaxValue;
            }
            public override string DisplayParams()
            {
                return $"I = {Math.Round(Value, 2)} А";
            }
        }
    }
}
