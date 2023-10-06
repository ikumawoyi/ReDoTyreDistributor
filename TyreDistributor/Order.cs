using System.Collections.Generic;
namespace TyreDistributor
{
    public class Order
    {
        public readonly IList<Line> _lines = new List<Line>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt()
        {
            var receipt = string.Empty;
            var formater = new List<RecieptFactory>
            {
                new TextReceiptFactory()
            };
            foreach (var item in formater)
            {
                receipt = item.FormatRecieptService().FormatReceipt(Company, _lines);
            }
            return receipt;
        }

        public string HtmlReceipt()
        {
            var receipt = string.Empty;
            var formater = new List<RecieptFactory>
            {
                new HtmlReceiptFactory()
            };
            foreach (var item in formater)
            {
                receipt = item.FormatRecieptService().FormatReceipt(Company, _lines);
            }
            return receipt;
        }
    }
}