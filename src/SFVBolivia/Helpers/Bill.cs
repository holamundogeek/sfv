using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class Bill
    {
        private int billNumber;
        public int BillNumber { get; set; }

        private long authorization;
        public long Authorization { get; set; }

        private DateTime date;
        public DateTime Date { get; set; }

        private double amount;
        public double Amount { get; set; }

        private double amountFiscalCredit;
        public double AmountFiscalCredit { get; set; }

        private string controlCode;
        public string ControlCode { get; set; }

        private long nITRecep;
        public long NITRecep { get; set; }

        private UserIssuer userIssuer;
        public UserIssuer UserIssuer { get; set; }


        public Bill()
        {
            this.billNumber = 0;
            this.authorization = 0;
            this.date = DateTime.Now.Date;
            this.amount = 0;
            this.amountFiscalCredit = 0;
            this.controlCode = "";
            this.nITRecep = 0;
            this.userIssuer = new UserIssuer();
        }

        public Bill(int billNumber, long authorization, DateTime date, 
            double amount, double amountFiscalCredit, string controlCode, long nITRecep, UserIssuer userIssuer)
        {
            this.billNumber = billNumber;
            this.authorization = authorization;
            this.date = date;
            this.amount = amount;
            this.amountFiscalCredit = amountFiscalCredit;
            this.controlCode = controlCode;
            this.nITRecep = nITRecep;
            this.userIssuer = userIssuer;
        }

        /// <summary>
        /// This method override ToString method in order to concat fields 
        /// that will be needed to generate QRCode Bill.
        /// </summary>
        /// <returns>Bill fields in an specific format</returns>
        public override string ToString()
        {
            return billNumber + "|" + authorization + "|" + date + "|" + amount + "|" + amountFiscalCredit + "|" + controlCode + "|" + nITRecep + "|" + userIssuer;
        }

    }
}
