namespace TyreDistributor.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrderTest
    {
        private static readonly Tyre AlfaRomeo = new Tyre("Alfa Romeo", Tyre.Suv, 100);
        private static readonly Tyre BmwMini = new Tyre("BMW", Tyre.Mini, 200);
        private static readonly Tyre BmwEstate = new Tyre("BMW", Tyre.Estate, 500);

        [TestMethod]
        public void ReceiptOneAlfaRomeo()
        {
            var order = new Order("Anywhere Tyre Shop");
            order.AddLine(new Line(AlfaRomeo, 1));
            Assert.AreEqual(ResultStatementOneAlfa, order.Receipt());
        }

        private const string ResultStatementOneAlfa = @"Order Receipt for Anywhere Tyre Shop
1 x Alfa Romeo Sports Utility Vehicle = £100.00
Sub-Total: £100.00
Tax: £7.25
Total: £107.25";

        [TestMethod]
        public void ReceiptOneBmw1()
        {
            var order = new Order("Anywhere Tyre Shop");
            order.AddLine(new Line(BmwMini, 1));
            Assert.AreEqual(ResultStatementOneBmw, order.Receipt());
        }

        private const string ResultStatementOneBmw = @"Order Receipt for Anywhere Tyre Shop
1 x BMW Mini = £200.00
Sub-Total: £200.00
Tax: £14.50
Total: £214.50";

        [TestMethod]
        public void ReceiptOneBmwX()
        {
            var order = new Order("Anywhere Tyre Shop");
            order.AddLine(new Line(BmwEstate, 1));
            Assert.AreEqual(ResultStatementOneBmwEstate, order.Receipt());
        }

        private const string ResultStatementOneBmwEstate = @"Order Receipt for Anywhere Tyre Shop
1 x BMW Estate = £500.00
Sub-Total: £500.00
Tax: £36.25
Total: £536.25";

        [TestMethod]
        public void HtmlReceiptOneAlfaRomeoSportWagon()
        {
            var order = new Order("Anywhere Tyre Shop");
            order.AddLine(new Line(AlfaRomeo, 1));
            Assert.AreEqual(HtmlResultStatementOneAlfaRomeoSportWagon, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneAlfaRomeoSportWagon = @"<html><body><h1>Order Receipt for Anywhere Tyre Shop</h1><ul><li>1 x Alfa Romeo Sports Utility Vehicle = £100.00</li></ul><h3>Sub-Total: £100.00</h3><h3>Tax: £7.25</h3><h2>Total: £107.25</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneBmwMiniSeries()
        {
            var order = new Order("Anywhere Tyre Shop");
            order.AddLine(new Line(BmwMini, 1));
            Assert.AreEqual(HtmlResultStatementOneBmw1Series, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneBmw1Series = @"<html><body><h1>Order Receipt for Anywhere Tyre Shop</h1><ul><li>1 x BMW Mini = £200.00</li></ul><h3>Sub-Total: £200.00</h3><h3>Tax: £14.50</h3><h2>Total: £214.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneBmwEstate()
        {
            var order = new Order("Anywhere Tyre Shop");
            order.AddLine(new Line(BmwEstate, 1));
            Assert.AreEqual(HtmlResultStatementOneBmwX5, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneBmwX5 = @"<html><body><h1>Order Receipt for Anywhere Tyre Shop</h1><ul><li>1 x BMW Estate = £500.00</li></ul><h3>Sub-Total: £500.00</h3><h3>Tax: £36.25</h3><h2>Total: £536.25</h2></body></html>";
    }
}