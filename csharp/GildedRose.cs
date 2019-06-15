using csharp.Dto;
using csharp.Interface;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        #region Attributes

        public static int LOWEST_QUALITY_VALUE_POSSIBLE = 0;

        IList<Item> items;

        #endregion

        #region Builder

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        #endregion

        #region Public Method
        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                customisedItem(item).UpdateState();
                if (hasReachedLowestQualityValue(item))
                {
                    item.Quality = LOWEST_QUALITY_VALUE_POSSIBLE;
                }
                else if (hasReachedHighestQualityValue(item))
                {
                    item.Quality = QualityValues.HighestValuePossible(item);
                }
            }
        }


        //public void UpdateQuality()
        //{
        //    foreach (Item item in Items)
        //    {
        //        if (!item.Name.Equals("Aged Brie") && !item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
        //        {
        //            if (item.Quality > 0)
        //            {
        //                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
        //                {
        //                    item.Quality = item.Quality - 1;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (IsUnderHighestQualityValue(item))
        //            {
        //                item.Quality = item.Quality + 1;

        //                if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
        //                {
        //                    if (item.SellIn < 11)
        //                    {
        //                        if (IsUnderHighestQualityValue(item))
        //                        {
        //                            item.Quality = item.Quality + 1;
        //                        }
        //                    }

        //                    if (item.SellIn < 6)
        //                    {
        //                        if (IsUnderHighestQualityValue(item))
        //                        {
        //                            item.Quality = item.Quality + 1;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
        //        {
        //            item.SellIn = item.SellIn - 1;
        //        }

        //        if (item.SellIn < 0)
        //        {
        //            if (!item.Name.Equals("Aged Brie"))
        //            {
        //                if (!item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
        //                {
        //                    if (item.Quality > 0)
        //                    {
        //                        if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
        //                        {
        //                            item.Quality = item.Quality - 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    item.Quality = item.Quality - item.Quality;
        //                }
        //            }
        //            else
        //            {
        //                if (IsUnderHighestQualityValue(item))
        //                {
        //                    item.Quality = item.Quality + 1;
        //                }
        //            }
        //        }
        //    }

        //}

        #endregion

        #region Private Method}

        private ICustomisedItem customisedItem(Item item)
        {
            return new CustomisedItemFactory(item).CustomiseItem(item);
        }

        private bool hasReachedLowestQualityValue(Item item)
        {
            return item.Quality < LOWEST_QUALITY_VALUE_POSSIBLE;
        }

        private bool hasReachedHighestQualityValue(Item item)
        {
            return item.Quality > QualityValues.HighestValuePossible(item);
        }

        //private bool IsUnderHighestQualityValue(Item item)
        //{
        //    return item.Quality < 50;

        //}

        #endregion
    }
}
