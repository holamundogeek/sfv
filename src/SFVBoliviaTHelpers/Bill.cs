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
        private long authorization;
        private DateTime date;
        private double amount;
        private double amountFiscalCredit;
        private string controlCode;
        private long nITRecep;
        private UserIssuer userIssuer;

            
            public int MyProperty { get; set; }

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

    }
}
