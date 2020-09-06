using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class MainSalesModel
    {
        public List<SalesModel> Sale { get; set; }
        public List<SalesChannelModel> Channel { get; set; }
        public List<BranchModel> Branch { get; set; }
        public List<PayTermsModel> PayTerm { get; set; }
        public List<TransportModel> Transport { get; set; }
        
    }
}