using ItemDomain;

namespace ItemImplementation
{
    public class Conjured : EditableItem
    {
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
