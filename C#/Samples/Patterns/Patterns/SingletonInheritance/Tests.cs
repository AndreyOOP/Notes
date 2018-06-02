using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonInheritance
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Sample1()
        {
            var inst1 = InheritedSingleton.Instance;
            var inst2 = InheritedSingleton.Instance;

            Assert.IsTrue(inst1 == inst2);
            Console.WriteLine(inst1.BaseProperty);
            Console.WriteLine(inst1.AdditionProperty);
        }

        [TestMethod]
        public void Sample2()
        {
            var instA1 = Singleton<A>.Instance;
            var instA2 = A.Instance;
            //var instB = Singleton<B>.Instance; impossible because of 'where T : Singleton<T>' constrain

            Assert.IsTrue(instA1 == instA2);
            Console.WriteLine($"Variable of instA1 = {instA1.SomeVar}, instA2 = {instA2.SomeVar}");
        }

        public class A : Singleton<A>
        {
            private A()
            {
                Console.WriteLine("Constructor of class A");
            }

            public int SomeVar = 10;
        }

        public class B
        {
            private B()
            {
                Console.WriteLine("Constructor of class B");
            }

            public int SomeVar = 20;
        }
    }
}
