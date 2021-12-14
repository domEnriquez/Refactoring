using ItemDomain;

namespace ItemImplementation
{
    public class Sulfuras : EditableItem
    {
        public static Sulfuras Create(int sellIn, int quality)
        {
            return new Sulfuras()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = sellIn,
                Quality = quality
            };
        } 

        protected override void decrementSellIn()
        {
            //do nothing
        }

        public override void UpdateQualityAfterADay()
        {
            //do nothing
        }

        public override void ValidateInitialQuality()
        {
            //do nothing
        }

    }
}
