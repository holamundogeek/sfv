using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    internal class Bill
    {

        private int BillNumber { get; set; }

        private long Authorization { get; set; }

        private DateTime Date { get; set; }

        private double Amount { get; set; }

        private double AmountFiscalCredit { get; set; }

        private string ControlCode { get; set; }

        private long NITRecep { get; set; }

        private UserIssuer UserIssuer { get; set; }
        
        internal Bill(int billNumber, long authorization, DateTime date,
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
