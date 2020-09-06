using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TFATERPWebApplication.Models
{
    public class SalesModel
    {
         [DataType(DataType.Date)]
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
         public DateTime? DocDate { get; set; }
         [Required(ErrorMessage="Can't Empty this field")]
         public string Srl { get; set; }
         //[Required(ErrorMessage = "Can't Empty this field")]
         public string WONumber { get; set; }
         //public IEnumerable<SelectListItem> ExciseAs { get; set; }
         //[Required(ErrorMessage ="Can't Empty this field")]
         public string TfatBranchCode { get; set; }
         public string Code { get; set; }
         public string DCCode { get; set; }
         public string Qty { get; set; }
         public string Qty2 { get; set; }
         public string Unit { get; set; }
         public string Unit2 { get; set; }
         public string Rate { get; set; }
         public string RatePer { get; set; }
         public string Disc { get; set; }
         public string DiscAmt { get; set; }
         public string TfatBranchName { get; set; }
         public string BillToCode { get; set; }
         public string BillToName { get; set; }
         public string ShipToCode { get; set; }
         public string ShipToName { get; set; }
         public string SalesChannelCode { get; set; }
         public string SalesChannelName { get; set; }
         public List<AddressDetails> AddressList { get; set; }        
         public string IncoTermName { get; set; }
         public string IncoTermCode { get; set; }
         public string PaymentTermCode { get; set; }
         public string PaymaentTermName { get; set; }
         public string ContactPerson { get; set; }
        public string TransportName { get; set; }
        public string TransportCode { get; set; }
        public string VehicleNo { get; set; }
        public string TransMode { get; set; }
        public string Remark { get; set; }
        public string NoPkg { get; set; }
        public DateTime? NoteDate { get; set; }
        public string NoteNo { get; set; }
        public string workOrderNo { get; set; }
        public string BillRef { get; set; }
        public string SalesManName { get; set; }
        public string SalesManCode { get; set; }
        public string Comm { get; set; }
        public string Head { get; set; }
        public string Sno { get; set; }
        public int Value { get; set; }
        public decimal TotalDisc { get; set; }
        public string Narr { get; set; }
        public int Order { get; set; }
        public int VenderID { get; set; }
        public int txtCode_TFatBranch { get; set; }
        public string txtName_TFatBranch { get; set; }
        public string txtCode_TfatComp { get; set; }
        public string txtName_TfatComp { get; set; }
        public string txtCode_TfatCity { get; set; }
        public string txtName_TfatCity { get; set; }

    }
    public class AddressDetails
    {
        public string Sno { get; set; }
        public string Name { get; set; }
    }
}