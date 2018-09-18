using ItemDomain;

namespace ItemImplementation
{
    public class ConcertBackstagePass : EditableItem
    {
        public override void UpdateQualityAfterADay()
        {
            decrementSellIn();
            if (exceedsSellInDays())
            {
                reduceQualityToZero();
            }
            else
            {
                updateConcertPassQuality();
            }
        }

        private void updateConcertPassQuality()
        {
            if (SellIn < 5)
                incrementQualityBy(3);
            else if (SellIn >= 5 && SellIn < 10)
                incrementQualityBy(2);
            else
                incrementQualityBy(1);
        }
    }
}
