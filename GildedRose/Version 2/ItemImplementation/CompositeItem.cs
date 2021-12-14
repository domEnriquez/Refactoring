using ItemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemImplementation
{
    public class CompositeItem : EditableItem
    {
        List<EditableItem> items;

        public CompositeItem()
        {
            items = new List<EditableItem>();
        }

        public void Add(EditableItem item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public override void UpdateQualityAfterADay()
        {
            foreach(EditableItem item in items)
                item.UpdateQualityAfterADay();
        }

        public override void ValidateInitialQuality()
        {
            foreach(EditableItem item in items)
                item.ValidateInitialQuality();
        }

        public void DisplayItems()
        {
            for (var j = 0; j < items.Count; j++)
                Console.WriteLine(items[j].Name + ", " + 
                    items[j].SellIn + ", " + 
                    items[j].Quality);
        }
    }
}
