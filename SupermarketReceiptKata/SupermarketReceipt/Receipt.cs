using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class Receipt
    {
        private readonly List<Discount> _discounts = new List<Discount>();
        private readonly List<ReceiptItem> _items = new List<ReceiptItem>();

        public double GetTotalPrice()
        {
            var total = 0.0;
            foreach (var item in _items) total += item.TotalPrice;
            foreach (var discount in _discounts) total += discount.DiscountAmount;
            return total;
        }

        public void AddProduct(ProductQuantity prodQuant, double unitPrice)
        {
            _items.Add(new ReceiptItem(prodQuant, unitPrice));
        }

        public List<ReceiptItem> GetItems()
        {
            return new List<ReceiptItem>(_items);
        }

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
        }

        public List<Discount> GetDiscounts()
        {
            return _discounts;
        }
    }
}