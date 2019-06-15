using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TareaTest
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void footest()
        {
            IList<Item> Items = new List<Item>();
            var item = new Item();
            item.Name = "foo";
            item.SellIn = 0;
            item.Quality = 0;
            Items.Add(item);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [TestMethod]
        public void ThirtyDays()
        {
            var lines = File.ReadAllLines("ThirtyDays.txt");

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            String output = fakeoutput.ToString();

            var outputLines = output.Split('\n');
            for (var i = 0; i < Math.Min(lines.Length, outputLines.Length); i++)
            {
                //Assert.AreEqual(lines[i], outputLines[i]);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void standardItemDecreasesSellByDayNumberEachTime()
        {
            GildedRose app = new GildedRose("standard item", 0, 0);

            app.UpdateQuality();

            Assert.Equals(-1, itemSellByDayNumber(app));
        }

        private GildedRose newGildedRose(String itemName, int itemSellIn, int itemQuality)
        {
            Item[] items = new Item[] { new Item(itemName, itemSellIn, itemQuality) };
            return new GildedRose(items);
        }

        private int itemSellByDayNumber(GildedRose app)
        {
            return app.items[0].SellIn;
        }

        private int itemQualityValue(GildedRose app)
        {
            return app.items[0].Quality;
        }
    }
}
