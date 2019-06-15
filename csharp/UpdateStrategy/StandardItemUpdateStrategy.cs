using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.UpdateStrategy
{
    public class StandardItemUpdateStrategy : IUpdateStrategy
    {
        private Item Item;

        public StandardItemUpdateStrategy(Item item)
        {
            this.Item = item;
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
            Item.SellIn -= 1;
        }

        private bool IsSellByDayValueIsOverZero()
        {
            return Item.SellIn >= 0;
        }

        private void DecreaseQualityBy(int qualityValue)
        {
            Item.Quality -= qualityValue;
        }

        public bool IsQualityValueAboutZero()
        {
            return Item.Quality > 0;
        }

        private int DecreasingValueForZeroOrLessDaysToSell()
        {
            return DecreasingValueOverZeroDaysToSell() * 2;
        }
    }
}
