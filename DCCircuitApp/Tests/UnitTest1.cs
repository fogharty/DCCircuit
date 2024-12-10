using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DCCircuitApp;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class StructureTests
    {
        static IEnumerable<object[]> KnotsData1()
        {
            Knot[] knots1 = new Knot[0];
            Knot[] knots2 = new Knot[3]
            {
                new Knot(0),
                new Knot(1),
                new Knot(2),
            };
            knots2[0].CurrentElement = new Elements.Resistor(20, 0, 0);
            knots2[1].CurrentElement = new Elements.Resistor(30, 0, 0);
            knots2[2].CurrentElement = new Elements.Resistor(100, 0, 0);
            yield return new object[] { knots1, 0 };
            yield return new object[] { knots2, 150 };
        }
        [DataTestMethod]
        [DynamicData(nameof(KnotsData1), DynamicDataSourceType.Method)]
        public void CalcSerialResTest(Knot[] knots, double expected)
        {
            double actual = CalcMethods.CalcSerialResistance(knots);
            Assert.AreEqual(expected, actual);
        }

        static IEnumerable<object[]> KnotsData2()
        {
            double[] resistances1 = new double[0];
            double[] resistances2 = new double[] { 12, 342, 0, 63 };
            double[] resistances3 = new double[] { 20, 30, 100 };
            yield return new object[] { resistances1, 0 };
            yield return new object[] { resistances2, 0 };
            yield return new object[] { resistances3, (double)75/7 };
        }
        [DataTestMethod]
        [DynamicData(nameof(KnotsData2), DynamicDataSourceType.Method)]
        public void CalcParallelResTest(double[] resistances, double expected)
        {
            double actual = CalcMethods.CalcParallelResistance(resistances);
            Assert.AreEqual(expected, actual);
        }

        static IEnumerable<object[]> KnotsData3()
        {
            Knot[] knots1 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            Knot[] knots2 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            knots2[8].CurrentElement = new Elements.DC(200);
            Knot[] knots3 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            knots3[6].CurrentElement = new Elements.DC(150);
            Knot[] knots4 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            knots4[7].CurrentElement = new Elements.DC(100);
            Knot[] knots5 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            knots5[8].CurrentElement = new Elements.DC(200);
            knots5[11].CurrentElement = new Elements.Switch();
            Knot[] knots6 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            knots6[8].CurrentElement = new Elements.DC(200);
            knots6[12].CurrentElement = new Elements.Switch();
            Knot[] knots7 = new Knot[] { new Knot(0), new Knot(1), new Knot(2), new Knot(3), new Knot(4), new Knot(5), new Knot(6), new Knot(7), new Knot(8), new Knot(9), new Knot(10), new Knot(11), new Knot(12), new Knot(13), new Knot(14), new Knot(15), new Knot(16), new Knot(17), new Knot(18) };
            knots7[8].CurrentElement = new Elements.DC(200);
            knots7[10].CurrentElement = new Elements.Switch();
            yield return new object[] { knots1, 0 };
            yield return new object[] { knots2, 200 };
            yield return new object[] { knots3, 150 };
            yield return new object[] { knots4, 100 };
            yield return new object[] { knots5, 0 };
            yield return new object[] { knots6, 200 };
            yield return new object[] { knots7, 200 };
        }
        [DataTestMethod]
        [DynamicData(nameof(KnotsData3), DynamicDataSourceType.Method)]
        public void CalcAllTest(Knot[] knots, double expected)
        {
            double actual = CalcMethods.CalcAll(knots);
            Assert.AreEqual(expected, actual);
        }
    }
}
