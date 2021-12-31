using System.Globalization;
using System.Text;

namespace SupermarketReceipt
{
    public class ReceiptPrinter
    {
        private const int DEFAULT_SPACES = 40;
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");

        private readonly int columnSpaces;


        public ReceiptPrinter(int columnSpaces)
        {
            this.columnSpaces = columnSpaces;
        }

        public ReceiptPrinter() : this(DEFAULT_SPACES)
        {
        }

        public string PrintReceipt(Receipt receipt)
        {
            var result = new StringBuilder();

            appendAllProductItems(receipt, result);
            appendAllDiscounts(receipt, result);
            appendTotalPrice(receipt, result);

            return result.ToString();
        }

        private void appendAllProductItems(Receipt receipt, StringBuilder result)
        {
            foreach (var item in receipt.GetItems())
                result.Append(ReceiptItemTextLine(item));
        }

        private void appendAllDiscounts(Receipt receipt, StringBuilder result)
        {
            foreach (var discount in receipt.GetDiscounts())
                result.Append(DiscountTextLine(discount));
        }
        private void appendTotalPrice(Receipt receipt, StringBuilder result)
        {
            result.Append("\n");
            result.Append(PrintTotal(receipt));
        }

        private string PrintTotal(Receipt receipt)
        {
            return FormatLineWithWhitespace("Total: ", 
                PrintPrice(receipt.GetTotalPrice()));
        }

        private string DiscountTextLine(Discount discount)
        {
            string name = discount.Description + "(" + discount.Product.Name + ")";
            string value = PrintPrice(discount.DiscountAmount);

            return FormatLineWithWhitespace(name, value);
        }

        private string ReceiptItemTextLine(ReceiptItem item)
        {
            string totalPrice = PrintPrice(item.TotalPrice);
            string name = item.Product.Name;
            string line = FormatLineWithWhitespace(name, totalPrice);

            if (item.Quantity != 1)
                line += "  " + PrintPrice(item.Price) + " * " + PrintQuantity(item) + "\n";

            return line;
        }
        
        private string FormatLineWithWhitespace(string name, string value)
        {
            var line = new StringBuilder();
            line.Append(name);
            int whitespaceSize = columnSpaces - name.Length - value.Length;

            for (int i = 0; i < whitespaceSize; i++) 
                line.Append(" ");

            line.Append(value).Append('\n');

            return line.ToString();
        }

        private string PrintPrice(double price)
        {
            return price.ToString("N2", Culture);
        }

        private static string PrintQuantity(ReceiptItem item)
        {
            return ProductUnit.Each == item.Product.Unit
                ? ((int) item.Quantity).ToString()
                : item.Quantity.ToString("N3", Culture);
        }
    }
}