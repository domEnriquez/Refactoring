using ItemDomain;
using System;
using System.Collections.Generic;

namespace GildedRoseApp
{
    public class GildedRose
    {
        IList<EditableItem> Items;


        public GildedRose(IList<EditableItem> Items)
        {
            validateItems(Items);
            this.Items = Items;
        }

        private void validateItems(IList<EditableItem> items)
        {
            for (int i = 0; i < items.Count; i++)
                items[i].ValidateInitialQuality();
        }

        public void UpdateItemsQualityAfterADay()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].UpdateQualityAfterADay();
            }
        }
    }
}
