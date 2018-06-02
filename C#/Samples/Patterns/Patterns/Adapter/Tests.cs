using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//tempData & tempCalc have different interfaces for getting temperature, using Adapter => same unified interface adapter.GetTemperature()
namespace Adapter
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestOfAdapter() //client
        {
            var tempData = new TempData { Celsii = 20, Kelvin = 293.15, Farengeit = 68 };
            var tempCalc = new TempCalculator(100.4, TemperatureType.F);

            Console.WriteLine(tempData);
            Console.WriteLine(tempCalc);

            PrintAdapterResults(new Adapter(tempData)); //adopt adaptee interface to target interface
            PrintAdapterResults(new Adapter(tempCalc));
        }

        private void PrintAdapterResults(ITemperature target)
        {
            var c = target.GetTemperature(TemperatureType.C);
            var k = target.GetTemperature(TemperatureType.K);
            var f = target.GetTemperature(TemperatureType.F);

            Console.WriteLine($"Adapter: C = {c}, K = {k}, F = {f}");
        }
    }
}