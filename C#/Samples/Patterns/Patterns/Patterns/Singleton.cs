using System;

namespace Patterns
{
    public class Singleton
    {
        private static Singleton instance;

        private Singleton()
        {
            Console.WriteLine("Constructor: Singleton instance creation");
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();

                return instance;
            }
        }

        public string SizeX { get; protected set; } = "x_default";
        public string SizeY { get; protected set; } = "y_default";

        public void Load(string X, string Y)
        {
            SizeX = X;
            SizeY = Y;
        }

        public void Display()
        {
            Console.WriteLine($"Current configuration is - size x = {SizeX}; size y = {SizeY}");
        }
    }
}
