using csharp.UpdateStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class UpdateStrategyFactory : IUpdateStrategyFactory
    {
        Dictionary<string, IUpdateStrategy> ITEM_TYPES_LIST = new Dictionary<string, IUpdateStrategy>();

        public static string SULFURA = "Sulfuras, Hand of Ragnaros";
        public static string AGED_BRIE = "Aged Brie";
        public static string BACKTAGE_PASSES_ITEM = "Backstage passes to a TAFKAL80ETC concert";
        public static string CONJURED_ITEM = "Conjured Mana Cake";

        public UpdateStrategyFactory(Item item)
        {
            ITEM_TYPES_LIST[SULFURA] = new SulfurasUpdateStrategy();
            ITEM_TYPES_LIST[AGED_BRIE] = new AgedBrieUpdateStrategy(item);
            ITEM_TYPES_LIST[BACKTAGE_PASSES_ITEM] = new BackstagePassesItem(item);
            ITEM_TYPES_LIST[CONJURED_ITEM] = new BackstagePassesItem(item);
            ITEM_TYPES_LIST[CONJURED_ITEM]= new ConjuredItem(item);
        }

        public UpdateStrategyFactory()
        {
            
        }

        public IUpdateStrategy Create(Item item)
        {
            if (IsStandardItem(item))
            {
                return new StandardItemUpdateStrategy(item);
            }
            return ITEM_TYPES_LIST[item.Name];
        }

        private bool IsStandardItem(Item item)
        {
            return !ITEM_TYPES_LIST.Keys.Contains(item.Name);
        }

      
    }
}
