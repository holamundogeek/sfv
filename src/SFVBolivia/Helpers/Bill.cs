using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class Bill
    {
        public int BillNumber { get; set; }
        public long Authorization;
        public DateTime Date;
        public double Amount;
        public double AmountFiscalCredit;
        public string ControlCode;
        public long NITRecep;
        public UserIssuer UserIssuer;

            
            public int MyProperty { get; set; }

        public Bill()
        {
            this.BillNumber = 0;
            this.Authorization = 0;
            this.Date = DateTime.Now.Date;
            this.Amount = 0;
            this.AmountFiscalCredit = 0;
            this.ControlCode = "";
            this.NITRecep = 0;
            this.UserIssuer = new UserIssuer();
        }

        public Bill(int billNumber, long authorization, DateTime date, 
            double amount, double amountFiscalCredit, string controlCode, long nITRecep, UserIssuer userIssuer)
        {
            this.BillNumber = billNumber;
            this.Authorization = authorization;
            this.Date = date;
            this.Amount = amount;
            this.AmountFiscalCredit = amountFiscalCredit;
            this.ControlCode = controlCode;
            this.NITRecep = nITRecep;
            this.UserIssuer = userIssuer;
        }

        public override string ToString()
        {
            return BillNumber + "|" + Authorization + "|" + Date + "|" + Amount + "|" + AmountFiscalCredit + "|" + ControlCode + "|" + NITRecep + "|" + UserIssuer;
        }

    }
}
