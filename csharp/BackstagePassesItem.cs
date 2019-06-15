using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class BackstagePassesItem :ICustomisedItem
    {
        Item item;

        public BackstagePassesItem(Item item)
        {
            this.item = item;
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
            item.SellIn -= 1;
        }

        private bool IsSellByDayValueIsOver(int dayNumber)
        {
            return item.SellIn >= dayNumber;
        }

        private void IncreaseQualityBy(int qualityValue)
        {
            item.Quality += qualityValue;
        }

        private void DropQualityToZero()
        {
            item.Quality = 0;
        }
    }
}
