using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TypeCasting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = "";
            var b = 100;

            object o1 = 1;
            object o2 = a;
            object o3 = new { z = "23", e = 1 };
            object o4 = new { z1 = "", e1 = 8 };

            Console.WriteLine("a: " + a.GetType().ToString());
            Console.WriteLine("b: " + b.GetType().ToString());
            Console.WriteLine("o1: " + o1.GetType().ToString());
            Console.WriteLine("o1 long: " + ((long)(int)o1).GetType().ToString());
            Console.WriteLine("o2: " + o2.GetType().ToString());
            Console.WriteLine("o3: " + o3.GetType().ToString());
            Console.WriteLine("o4: " + o4.GetType().ToString());

            A.AreEqual(typeof(String), a.GetType());
            A.AreEqual(typeof(int), b.GetType());
            A.AreNotEqual(o3.GetType(), o4.GetType());
        }

        //note: cast int to long is ok, but cast object that is actually int to long - is prohibitet, but if we cast object to int than to long it is ok

        [TestMethod]
        public void ObjectIntLong()
        {
            Object o;
            o = (Object)3;
            var typeO = o.GetType();
            var typeI = ((int)o).GetType();

            A.AreEqual(typeO, typeI);

            var a = o;
            var b = (int)o;
        }
    }
}
