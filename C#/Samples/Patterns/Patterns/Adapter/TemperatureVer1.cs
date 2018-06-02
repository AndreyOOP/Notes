namespace Adapter
{
    //adaptee 1
    public class TempData
    {
        public double Celsii { get; set; }
        public double Kelvin { get; set; }
        public double Farengeit { get; set; }

        public override string ToString()
        {
            return $"C = {Celsii}, K = {Kelvin}, F = {Farengeit}";
        }
    }

    public enum TemperatureType { C, K, F }

    //adaptee 2
    public class TempCalculator
    {
        public double C { get; private set; }
        public double K { get; private set; }
        public double F { get; private set; }

        public TempCalculator(double t, TemperatureType type)
        {
            if(type == TemperatureType.C)
            {
                C = t;
                K = C + 273.15;
                F = 1.8 * C + 32;
            }
            else 
            if(type == TemperatureType.K)
            {
                K = t;
                C = K - 273.15;
                F = 1.8 * C + 32;
            }
            else
            if (type == TemperatureType.F)
            {
                F = t;
                C = (F - 32) / 1.8;
                K = C + 273.15;
            }
        }

        public override string ToString()
        {
            return $"C = {C}, K = {K}, F = {F}";
        }
    }
}
