using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DCCircuitApp.Elements;
using static DCCircuitApp.Meters;

namespace DCCircuitApp
{
    public class CalcMethods
    {
        public static double CalcAll(Knot[] knots)
        {
            Knot[] contour1 = new Knot[] { knots[0], knots[1], knots[5], knots[8], knots[11], knots[14], knots[15] };
            Knot[] contour2 = new Knot[] { knots[2], knots[6], knots[9], knots[12], knots[16] };
            Knot[] contour3 = new Knot[] { knots[3], knots[4], knots[7], knots[10], knots[13], knots[17], knots[18] };
            IEnumerable<Element> dcs;
            IEnumerable<Knot> amperemeters1;
            IEnumerable<Knot> amperemeters2;
            IEnumerable<Knot> amperemeters3;
            double R1;
            double R2;
            double R3;
            double R23;
            double R12;
            double R13;
            double R123;
            double U;
            double I1;
            double Uab;
            double I2;
            double I3;
            if (contour1.Count(knot => knot.CurrentElement.GetType() == typeof(DC)) != 0)
            {
                dcs = from knot in contour1 where knot.CurrentElement.GetType() == typeof(DC) select knot.CurrentElement;
                DC dc = (DC)dcs.First();
                R1 = CalcSerialResistance(contour1);
                R2 = CalcSerialResistance(contour2);
                R3 = CalcSerialResistance(contour3);
                if (contour1.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0)
                {
                    foreach (Knot am in contour1) { am.CurrentElement.Value = 0; }
                    foreach (Knot am in contour2) { am.CurrentElement.Value = 0; }
                    foreach (Knot am in contour3) { am.CurrentElement.Value = 0; }
                    return 0;
                }
                if (contour2.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0) { R2 = double.MaxValue; }
                if (contour3.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0) { R3 = double.MaxValue; }
                R23 = CalcParallelResistance(new double[] { R2, R3 });
                R123 = R1 + R23;
                U = dc.Voltage;
                I1 = U/R123;
                Uab = I1 * R23;
                I2 = Uab/R2;
                I3 = Uab/R3;
                foreach (Knot am in contour1) { am.CurrentElement.Value = I1; }
                foreach (Knot am in contour2) { am.CurrentElement.Value = I2; }
                foreach (Knot am in contour3) { am.CurrentElement.Value = I3; }
                return U;
            }
            else if (contour2.Count(knot => knot.CurrentElement.GetType() == typeof(DC)) != 0)
            {
                dcs = from knot in contour2 where knot.CurrentElement.GetType() == typeof(DC) select knot.CurrentElement;
                DC dc = (DC)dcs.First();
                R1 = CalcSerialResistance(contour1);
                R2 = CalcSerialResistance(contour2);
                R3 = CalcSerialResistance(contour3);
                if (contour1.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0) { R1 = double.MaxValue; }
                if (contour2.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0)
                {
                    foreach (Knot am in contour1) { am.CurrentElement.Value = 0; }
                    foreach (Knot am in contour2) { am.CurrentElement.Value = 0; }
                    foreach (Knot am in contour3) { am.CurrentElement.Value = 0; }
                    return 0;
                }
                if (contour3.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0) { R3 = double.MaxValue; }
                R13 = CalcParallelResistance(new double[] { R1, R3 });
                R123 = R2 + R13;
                U = dc.Voltage;
                I2 = U / R123;
                Uab = I2 * R13;
                I3 = Uab / R3;
                I1 = Uab / R1;
                foreach (Knot am in contour1) { am.CurrentElement.Value = I1; }
                foreach (Knot am in contour2) { am.CurrentElement.Value = I2; }
                foreach (Knot am in contour3) { am.CurrentElement.Value = I3; }
                return U;
            }
            else if (contour3.Count(knot => knot.CurrentElement.GetType() == typeof(DC)) != 0)
            {
                dcs = from knot in contour3 where knot.CurrentElement.GetType() == typeof(DC) select knot.CurrentElement;
                DC dc = (DC)dcs.First();
                R3 = CalcSerialResistance(contour3);
                R2 = CalcSerialResistance(contour2);
                R1 = CalcSerialResistance(contour1);
                if (contour1.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0) { R1 = double.MaxValue; }
                if (contour2.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0) { R2 = double.MaxValue; }
                if (contour3.Count(knot => knot.CurrentElement.GetType() == typeof(Switch)) != 0)
                {
                    foreach (Knot am in contour1) { am.CurrentElement.Value = 0; }
                    foreach (Knot am in contour2) { am.CurrentElement.Value = 0; }
                    foreach (Knot am in contour3) { am.CurrentElement.Value = 0; }
                    return 0;
                }
                R12 = CalcParallelResistance(new double[] { R1, R2 });
                R123 = R3 + R12;
                U = dc.Voltage;
                I3 = U / R123;
                Uab = I3 * R12;
                I2 = Uab / R2;
                I1 = Uab / R1;
                foreach (Knot am in contour1) { am.CurrentElement.Value = I1; }
                foreach (Knot am in contour2) { am.CurrentElement.Value = I2; }
                foreach (Knot am in contour3) { am.CurrentElement.Value = I3; }
                return U;
            }
            else
            {
                return 0;
            }
        }

        public static double CalcParallelResistance(double[] resistances)
        {
            double res = 0;
            foreach (double resistance in resistances)
            {
                if (resistance != 0)
                {
                    res += 1 / resistance;
                }
                else { return 0; }
            }
            if (res != 0) return 1 / res;
            else return 0;
        }

        public static double CalcSerialResistance(Knot[] knots)
        {
            double res = 0;
            foreach(Knot knot in knots)
            {
                res += knot.CurrentElement.Resistance;
            }
            return res;
        }
    }
}
