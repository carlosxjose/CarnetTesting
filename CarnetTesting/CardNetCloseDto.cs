using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarnetTesting
{
    public class CardNetCloseDto
    {
        public string Status { get; set; }
        public int ClosureQuantity { get; set; }
        public List<Closure> Closures { get; set; }
    }
    public class Closure
    {
        public Closure()
        {
            this.Purchases = new Purchases();
            this.Returns = new Returns();
        }

        public string Status { get; set; }

        public List<string> Messages { get; set; }

        public Result Result { get; set; }

        public string Host { get; set; }

        public short Batch { get; set; } = -1;

        public DateTime DataTime { get; set; } = DateTime.MinValue;

        public int? MerchantID { get; set; }

        public int? TerminalID { get; set; }

        public Purchases Purchases { get; set; }

        public Returns Returns { get; set; }
    }

    public class Purchases
    {
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal OtherTax { get; set; }
    }

    public class Returns
    {
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
    }
}

public enum Result
{
    SuccessfulClosing = 0,
    CloseFail = 1,
    DuplicateBatch = 2,
    EmptyBatch = 10, // 0x0000000A
}