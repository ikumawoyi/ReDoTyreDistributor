using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TyreDistributor
{
	public abstract class FormatService
    {
		public abstract double totalAmount { get; }
		public abstract double thisAmount { get; }
        public abstract string FormatReceipt(string company, IList<Line> _lines);

        public static double GetAmount(Line line)
        {
            var thisAmount = 0d;
            switch (line.Tyre.Model)
            {
                case Tyre.Suv:
                    if (line.Quantity >= 20)
                        thisAmount += line.Quantity * line.Tyre.Price * .9d;
                    else
                        thisAmount += line.Quantity * line.Tyre.Price;
                    break;

                case Tyre.Mini:
                    if (line.Quantity >= 10)
                        thisAmount += line.Quantity * line.Tyre.Price * .8d;
                    else
                        thisAmount += line.Quantity * line.Tyre.Price;
                    break;

                case Tyre.Estate:
                    if (line.Quantity >= 5)
                        thisAmount += line.Quantity * line.Tyre.Price * .8d;
                    else
                        thisAmount += line.Quantity * line.Tyre.Price;
                    break;
            }

            return thisAmount;
        }
    }

    public class TextReceiptService : FormatService
    {
        private double _totalAmount;
        private double _thisAmount;
        private const double TaxRate = .0725d;

        public TextReceiptService()
        {
            _totalAmount = 0d;
            _thisAmount = 0d;
        }
		public override double thisAmount => _thisAmount;
		public override double totalAmount => _totalAmount;

        public override string FormatReceipt(string company, IList<Line> _lines)
        {
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", company, Environment.NewLine));
                foreach (var line in _lines)
                {
                    _thisAmount = GetAmount(line);
                    result.AppendLine(string.Format("{0} x {1} {2} = {3}", line.Quantity, line.Tyre.Brand, line.Tyre.Model, _thisAmount.ToString("C")));
                    _totalAmount += _thisAmount;
                }
                result.AppendLine(string.Format("Sub-Total: {0}", _totalAmount.ToString("C")));
                var tax = _totalAmount * TaxRate;
                result.AppendLine(string.Format("Tax: {0}", tax.ToString("C")));
                result.Append(string.Format("Total: {0}", (_totalAmount + tax).ToString("C")));
                return result.ToString().Replace(Environment.NewLine, "\n");
        }
    }

    public abstract class RecieptFactory
    {
        public abstract FormatService FormatRecieptService();
    }

    public class TextReceiptFactory : RecieptFactory
    {
        public override FormatService FormatRecieptService()
        {
            return new TextReceiptService();
        }
    }


    public class HtmlReceiptService : FormatService
    {
        private double _totalAmount;
        private double _thisAmount;
        private const double TaxRate = .0725d;

        public HtmlReceiptService()
        {
            _totalAmount = 0d;
            _thisAmount = 0d;
        }
        public override double thisAmount => _thisAmount;
        public override double totalAmount => _totalAmount;

        public override string FormatReceipt(string company, IList<Line> _lines)
        {
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", company, Environment.NewLine));
                if (_lines.Any())
                {
                    result.Append("<ul>");
                    foreach (var line in _lines)
                    {
                    _thisAmount = GetAmount(line);
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Tyre.Brand, line.Tyre.Model, _thisAmount.ToString("C")));
                        _totalAmount += _thisAmount;
                    }
                    result.Append("</ul>");
                }
                result.Append(string.Format("<h3>Sub-Total: {0}</h3>", _totalAmount.ToString("C")));
                var tax = _totalAmount * TaxRate;
                result.Append(string.Format("<h3>Tax: {0}</h3>", tax.ToString("C")));
                result.Append(string.Format("<h2>Total: {0}</h2>", (_totalAmount + tax).ToString("C")));
                result.Append("</body></html>");
                return result.ToString();
            }
    }

    public class HtmlReceiptFactory : RecieptFactory
    {
        public override FormatService FormatRecieptService()
        {
            return new HtmlReceiptService();
        }
    }

}
