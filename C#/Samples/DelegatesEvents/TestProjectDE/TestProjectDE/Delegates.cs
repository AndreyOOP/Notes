using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TestProjectDE.Delegates;

namespace TestProjectDE
{
    [TestClass]
    public class TestDelegates
    {
        [TestMethod]
        public void InitializationAndUse()
        {
            //Explicit delegate creation & call
            Transformer t = new Transformer(Square);
            Assert.AreEqual(36, t.Invoke(6));

            //instance delegate
            var instance = new Delegates();
            instance.T = Cube;
            Assert.AreEqual(125, instance.T(5));

            //delegate with 2 parameters
            Operation op = Sum;
            Assert.AreEqual(5, op(2, 3));

            op = Sub;
            Assert.AreEqual(-1, op(2, 3));

            //few delegates execution.
            //Both executes, only last one show result (possible to check by output)
            t = null;
            t += Cube;
            t += Square2;
            Console.WriteLine("Only last one return result, executes both:");
            Assert.AreEqual(25, t(5));
        }

        [TestMethod]
        public void FuncAndAction()
        {
            Func<int, int, int> op = Sum;
            Assert.AreEqual(10, op(2, 8));

            Action<string> act = Message;
            act("zzz");
        }

        [TestMethod]
        public void Convers()
        {
            Del d = Act;
            //d(new OutClassA()); //impossible to compile
            d(new OutClassB());

            //possible to call derived classes
            Action<OutClassA> act = Act;
            act(new OutClassA()); //same situation with Action is ok
            act(new OutClassB());
        }

        public static int Square2(int i)
        {
            Console.WriteLine("Square 2");
            return i * i;
        }

        public static int Square(int i) => i * i;

        public static int Cube(int i)
        {
            Console.WriteLine("Cube");
            return i * i * i;
        }

        public static int Sum(int x, int y) => x + y;

        public static int Sub(int x, int y) => x - y;

        public static void Message(String msg)
        {
            Console.WriteLine("Show input msg -> " + msg);
        }

        public static void Act(OutClassA ClassA)
        {
            Console.WriteLine( 2 * ClassA.A);
        }
    }

    public class Delegates
    {
        public delegate int Transformer(int n);
        public delegate int Operation(int a, int b);
        public delegate void Del(OutClassB cla);

        public Transformer T;
    }

    public class OutClassA
    {
        protected int a = 10;

        public virtual int A {
            get {
                Console.WriteLine("Get a from OutClass_A");
                return a;
            }
        }
    }

    public class OutClassB : OutClassA
    {
        public override int A
        {
            get{
                Console.WriteLine("Get a from OutClass_B");
                return a-1;
            }
        }
    }
}
