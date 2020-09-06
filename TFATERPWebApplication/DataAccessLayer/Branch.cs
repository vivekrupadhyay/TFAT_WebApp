using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Data_Access_Layer
{
    public class Branch
    {
        public string InsertData(TFATERPWebApplication.Dal.TFatBranch MD)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ToString());
                SqlCommand cmd = new SqlCommand("Tfat_Insert_TFatBranch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@aAuthno ",MD.aAuthno);
                cmd.Parameters.AddWithValue("@aCity ", MD.aCity);
                cmd.Parameters.AddWithValue("@aCountry",MD.aCountry);
                cmd.Parameters.AddWithValue("@aCstNo ", MD.aCstNo);
                cmd.Parameters.AddWithValue("@Addrl1", MD.Addrl1);
                cmd.Parameters.AddWithValue("@Addrl2", MD.Addrl2);
                cmd.Parameters.AddWithValue("@Addrl3", MD.Addrl3);
                cmd.Parameters.AddWithValue("@Addrl4", MD.Addrl4);
                cmd.Parameters.AddWithValue("@aFax", MD.aFax);
                cmd.Parameters.AddWithValue("@aLstno", MD.aLstno);
                cmd.Parameters.AddWithValue("@aPin", MD.aPin);
                cmd.Parameters.AddWithValue("@AssAreaCode", MD.AssAreaCode);
                cmd.Parameters.AddWithValue("@AssCityCode", MD.AssCityCode);
                cmd.Parameters.AddWithValue("@AssPincode", MD.AssPincode);
                cmd.Parameters.AddWithValue("@aState ",MD.aState);
                cmd.Parameters.AddWithValue("@aTel1", MD.aTel1);
                cmd.Parameters.AddWithValue("@aTel2", MD.aTel2);
                cmd.Parameters.AddWithValue("@aTel3", MD.aTel3);
                cmd.Parameters.AddWithValue("@aTel4 ", MD.aTel4);
                cmd.Parameters.AddWithValue("@AuthIds", "Admin");
                cmd.Parameters.AddWithValue("@Authorise", "Adm");
                cmd.Parameters.AddWithValue("@BranchLocation", MD.BranchLocation);
                cmd.Parameters.AddWithValue("@Business", MD.Business);
                cmd.Parameters.AddWithValue("@Code", MD.Code);
                cmd.Parameters.AddWithValue("@Coll", MD.Coll);
                cmd.Parameters.AddWithValue("@CompCode", MD.CompCode);
                cmd.Parameters.AddWithValue("@Custom", MD.Custom);
                cmd.Parameters.AddWithValue("@Div", MD.Div);
                cmd.Parameters.AddWithValue("@ECCNo", MD.ECCNo);
                cmd.Parameters.AddWithValue("@EMail", MD.EMail);
                cmd.Parameters.AddWithValue("@Flag", MD.Flag);
                cmd.Parameters.AddWithValue("@Grp", MD.Grp);
                cmd.Parameters.AddWithValue("@HWSerial", "WEB001");
                cmd.Parameters.AddWithValue("@HWSerial2", "WEB001");
                cmd.Parameters.AddWithValue("@Licence2 ", MD.Licence2);
                cmd.Parameters.AddWithValue("@Name", MD.Name);
                cmd.Parameters.AddWithValue("@NoteAvail", MD.NoteAvail);
                cmd.Parameters.AddWithValue("@NoteSno", MD.NoteSno);
                cmd.Parameters.AddWithValue("@PanNo", MD.PanNo);
                cmd.Parameters.AddWithValue("@Range ", MD.Range);
                cmd.Parameters.AddWithValue("@RegNo ", MD.RegNo);
                cmd.Parameters.AddWithValue("@ServiceTax", MD.ServiceTax);
                cmd.Parameters.AddWithValue("@Supp ", MD.Supp);
                cmd.Parameters.AddWithValue("@TDSAuthorise", MD.TDSAuthorise);
                cmd.Parameters.AddWithValue("@TDSCir", MD.TDSCir);
                cmd.Parameters.AddWithValue("@TDSOffice", MD.TDSOffice);
                cmd.Parameters.AddWithValue("@TDSReg", MD.TDSReg);
                cmd.Parameters.AddWithValue("@TINNo", MD.TINNo);
                cmd.Parameters.AddWithValue("@Users", MD.Users);
                cmd.Parameters.AddWithValue("@VATReg", MD.VATReg);
                cmd.Parameters.AddWithValue("@www ", MD.www);
                cmd.Parameters.AddWithValue("@EnteredBy", "Admin");
                cmd.Parameters.AddWithValue("@Fri", MD.Fri);
                cmd.Parameters.AddWithValue("@LastBranch", MD.LastBranch);
                cmd.Parameters.AddWithValue("@LastUpdated",MD.LastUpdated);
                cmd.Parameters.AddWithValue("@LogIn", MD.LogIn);
                cmd.Parameters.AddWithValue("@Mon", MD.Mon);
                cmd.Parameters.AddWithValue("@OpCredit", MD.OpCredit);
                cmd.Parameters.AddWithValue("@OpDebit", MD.OpDebit);
                cmd.Parameters.AddWithValue("@Sat", MD.Sat);
                cmd.Parameters.AddWithValue("@Sun", MD.Sun);
                cmd.Parameters.AddWithValue("@Thu", MD.Thu);
                cmd.Parameters.AddWithValue("@TouchValue",MD.TouchValue);
                cmd.Parameters.AddWithValue("@Tue", MD.Tue);
                cmd.Parameters.AddWithValue("@Wed ", MD.Wed);               
                con.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch(Exception ex)
            {
                throw;
                
            }
            finally
            {
                con.Close();
            }
        }
    }
}