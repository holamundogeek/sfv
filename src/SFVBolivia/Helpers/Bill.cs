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

        public long Authorization { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public double AmountFiscalCredit { get; set; }

        public string ControlCode { get; set; }

        public long NITRecep { get; set; }

        public UserIssuer UserIssuer { get; set; }



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

        /// <summary>
        /// This method override ToString method in order to concat fields 
        /// that will be needed to generate QRCode Bill.
        /// </summary>
        /// <returns>Bill fields in an specific format</returns>
        public override string ToString()
        {
            return $"{this.BillNumber}|{this.BillNumber}|{this.Date}|{this.Amount}|{this.AmountFiscalCredit}|{this.ControlCode}|{this.NITRecep}|{this.UserIssuer}";
        }

    }
}
