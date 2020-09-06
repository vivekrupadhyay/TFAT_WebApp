using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFATERPWebApplication.Aspx
{
    public partial class BankPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindgrid();
        }

        public void Bindgrid()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TfatLedgerBranch_Select";
            cmd.Connection = con;
            try
            {
                con.Open();
                GvLedgerBranch.EmptyDataText = "No Records Found";
                GvLedgerBranch.DataSource = cmd.ExecuteReader();
                GvLedgerBranch.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        
        
        
        }
    }
}