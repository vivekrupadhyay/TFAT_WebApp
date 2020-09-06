using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Models;

namespace TFATERPWebApplication.Models
{
    public class BankPaymentContext:DbContext
    {
        public DbSet<BankPayment> bankPaymentlist { get; set; } 
    }
}