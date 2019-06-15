using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class CustomisedItemFactory
    {
        Dictionary<string, ICustomisedItem> ITEM_TYPES_LIST = new Dictionary<string, ICustomisedItem>();

        public static string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public static string AGED_BRIE = "Aged Brie";
        public static string BACKTAGE_PASSES_ITEM = "Backstage passes to a TAFKAL80ETC concert";
        public static string CONJURED_ITEM = "Conjured Mana Cake";

        public CustomisedItemFactory(Item item)
        {
            ITEM_TYPES_LIST[SULFURAS] = new Sulfuras();
            ITEM_TYPES_LIST[AGED_BRIE] = new AgedBrie(item);
            ITEM_TYPES_LIST[BACKTAGE_PASSES_ITEM] = new BackstagePassesItem(item);
            ITEM_TYPES_LIST[CONJURED_ITEM] = new BackstagePassesItem(item);
            ITEM_TYPES_LIST[CONJURED_ITEM]= new ConjuredItem(item);
        }

        public ICustomisedItem CustomiseItem(Item item)
        {
            if (IsStandardItem(item))
            {
                return new StandardItem(item);
            }
            return ITEM_TYPES_LIST[item.Name];
        }

        private bool IsStandardItem(Item item)
        {
            return !ITEM_TYPES_LIST.Keys.Contains(item.Name);
        }
    }
}
