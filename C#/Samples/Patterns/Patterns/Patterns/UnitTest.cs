using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Patterns
{
    //http://www.devartplus.com/singleton-inheritance-in-c-net-part-1/ - about singleton inheritance
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void SampleOfUse()
        {
            var config = Singleton.Instance;

            config.Display();
            config.Load("5pt", "10pt");
            config.Display();
        }

        [TestMethod]
        public void TryToCreateFewInstances()
        {
            var inst1 = Singleton.Instance;
            var inst2 = Singleton.Instance;
            //var inst3 = new Singleton(); //impossible to create via constructor - private

            Console.WriteLine($"Hash code of instance 1 = {inst1.GetHashCode()}");
            Console.WriteLine($"Hash code of instance 2 = {inst2.GetHashCode()}");
            Assert.IsTrue(inst1 == inst2);
        }
    }
}