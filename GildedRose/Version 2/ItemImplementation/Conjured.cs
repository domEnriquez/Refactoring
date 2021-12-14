using ItemDomain;

namespace ItemImplementation
{
    public class Conjured : EditableItem
    {
        public static new Conjured Create(string name, int sellIn, int quality)
        {
            return new Conjured()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }

        public override void UpdateQualityAfterADay()
        {
            decrementSellIn();

            if (exceedsSellInDays())
                decrementQualityBy(4);
            else
                decrementQualityBy(2);
        }
    }
}
