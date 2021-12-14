using GildedRoseApp;
using ItemDomain;
using ItemImplementation;
using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            CompositeItem items = new CompositeItem();
            items.Add(EditableItem.Create(name: "+5 Dexterity Vest", sellIn: 10, quality: 20));
            items.Add(AgedBrie.Create(sellIn: 2, quality: 0));
            items.Add(EditableItem.Create(name: "Elixir of the Mongoose", sellIn: 5, quality: 7));
            items.Add(Sulfuras.Create(sellIn: 0, quality: 80));
            items.Add(Sulfuras.Create(sellIn: -1, quality: 80));
            items.Add(ConcertBackstagePass.Create(concertName: "TAFKAL80ETC", sellIn: 15, quality: 20));
            items.Add(ConcertBackstagePass.Create(concertName: "TAFKAL80ETC", sellIn: 10, quality: 49));
            items.Add(ConcertBackstagePass.Create(concertName: "TAFKAL80ETC", sellIn: 5, quality: 49));
            items.Add(Conjured.Create(name: "Conjured Mana Cake", sellIn: 3, quality: 6));

            //IList<EditableItem> Items = new List<EditableItem>{
            //    EditableItem.Create(name:"+5 Dexterity Vest", sellIn: 10, quality: 20),
            //    AgedBrie.Create(sellIn: 2, quality: 0),
            //    EditableItem.Create(name: "Elixir of the Mongoose", sellIn: 5, quality: 7),
            //    Sulfuras.Create(sellIn: 0, quality: 80),
            //    Sulfuras.Create(sellIn: -1, quality: 80), 
            //    ConcertBackstagePass.Create(concertName: "TAFKAL80ETC", sellIn: 15, quality: 20),
            //    ConcertBackstagePass.Create(concertName: "TAFKAL80ETC", sellIn: 10, quality: 49),
            //    ConcertBackstagePass.Create(concertName: "TAFKAL80ETC", sellIn: 5, quality: 49),
            //    Conjured.Create(name: "Conjured Mana Cake", sellIn: 3, quality: 6)
            //};

            GildedRose app = new GildedRose(items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                items.DisplayItems();
                //for (var j = 0; j < Items.Count; j++)
                //    Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);

                app.UpdateItemsQualityAfterADay();
            }
        }
    }
}
