using ItemDomain;

namespace ItemImplementation
{
    public class ConcertBackstagePass : EditableItem
    {
        public static new ConcertBackstagePass Create(string concertName, int sellIn, int quality)
        {
            return new ConcertBackstagePass()
            {
                Name = "Backstage passes to a " + concertName + " concert",
                SellIn = sellIn,
                Quality = quality
            };
        }

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
