using ItemDomain;

namespace ItemImplementation
{
    public class AgedBrie : EditableItem
    {
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
