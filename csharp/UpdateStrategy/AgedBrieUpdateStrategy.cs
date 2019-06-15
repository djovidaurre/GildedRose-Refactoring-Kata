using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.UpdateStrategy
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        Item Item;

        public AgedBrieUpdateStrategy(Item item)
        {
            this.Item = item;
        }

        public void UpdateState()
        {
            DecreaseSellByDayValueByOne();

            IncreaseQualityByOne();

            if (IsSellInUnderZero() && IsUnderHighestQualityValue())
            {
                IncreaseQualityByOne();
            }
        }

        private void DecreaseSellByDayValueByOne()
        {
            Item.SellIn -= 1;
        }

        private void IncreaseQualityByOne()
        {
            Item.Quality += 1;
        }
        private bool IsSellInUnderZero()
        {
            return Item.SellIn< 0;
        }

        private bool IsUnderHighestQualityValue()
        {
            return Item.Quality < 50;

        }

    }
}
