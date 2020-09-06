using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.DataAccessLayer
{
    public class Company
    {


        public bool Iscompany(string Code)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection
            (System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from TfatComp where Code='" + Code + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }

        //public string inseruser(TFATERPWebApplication.Dal. comp)
        //{ 
        //    SqlConnection con = null;
        //    string result = "";
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ToString());
        //        SqlCommand cmd = new SqlCommand("Tfat_Insert_UserCompBranch", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserId  ", comp.Users);
        //        cmd.Parameters.AddWithValue("@CompCode  ", comp.Adrl2);
        //        cmd.Parameters.AddWithValue("@BranchCode ", comp.Adrl3);
        //        cmd.Parameters.AddWithValue("@Adrl4  ", comp.Adrl4);
        //    }
        
        
        //}


         public string InsertData(TFATERPWebApplication.Dal.TfatComp comp)
        {
            
            SqlConnection con = null;
            string result = "";
            try
            {
                 con = new SqlConnection(ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ToString());
                SqlCommand cmd = new SqlCommand("Tfat_Insert_TfatComp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Adrl1  ", comp.Adrl1);
                cmd.Parameters.AddWithValue("@Adrl2  ", comp.Adrl2);
                cmd.Parameters.AddWithValue("@Adrl3 ", comp.Adrl3);
                cmd.Parameters.AddWithValue("@Adrl4  ",comp.Adrl4);
                cmd.Parameters.AddWithValue("@AssessOffice ",comp.AssessOffice);
                cmd.Parameters.AddWithValue("@AuthCap ", comp.AuthCap);
                cmd.Parameters.AddWithValue("@AuthIds", "Admin");
                cmd.Parameters.AddWithValue("@AuthNo ", comp.AuthNo);
                cmd.Parameters.AddWithValue("@Authorise", "Adm");
                cmd.Parameters.AddWithValue("@Business", comp.Business);
                cmd.Parameters.AddWithValue("@City", comp.City);
                cmd.Parameters.AddWithValue("@Code", comp.Code);
                cmd.Parameters.AddWithValue("@CompanyLogo", comp.CompanyLogo);
                cmd.Parameters.AddWithValue("@CompanyType", comp.CompanyType);
                cmd.Parameters.AddWithValue("@CompInfo", comp.CompInfo);
                cmd.Parameters.AddWithValue("@Const", comp.Const);
                cmd.Parameters.AddWithValue("@Country ", comp.Country);
                cmd.Parameters.AddWithValue("@cstno", comp.cstno);
                cmd.Parameters.AddWithValue("@DDOCode", comp.DDOCode);
                cmd.Parameters.AddWithValue("@DDOReg", comp.DDOReg);
                cmd.Parameters.AddWithValue("@DeductorType", comp.DeductorType);
                cmd.Parameters.AddWithValue("@EMail", comp.EMail);
                cmd.Parameters.AddWithValue("@fax", comp.fax);
                cmd.Parameters.AddWithValue("@HWSerial", "WEB001");
                cmd.Parameters.AddWithValue("@HWSerial2", "WEB001");
                cmd.Parameters.AddWithValue("@LastBranch",comp.LastBranch);
                cmd.Parameters.AddWithValue("@LastPeriod",comp.LastPeriod);
                cmd.Parameters.AddWithValue("@Licence1", comp.Licence1);
                cmd.Parameters.AddWithValue("@Licence2", comp.Licence2);
                cmd.Parameters.AddWithValue("@lstno", comp.lstno);
                cmd.Parameters.AddWithValue("@Ministry ", comp.Ministry);
                cmd.Parameters.AddWithValue("@Name", comp.Name);
                cmd.Parameters.AddWithValue("@Nature", comp.Nature);
                cmd.Parameters.AddWithValue("@PAN", comp.PAN);
                cmd.Parameters.AddWithValue("@PAOCode", comp.PAOCode);
                cmd.Parameters.AddWithValue("@PAOReg", comp.PAOReg);
                cmd.Parameters.AddWithValue("@Pin ", comp.Pin);
                cmd.Parameters.AddWithValue("@PFFix ", comp.PFFix);
                cmd.Parameters.AddWithValue("@PFupLimit ", comp.PFupLimit);
                cmd.Parameters.AddWithValue("@ServiceTaxNo ", comp.ServiceTaxNo);
                cmd.Parameters.AddWithValue("@SMSURL", comp.SMSURL);
                cmd.Parameters.AddWithValue("@State ", comp.State);
                cmd.Parameters.AddWithValue("@STDCode", comp.STDCode);
                cmd.Parameters.AddWithValue("@Taluka", comp.Taluka);
                cmd.Parameters.AddWithValue("@TDSCir", comp.TDSCir);
                cmd.Parameters.AddWithValue("@TDSReg ", comp.TDSReg);
                cmd.Parameters.AddWithValue("@Tel1", comp.Tel1);
                cmd.Parameters.AddWithValue("@Tel2", comp.Tel2);
                cmd.Parameters.AddWithValue("@Tel3", comp.Tel3);
                cmd.Parameters.AddWithValue("@Tel4", comp.Tel4);
                cmd.Parameters.AddWithValue("@TINNo ", comp.TINNo);
                cmd.Parameters.AddWithValue("@TouchValue ", comp.TouchValue);
                cmd.Parameters.AddWithValue("@USERPass", comp.USERPass);
                cmd.Parameters.AddWithValue("@Users", comp.Users);
                cmd.Parameters.AddWithValue("@VATReg ", comp.VATReg);
                cmd.Parameters.AddWithValue("@www", comp.www);
                cmd.Parameters.AddWithValue("@xState ", comp.xState);
                cmd.Parameters.AddWithValue("@EnteredBy", "Admin");
                cmd.Parameters.AddWithValue("@LastUpdateDate", 0);
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

