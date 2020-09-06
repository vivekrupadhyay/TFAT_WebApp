using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class TransportModel
    {
        public string ContactPerson { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string VehicleNo { get; set; }
        public string TransMode { get; set; }
        public string Remark { get; set; }
        public string NoPkg { get; set; }
        public DateTime? NoteDate { get; set; }
        public string NoteNo { get; set; }
        public ICollection<MasterModel> Transporter { get; set; }

    }
}