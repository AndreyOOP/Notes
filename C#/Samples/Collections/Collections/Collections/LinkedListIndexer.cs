using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collections
{
    [TestClass]
    public class LinkedListIndexer
    {
        [TestMethod]
        public void TestMethod1()
        {
            var listInt = new LinkedListInd<int>(new int[] { 1, 2, 3 });
            var listStr = new LinkedListInd<string>(new string[] { "a", "b", "c" });

            for(int i=0; i<listInt.Count; i++)
                Console.WriteLine(listInt[i]);

            Console.WriteLine();

            listStr[1] = "x";

            for (int i = 0; i < listStr.Count; i++)
                Console.WriteLine(listStr[i]);

            
        }
    }

    public class LinkedListInd<T> : LinkedList<T>
    {
        public LinkedListInd(T[] init) : base(init) { }

        public T this[int i] //todo exceptions
        {
            get
            {
                var enumerator = GetEnumerator();

                for (int j = 0; j <= i; j++)
                    enumerator.MoveNext();

                return enumerator.Current;
            }

            //not clear how to implement set based on LinkedList, no access to current property...
            //possible use find, but it will work only if there is no same objects in the list
            set
            {
                Find(this[i]).Value = value;
            }
        }
    }
}