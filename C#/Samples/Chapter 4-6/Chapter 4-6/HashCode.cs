using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Chapter_4_6
{
    [TestClass]
    public class HashCode
    {
        [TestMethod]
        public void GetHashCode()
        {
            OverrideGHC a = new OverrideGHC(33, true);
            OverrideGHC b = new OverrideGHC(178, false);

            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
        }

        [TestMethod]
        public void EqualsAndHashCode()
        {
            OverrideGHC a1 = new OverrideGHC(1, true);
            OverrideGHC a2 = new OverrideGHC(1, true);

            NotOverrideGHC b1 = new NotOverrideGHC(1, true);
            NotOverrideGHC b2 = new NotOverrideGHC(1, true);

            //if objects == than their hash codes match
            A.IsTrue(a1.Equals(a2));
            A.AreEqual(a1.GetHashCode(), a2.GetHashCode());

            //default implementation do not satisfies rule above
            A.IsTrue(b1.Equals(b2));
            A.AreNotEqual(b1.GetHashCode(), b2.GetHashCode());
        }

        [TestMethod]
        public void OverrideGHCInCollection()
        {
            String va, vb;
            var a = new OverrideGHC(1, true);
            var b = new OverrideGHC(1, true);

            var d = new Dictionary<OverrideGHC, String>();
            d.Add(a, "a1 value");

            d.TryGetValue(a, out va);
            d.TryGetValue(b, out vb);

            //with overrided hash code if objects are equal (even if it is different instances) corretly find them in hash table
            A.AreEqual(a, b);
            A.AreEqual("a1 value", va);
            A.AreEqual("a1 value", vb);
        }

        [TestMethod]
        public void NotOverrideGHCInCollection()
        {
            String va, vb;
            var a = new NotOverrideGHC(1, true);
            var b = new NotOverrideGHC(1, true);

            var d = new Dictionary<NotOverrideGHC, String>();
            d.Add(a, "a1 value");

            d.TryGetValue(a, out va);
            d.TryGetValue(b, out vb);

            //without overrided hash code if objects are equal could not find them in hash table
            //find only by instanse
            A.AreEqual(a, b);
            A.AreEqual("a1 value", va);
            A.AreNotEqual("a1 value", vb);
        }

        [TestMethod]
        public void MeasurePerformance()
        {
            String v;
            var d_not  = new Dictionary<NotOverrideGHC, String>();
            var d_over = new Dictionary<OverrideGHC, String>();

            //adding to collection
            var t1 = DateTime.Now;
            for (int i=0; i<1000000; i++)
            {
                d_not.Add(new NotOverrideGHC(i, true), i.ToString());
            }
            var t2 = DateTime.Now;

            for (int i=0; i<1000000; i++)
            {
                d_over.Add(new OverrideGHC(i, true), i.ToString());
            }
            var t3 = DateTime.Now;

            //getting from collection
            for (int i = 0; i < 1000000; i++)
            {
                d_not.TryGetValue(new NotOverrideGHC(i, true), out v);
            }
            var t4 = DateTime.Now;

            for (int i = 0; i < 1000000; i++)
            {
                d_over.TryGetValue(new OverrideGHC(i, true), out v);
            }
            var t5 = DateTime.Now;

            //Default implementation has longer execution time (during adding to collection hash code is calculated)
            Console.WriteLine("Default implementation = " + t2.Subtract(t1).Ticks/1000 );
            Console.WriteLine("Overrided implementation = " + t3.Subtract(t2).Ticks/1000 );

            //Default implementation is much longer, maybe because could not find key in bucket, so excessive search
            Console.WriteLine("Default implementation get value = " + t4.Subtract(t3).Ticks / 1000);
            Console.WriteLine("Overrided implementation get value = " + t5.Subtract(t4).Ticks / 1000);
        }
    }

    public class OverrideGHC
    {
        private int a;
        private bool b;

        public OverrideGHC(int a, bool b)
        {
            this.a = a;
            this.b = b;
        }

        public override bool Equals(object obj)
        {
            OverrideGHC o = (OverrideGHC)obj;

            if (a == o.a && b == o.b)
                return true;

            return false;
        }

        //default simple way is just to xor instance fields
        public override int GetHashCode()
        {
            if (b)
            {
                return (a << 2) + 1;
            }

            return (a << 2);
        }
    }

    public class NotOverrideGHC
    {
        private int a;
        private bool b;

        public NotOverrideGHC(int a, bool b)
        {
            this.a = a;
            this.b = b;
        }

        public override bool Equals(object obj)
        {
            NotOverrideGHC o = (NotOverrideGHC)obj;

            if (a == o.a && b == o.b)
                return true;

            return false;
        }
    }
}

