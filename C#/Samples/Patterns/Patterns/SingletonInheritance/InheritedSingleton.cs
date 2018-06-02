using System;

namespace SingletonInheritance
{
    public class InheritedSingleton : Singleton<InheritedSingleton>
    {
        private InheritedSingleton()
        {
            Console.WriteLine("InheritedSingleton constructor");
        }

        public string AdditionProperty { get; } = "Addition property default value";
    }
}