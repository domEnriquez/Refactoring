using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.DiscountStrategies
{
    public class ThreeForTwoOffer : OfferType
    {
        public override Discount GetDiscount(KeyValuePair<Product, double> productQuantity, 
            SupermarketCatalog catalog, 
            Offer offer)
        {
            Discount discount = null;
            Product product = productQuantity.Key;
            double quantity = productQuantity.Value;
            var quantityAsInt = (int)quantity;

            int numOfX = quantityAsInt / 3;

            if (quantityAsInt > 2)
            {
                var discountAmount = quantity *
                    catalog.GetUnitPrice(product) -
                    (numOfX 
                        * 2 
                        * catalog.GetUnitPrice(product) 
                        + quantityAsInt % 3 
                        * catalog.GetUnitPrice(product));

                discount = new Discount(productQuantity.Key, "3 for 2", -discountAmount);
            }

            return discount;
        }
    }
}
