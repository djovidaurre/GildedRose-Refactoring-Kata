using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.UpdateStrategy
{
    public class BackstagePassesItem :IUpdateStrategy
    {
        Item Item;

        public BackstagePassesItem(Item item)
        {
            this.Item = item;
        }

        public void UpdateState()
        {
            DecreaseSellByDayValueByOne();

            if (IsSellByDayValueIsOver(10))
            {
                IncreaseQualityBy(1);
            }
            else if (IsSellByDayValueIsOver(5))
            {
                IncreaseQualityBy(2);
            }
            else if (IsSellByDayValueIsOver(0))
            {
                IncreaseQualityBy(3);
            }
            else
            {
                DropQualityToZero();
            }
        }

        private void DecreaseSellByDayValueByOne()
        {
            Item.SellIn -= 1;
        }

        private bool IsSellByDayValueIsOver(int dayNumber)
        {
            return Item.SellIn >= dayNumber;
        }

        private void IncreaseQualityBy(int qualityValue)
        {
            Item.Quality += qualityValue;
        }

        private void DropQualityToZero()
        {
            Item.Quality = 0;
        }
    }
}
