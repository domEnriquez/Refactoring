using SupermarketReceipt.DiscountStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt
{
    public abstract class OfferType
    {
        public static OfferType GetOfferType(SpecialOfferType type)
        {
            if (type == SpecialOfferType.ThreeForTwo)
                return new ThreeForTwoOffer();
            else if (type == SpecialOfferType.FiveForAmount)
                return new FiveForAmount();
            else if (type == SpecialOfferType.TenPercentDiscount)
                return new TenPercentDiscountOffer();
            else if (type == SpecialOfferType.TwoForAmount)
                return new TwoForAmountDiscount();
            else
                throw new Exception();
        }

        public abstract Discount GetDiscount(KeyValuePair<Product, double> productQuantity,
            SupermarketCatalog catalog,
            Offer offer);
    }
}
