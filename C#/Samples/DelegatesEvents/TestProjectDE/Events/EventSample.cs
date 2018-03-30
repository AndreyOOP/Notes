using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Events
{
    [TestClass]
    public class EventSample
    {
        [TestMethod]
        public void TestEvents() //Event listener class
        {
            var stock = new Stock();

            stock.PriceIncrease += ImplPriceIncrease;
            stock.PriceDecrease += ImplPriceDecrease;
            stock.PriceIsZero   += ImplPriceIsZero;

            var stockUser = new StockUser(stock);

            stock.Price = 1;
            stock.Price = 1;
            stock.Price = 0;
            stock.Price = 10;
            stock.Price = 8;
        }

        static void ImplPriceIncrease(object sender, EventArgs e)
        {
            Console.WriteLine("Price Increased Action");
        }

        static void ImplPriceDecrease(object sender, EventArgs e)
        {
            Console.WriteLine("Price Decreased Action");
        }

        static void ImplPriceIsZero(object sender, EventArgs e)
        {
            Console.WriteLine("Price Is Zero Action");
        }
    }

    public class StockUser
    {
        Stock stock;

        public StockUser(Stock stock)
        {
            this.stock = stock;
            this.stock.PriceIsZero += ImplPriceIsZero;
        }

        private void ImplPriceIsZero(object sender, EventArgs e)
        {
            Console.WriteLine("StockUser listener if price is zero");
        }
    }

    public class Stock //Event broadcast during price set
    {
        private int price;

        public event EventHandler PriceIncrease;
        public event EventHandler PriceDecrease;
        public event EventHandler PriceIsZero;

        public int Price
        {
            get { return price;}

            set
            {
                if (price == value) return;

                OnPriceChanged(price, value, EventArgs.Empty);

                price = value;
            }
        }

        private void OnPriceChanged(int price, int value, EventArgs args)
        {
            if (value == 0)
            {
                PriceIsZero?.Invoke(this, args);
            }
            else if (value > price)
            {
                PriceIncrease?.Invoke(this, args);
            }
            else if (value < price)
            {
                PriceDecrease?.Invoke(this, args);
            }
        }
    }
}
