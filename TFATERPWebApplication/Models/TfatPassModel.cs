using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;

namespace TFATERPWebApplication.Models
{
    public class TfatPassModel:TfatPass 
    {
        


        public int RecordKey { get; set; }
        public string AccountRights { get; set; }
        public short ActiveAssist { get; set; }
        public string AllowAreas { get; set; }
        public string AllowCategory { get; set; }
        public bool Animate { get; set; }
        public string AppBranch { get; set; }
        public string Assistant { get; set; }
        public bool AuditTrail { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public int AuthRec { get; set; }
        public bool BoldFont { get; set; }
        public bool ChangeForm { get; set; }
        public short CheckMark { get; set; }
        public string ClickSequence { get; set; }
        public short ColScheme { get; set; }
        public bool Control3D { get; set; }
        public string CorpID { get; set; }
        public bool DailyPassword { get; set; }
        public string Dept { get; set; }
        public bool DeskTop { get; set; }
        public bool DontChangePassword { get; set; }
        public string EmailClient { get; set; }
        public string EmailID { get; set; }
        public bool EnterKey { get; set; }
        public System.DateTime Expiry { get; set; }
        public string Flag { get; set; }
        public bool FontBoldBtn { get; set; }
        public bool FontBoldGrdC { get; set; }
        public bool FontBoldGrdH { get; set; }
        public bool FontBoldLbl { get; set; }
        public bool FontBoldTxt { get; set; }
        public string FontName { get; set; }
        public string FontNameBtn { get; set; }
        public string FontNameGrdC { get; set; }
        public string FontNameGrdH { get; set; }
        public string FontNameLbl { get; set; }
        public string FontNameTxt { get; set; }
        public short FontSize { get; set; }
        public short FontSizeBtn { get; set; }
        public short FontSizeGrdC { get; set; }
        public short FontSizeGrdH { get; set; }
        public short FontSizeLbl { get; set; }
        public short FontSizeTxt { get; set; }
        public bool ForceResize { get; set; }
        public bool FormCaption { get; set; }
        public bool Fri { get; set; }
        public bool HelpOnStart { get; set; }
        public bool Hide { get; set; }
        public bool HomeWorkflow { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }

        [Required(ErrorMessage = "Email Id Required")]
        [Display(Name = "Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
          ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string IDs { get; set; }
        public bool InBox { get; set; }
        public bool InboxDelete { get; set; }
        public bool IsHead { get; set; }
        public string LastBranch { get; set; }
        public string LastBranchUsed { get; set; }
        public string LastComp { get; set; }
        public string LastCompany { get; set; }
        public System.DateTime LastLastDt { get; set; }
        public System.DateTime LastLicReminder { get; set; }
        public System.DateTime LastLogin { get; set; }
        public System.DateTime LastStartDt { get; set; }
        public bool LastUser { get; set; }
        public bool Learning { get; set; }
        public bool LicReminder { get; set; }
        public bool Locked { get; set; }
        public string LogIns { get; set; }
        public bool MainCentre { get; set; }
        public int MaxTrx { get; set; }
        public string Mobile { get; set; }
        public bool Mon { get; set; }
        public int MsgDays { get; set; }
        public bool MsgPopup { get; set; }
        public string Name { get; set; }
        public bool NoRightClick { get; set; }
        public string OptionAlign { get; set; }
        public short OptionTab { get; set; }
        public string PassRead { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string PassWords { get; set; }

        [Required(ErrorMessage = "Confirm Password Required:")]
        [DataType(DataType.Password)]
        [Compare("PassWords", ErrorMessage = "Confirm Password not matched:")]
        [Display(Name = "Confirm password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string ConfirmPassword { get; set; }

        public string Photograph { get; set; }
        public string POPServer { get; set; }
        public string PrGroup { get; set; }
        public bool PrintControl { get; set; }
        public string ProductRights { get; set; }
        public bool RateHistory { get; set; }
        public bool RecMsg { get; set; }
        public bool RecSMS { get; set; }
        public bool RestrictWS { get; set; }
        public bool Sat { get; set; }
        public string Signature { get; set; }
        public string SMTPPassword { get; set; }
        public int SMTPPort { get; set; }
        public bool SMTPRoute { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPUser { get; set; }
        public bool SoundEvent { get; set; }
        public bool StartRem { get; set; }
        public string StartUpForm { get; set; }
        public bool StartUpMemo { get; set; }
        public bool StatusBar { get; set; }
        public bool Sun { get; set; }
        public bool Thu { get; set; }
        public short TipOnStart { get; set; }
        public short ToolBar { get; set; }
        public short ToolBarDisplay { get; set; }
        public decimal TouchValue { get; set; }
        public bool Tue { get; set; }
        public string UserRole { get; set; }
        public string WallPaper { get; set; }
        public bool Wed { get; set; }
        public string WorkStation { get; set; }
        public string WSLogin { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }

        public bool IsSelected { get; set; }

        [Required(ErrorMessage = "Enter Verification Code")]
        [Display(Name = "Verification Code:")]
        public string Captcha { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "Please read and accept the term and policy")]
        //[Display(Name = "Terms & Condition:")]
        public bool TermsAccepted { get; set; }

        public virtual ICollection<TfatPass> TfatPass1 { get; set; }
        public virtual TfatPass TfatPass2 { get; set; }




        public bool IsUserExist(string IDs)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection
            (System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from TfatPass where IDs='" + IDs + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }

        public bool Insert()
        {
            bool flag = false;
            if (!IsUserExist(IDs))
            {
                SqlConnection connection = new SqlConnection
               (System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TfatPass(IDs,PassWords) values('" + IDs + "','" + PassWords + "')", connection);
                flag = Convert.ToBoolean(command.ExecuteNonQuery());

                connection.Close();
                return flag;
            }
            return flag;
        }

    }

    public class CaptchImageAction : System.Web.Mvc.ActionResult
    {
        public Color BackgroundColor { get; set; }
        public Color RandomTextColor { get; set; }
        public string RandomText { get; set; }
        public override void ExecuteResult(System.Web.Mvc.ControllerContext context)
        {
            RenderCaptchaImage(context);
        }
        private void RenderCaptchaImage(System.Web.Mvc.ControllerContext context)
        {
            Bitmap objBmp = new Bitmap(150, 60);
            Graphics objGraphic = Graphics.FromImage(objBmp);
            objGraphic.Clear(BackgroundColor);
            SolidBrush objBrush = new SolidBrush(RandomTextColor);
            Font objFont = null;
            int a;
            string myFont, str;
            string[] crypticsFont = new string[11];
            crypticsFont[0] = "Times New roman";
            crypticsFont[1] = "Verdana";
            crypticsFont[2] = "Sylfaen";
            crypticsFont[3] = "Microsoft Sans Serif";
            crypticsFont[4] = "Algerian";
            crypticsFont[5] = "Agency FB";
            crypticsFont[6] = "Andalus";
            crypticsFont[7] = "Cambria";
            crypticsFont[8] = "Calibri";
            crypticsFont[9] = "Courier";
            crypticsFont[10] = "Tahoma";
            for (a = 0; a < RandomText.Length; a++)
            {
                myFont = crypticsFont[a];
                objFont = new Font(myFont, 18, FontStyle.Bold | FontStyle.Italic |
                                                                  FontStyle.Strikeout);
                str = RandomText.Substring(a, 1);
                objGraphic.DrawString(str, objFont, objBrush, a * 20, 20);
                objGraphic.Flush();
            }
            context.HttpContext.Response.ContentType = "image/GF";
            objBmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Gif);
            objFont.Dispose();
            objGraphic.Dispose();
            objBmp.Dispose();
        }
    }

}

    
