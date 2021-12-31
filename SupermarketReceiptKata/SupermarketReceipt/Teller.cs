using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class Teller
    {
        private readonly SupermarketCatalog _catalog;
        private readonly Dictionary<Product, Offer> _offers = new Dictionary<Product, Offer>();

        public Teller(SupermarketCatalog catalog)
        {
            _catalog = catalog;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers[product] = new Offer(offerType, product, argument);
        }

        public Receipt ChecksOutArticlesFrom(ShoppingCart theCart)
        {
            Receipt receipt = new Receipt();
            List<ProductQuantity> productQuantities = theCart.GetItems();

            foreach (var pq in productQuantities)
                receipt.AddProduct(pq, _catalog.GetUnitPrice(pq.Product));

            handleOffers(theCart.ProductQuantityPairs(), receipt);

            return receipt;
        }

        private void handleOffers(Dictionary<Product, double> prodQuantities, Receipt receipt)
        {
            foreach(KeyValuePair<Product, double> prodQuant in prodQuantities)
            {
                if (!productHasSpecialOffers(prodQuant.Key))
                    continue;

                Discount discount = OfferType
                    .GetOfferType(_offers[prodQuant.Key].OfferType)
                    .GetDiscount(prodQuant, _catalog, _offers[prodQuant.Key]);

                if (discount != null)
                    receipt.AddDiscount(discount);
            }
        }

        private bool productHasSpecialOffers(Product product)
        {
            return _offers.ContainsKey(product);
        }
    }
}