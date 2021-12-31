using NUnit.Framework;
using System.Collections.Generic;

namespace SupermarketReceipt.Test
{
    [TestFixture]
    public class SupermarketTest
    {
        private SupermarketCatalog catalog;
        private ShoppingCart cart;
        private Teller teller;

        [SetUp]
        public void SetUp()
        {
            catalog = new FakeCatalog();
            cart = new ShoppingCart();
        }

        [Test]
        public void GivenProductWithNoDiscount_WhenCheckOut_ThenReturnTotalProductPrice()
        {
            Product apples = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apples, 1.99);
            cart.AddItemQuantity(apples, 2.5);
            teller = new Teller(catalog);

            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.That(receipt.GetTotalPrice(), Is.EqualTo(4.975));
            Assert.AreEqual(new List<Discount>(), receipt.GetDiscounts());
            Assert.That(receipt.GetItems(), Has.Exactly(1).Items);
            ReceiptItem receiptItem = receipt.GetItems()[0];
            Assert.AreEqual(apples, receiptItem.Product);
            Assert.AreEqual(1.99, receiptItem.Price);
            Assert.AreEqual(2.5 * 1.99, receiptItem.TotalPrice);
            Assert.AreEqual(2.5, receiptItem.Quantity);
        }

        [Test]
        public void GivenProductWithTenPercentDiscount_WhenCheckOut_ThenReduceProductPriceByTenPercent()
        {
            Product toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);
            cart.AddItemQuantity(toothbrush, 2);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.That(receipt.GetTotalPrice(), Is.EqualTo(1.782));
            ReceiptItem receiptItem = receipt.GetItems()[0];
            Assert.AreEqual(toothbrush, receiptItem.Product);
            Assert.AreEqual(0.99, receiptItem.Price);
            Assert.AreEqual(2 * 0.99, receiptItem.TotalPrice);
            Assert.AreEqual(2, receiptItem.Quantity);
        }

        [Test]
        public void GivenProductWithThreeForTwoDiscount_WhenCheckOut_ThenApplyThreeForTwoDiscountToTotalPrice()
        {
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 1);

            cart.AddItemQuantity(toothbrush, 5);

            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, toothbrush, 0.00);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.That(receipt.GetTotalPrice(), Is.EqualTo(4));
            var receiptItem = receipt.GetItems()[0];
            Assert.AreEqual(toothbrush, receiptItem.Product);
            Assert.AreEqual(1, receiptItem.Price);
            Assert.AreEqual(1 * 5, receiptItem.TotalPrice);
            Assert.AreEqual(5, receiptItem.Quantity);
        }

        [Test]
        public void GivenProductWithTwoForAmountDiscount_WhenCheckOut_ThenApplyTwoForAmountDiscount()
        {
            Product toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 2);
            cart.AddItemQuantity(toothbrush, 5);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, toothbrush, 1.00);

            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.That(receipt.GetTotalPrice(), Is.EqualTo(4));
        }

        [Test]
        public void GivenProductWithFiveForAmountDiscount_WhenCheckOut_ThenApplyFiveForAmountDiscount()
        {
            Product toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 1);
            cart.AddItemQuantity(toothbrush, 10);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.FiveForAmount, toothbrush, 1.00);

            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.That(receipt.GetTotalPrice(), Is.EqualTo(2));
        }

        [Test]
        public void GivenCombinationOfDifferentProducts_WhenCheckOut_ThenGetTotalPrice()
        {
            Product apples = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apples, 1);
            Product toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 1);
            Product tv = new Product("tv", ProductUnit.Each);
            catalog.AddProduct(tv, 2);
            Product fridge = new Product("fridge", ProductUnit.Each);
            catalog.AddProduct(fridge, 3);
            Product rice = new Product("rice", ProductUnit.Kilo);
            catalog.AddProduct(rice, 4);

            cart.AddItemQuantity(apples, 5);
            cart.AddItemQuantity(toothbrush, 2);
            cart.AddItemQuantity(tv, 5);
            cart.AddItemQuantity(fridge, 5);
            cart.AddItemQuantity(rice, 10);


            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, tv, 0.00);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, fridge, 1.00);
            teller.AddSpecialOffer(SpecialOfferType.FiveForAmount, toothbrush, 2.00);

            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.That(receipt.GetTotalPrice(), Is.EqualTo(60));
        }

        [Test]
        public void GivenProductWithNoDiscount_WhenPrintReceiptWith_ThenPrintProductPricesOnly()
        {
            Product apples = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apples, 1.99);
            teller = new Teller(catalog);
            cart.AddItemQuantity(apples, 2.5);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("apples     4.97\n  1.99 * 2.500\n\nTotal:     4.97\n"));
        }

        [Test]
        public void GivenProductWithTenPercentDiscount_WhenPrintReceipt_ThenPrintProductPriceAndDiscount()
        {
            Product dog = new Product("dog", ProductUnit.Each);
            catalog.AddProduct(dog, 0.99);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, dog, 10.0);
            cart.AddItemQuantity(dog, 2);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("dog        1.98\n  0.99 * 2\n10% off(dog)-0.20\n\nTotal:     1.78\n"));
        }

        [Test]
        public void GivenProductWithThreeForTwoDiscount_WhenPrintReceipt_ThenPrintProductPriceAndDiscount()
        {
            Product socks = new Product("socks", ProductUnit.Each);
            catalog.AddProduct(socks, 1);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, socks, 0.00);
            cart.AddItemQuantity(socks, 5);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("socks      5.00\n  1.00 * 5\n3 for 2(socks)-1.00\n\nTotal:     4.00\n"));
        }

        [Test]
        public void GivenProductWithThreeForTwoDiscountButLessThanThreeInCart_WhenPrintReceipt_ThenPrintProductPriceOnly()
        {
            Product socks = new Product("socks", ProductUnit.Each);
            catalog.AddProduct(socks, 1);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, socks, 0.00);
            cart.AddItemQuantity(socks, 2);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("socks      2.00\n  1.00 * 2\n\nTotal:     2.00\n"));
        }

        [Test]
        public void GivenProductWithTwoForAmountDiscount_WhenPrintReceipt_ThenPrintProductPriceAndDiscount()
        {
            Product phone = new Product("phone", ProductUnit.Each);
            catalog.AddProduct(phone, 2);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, phone, 1.00);
            cart.AddItemQuantity(phone, 5);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("phone     10.00\n  2.00 * 5\n2 for 1(phone)-6.00\n\nTotal:     4.00\n"));
        }

        [Test]
        public void GivenProductWithTwoForAmountDiscountButLessThanTwoInCart_WhenPrintReceipt_ThenPrintProductPriceOnly()
        {
            Product phone = new Product("phone", ProductUnit.Each);
            catalog.AddProduct(phone, 2);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, phone, 1.00);
            cart.AddItemQuantity(phone, 1);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("phone      2.00\n\nTotal:     2.00\n"));
        }

        [Test]
        public void GivenProductWithFiveForAmountDiscount_WhenPrintReceipt_ThenPrintProductPriceAndDiscount()
        {
            var phone = new Product("phone", ProductUnit.Each);
            catalog.AddProduct(phone, 1);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.FiveForAmount, phone, 1.00);
            cart.AddItemQuantity(phone, 10);
            var receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(15);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("phone     10.00\n  1.00 * 10\n5 for 1(phone)-8.00\n\nTotal:     2.00\n"));
        }

        [Test]
        public void GivenCombinationOfProducts_WhenPrintReceipt_ThenPrintProductsWithAndWithoutDiscounts()
        {
            Product bun = new Product("bun", ProductUnit.Kilo);
            catalog.AddProduct(bun, 1);
            Product bin = new Product("bin", ProductUnit.Each);
            catalog.AddProduct(bin, 1);
            teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, bin, 10.0);
            cart.AddItemQuantity(bun, 5);
            cart.AddItemQuantity(bin, 2);
            Receipt receipt = teller.ChecksOutArticlesFrom(cart);

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(1);

            Assert.That(receiptPrinter.PrintReceipt(receipt),
                Is.EqualTo("bun5.00\n  1.00 * 5.000\nbin2.00\n  1.00 * 2\n10% off(bin)-0.20\n\nTotal: 6.80\n"));
        }
    }
}