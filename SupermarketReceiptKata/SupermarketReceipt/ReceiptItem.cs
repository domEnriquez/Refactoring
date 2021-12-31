namespace SupermarketReceipt
{
    public class ReceiptItem
    {
        public ReceiptItem(ProductQuantity prodQuant, double unitPrice)
        {
            Product = prodQuant.Product;
            Quantity = prodQuant.Quantity;
            Price = unitPrice;
            TotalPrice = Quantity * Price;
        }

        public Product Product { get; }
        public double Price { get; }
        public double TotalPrice { get; }
        public double Quantity { get; }
    }
}