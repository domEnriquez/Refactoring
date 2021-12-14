using ItemDomain;
using System;
using System.Collections.Generic;

namespace GildedRoseApp
{
    public class GildedRose
    {
        public EditableItem Item { get; set; }

        public GildedRose(EditableItem item)
        {
            validateItems(item);
            Item = item;
        }

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

        private void validateItems(EditableItem item)
        {
            item.ValidateInitialQuality();
        }

        public void UpdateItemsQualityAfterADay()
        {
            Item.UpdateQualityAfterADay();
        }
    }
}
