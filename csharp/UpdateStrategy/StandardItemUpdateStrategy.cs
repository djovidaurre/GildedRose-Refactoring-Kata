using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.UpdateStrategy
{
    public class StandardItemUpdateStrategy : IUpdateStrategy
    {
        private Item item;

        public StandardItemUpdateStrategy(Item item)
        {
            this.item = item;
        }

        public void UpdateState()
        {
            DecreaseSellByDayValueByOne();

            if (IsSellByDayValueIsOverZero() && IsQualityValueAboutZero())
            {
                DecreaseQualityBy(DecreasingValueOverZeroDaysToSell());
            }
            else
            {
                DecreaseQualityBy(DecreasingValueForZeroOrLessDaysToSell());                
            }
        }

        public virtual int DecreasingValueOverZeroDaysToSell()
        {
            return 1;
        }

        private void DecreaseSellByDayValueByOne()
        {
            item.SellIn -= 1;
        }

        private bool IsSellByDayValueIsOverZero()
        {
            return item.SellIn >= 0;
        }

        private void DecreaseQualityBy(int qualityValue)
        {
            item.Quality -= qualityValue;
        }

        public bool IsQualityValueAboutZero()
        {
            return  item.Quality > 0;
        }

        private int DecreasingValueForZeroOrLessDaysToSell()
        {
            return DecreasingValueOverZeroDaysToSell() * 2;
        }
    }
}
