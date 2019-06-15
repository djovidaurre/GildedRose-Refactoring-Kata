using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public static int LOWEST_QUALITY_VALUE_POSSIBLE = 0;

        IList<Item> items;

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                CustomisedItem(item).UpdateState();

                if (IsReachedLowestQualityValue(item))
                {
                    item.Quality = LOWEST_QUALITY_VALUE_POSSIBLE;
                }
                else if (IsReachedHighestQualityValue(item))
                {
                    item.Quality = QualityValues.HighestValuePossible(item);
                }
            }
        }


        private IUpdateStrategy CustomisedItem(Item item)
        {
            return new UpdateStrategyFactory(item).Create(item);
        }

        private bool IsReachedLowestQualityValue(Item item)
        {
            return item.Quality < LOWEST_QUALITY_VALUE_POSSIBLE;
        }

        private bool IsReachedHighestQualityValue(Item item)
        {
            return item.Quality > QualityValues.HighestValuePossible(item);
        }

    }
}
