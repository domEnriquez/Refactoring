using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.DiscountStrategies
{
    public class FiveForAmount : OfferType
    {
        public override Discount GetDiscount(KeyValuePair<Product, double> productQuantity, 
            SupermarketCatalog catalog, 
            Offer offer)
        {
            Discount discount = null;
            double quantity = productQuantity.Value;
            Product product = productQuantity.Key;

            if ((int)quantity >= 5)
            {
                int numOfX = (int)quantity / 5;

                var discountTotal = catalog.GetUnitPrice(product)
                    * quantity
                    - (offer.Argument 
                        * numOfX 
                        + (int)quantity
                        % 5 
                        * catalog.GetUnitPrice(product));

                discount = new Discount(product, 
                    5 + " for " + offer.Argument, 
                    -discountTotal);
            }

            return discount;
        }
    }
}
