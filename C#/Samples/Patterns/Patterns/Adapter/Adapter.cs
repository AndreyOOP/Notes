using System;

namespace Adapter
{
    public class Adapter : ITemperature
    {
        private object temperatureProvider;

        public Adapter(object temperatureProvider)
        {
            this.temperatureProvider = temperatureProvider;
        }

        public double GetTemperature(TemperatureType type)
        {
            if(temperatureProvider.GetType() == typeof(TempData))
            {
                var temp = (TempData)temperatureProvider;

                switch (type)
                {
                    case TemperatureType.C: return temp.Celsii;
                    case TemperatureType.K: return temp.Kelvin;
                    case TemperatureType.F: return temp.Farengeit;                            
                }
            }

            if (temperatureProvider.GetType() == typeof(TempCalculator))
            {
                var temp = (TempCalculator)temperatureProvider;

                switch (type)
                {
                    case TemperatureType.C: return temp.C;
                    case TemperatureType.K: return temp.K;
                    case TemperatureType.F: return temp.F;
                }
            }

            throw new NotImplementedException();
        }
    }
}
