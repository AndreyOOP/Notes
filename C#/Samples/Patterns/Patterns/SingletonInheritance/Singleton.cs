using System;

namespace SingletonInheritance
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine($"Instance property of type {typeof(T)} is null - initialize instance");

                    //inherited class has to use private constructor
                    //line below create class instance even if constructor is private
                    instance = (T)Activator.CreateInstance(typeof(T), true);
                }

                return instance;
            }
        }

        public string BaseProperty { get; } = "Base property default value";
    }
}
