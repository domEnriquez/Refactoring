using ItemDomain;

namespace ItemImplementation
{
    public class AgedBrie : EditableItem
    {
        public static AgedBrie Create(int sellIn, int quality)
        {
            return new AgedBrie()
            {
                Name = "Aged Brie",
                SellIn = sellIn,
                Quality = quality
            };
        } 

        public override void UpdateQualityAfterADay()
        {
            decrementSellIn();

            if (exceedsSellInDays())
                incrementQualityBy(2);
            else
                incrementQualityBy(1);
        }
    }
}
