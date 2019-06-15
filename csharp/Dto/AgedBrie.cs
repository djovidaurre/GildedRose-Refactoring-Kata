using csharp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Dto
{
    public class AgedBrie : ICustomisedItem
    {
        private Item item;

        public AgedBrie(Item item)
        {
            this.item = item;
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
            item.SellIn -= 1;
        }

        private void IncreaseQualityByOne()
        {
            item.Quality += 1;
        }
        private bool IsSellInUnderZero()
        {
            return item.SellIn<0;
        }

        private bool IsUnderHighestQualityValue()
        {
            return item.Quality < 50;

        }

    }
}
