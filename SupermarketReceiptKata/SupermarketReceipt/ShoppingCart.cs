using SupermarketReceipt.DiscountStrategies;
using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();

        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
        }

        public Dictionary<Product, double> ProductQuantityPairs()
        {
            Dictionary<Product, double> productQuantities = 
                new Dictionary<Product, double>();

            foreach(ProductQuantity prodQuant in _items)
            {
                Product product = prodQuant.Product;
                double quantity = prodQuant.Quantity;

                if (productQuantities.ContainsKey(product))
                    productQuantities[product] = 
                        productQuantities[product] + quantity;
                else
                    productQuantities.Add(product, quantity);
            }

            return productQuantities;
        }
    }
}