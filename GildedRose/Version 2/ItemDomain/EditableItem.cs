using System;

namespace ItemDomain
{
    public class EditableItem : Item
    {
        private const int MAX_QUALITY = 50;

        public static EditableItem Create(string name, int sellIn, int quality)
        {
            return new EditableItem()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }

        public virtual void UpdateQualityAfterADay()
        {
            decrementSellIn();

            if (exceedsSellInDays())
                decrementQualityBy(2);
            else
                decrementQualityBy(1);
        }

        protected virtual void decrementSellIn()
        {
            SellIn--;
        }

        public virtual void ValidateInitialQuality()
        {
            if (Quality > MAX_QUALITY)
                throw new QualityExceededLimitException();
        }

        protected void reduceQualityToZero()
        {
            Quality = 0;
        }

        protected bool exceedsSellInDays()
        {
            return SellIn < 0;
        }

        protected void decrementQualityBy(int num)
        {
            if (hasQualityLeft())
                Quality = Quality - num;

            if (Quality < 0)
                reduceQualityToZero();
        }

        protected bool hasQualityLeft()
        {
            return Quality > 0;
        }

        protected void incrementQualityBy(int num)
        {
            if (belowMaxQuality())
                Quality = Quality + num;

            if (!belowMaxQuality())
                Quality = MAX_QUALITY;

        }

        protected bool belowMaxQuality()
        {
            return Quality < MAX_QUALITY;
        }

        public class QualityExceededLimitException : ApplicationException
        {

        }
    }
}
