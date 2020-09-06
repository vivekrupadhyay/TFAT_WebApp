using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Reflection;
using System.Xml;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Models;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class GeneralFunCls
    {
        decimal gpRoundVAT;

        decimal[] Ar;
        string[] BroArr = { };
        Boolean gpTaxS = false;
        decimal mVatDec;

        Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        public string FieldOfTable(string _mTableName, string _mReturnField, string mValField, string mVal)
        {
            var TblSet = Core.CoreCommon.GetTableData(_mTableName);
            var output = TblSet.AsQueryable().ToListAsync().Result.ToList();
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();
            var QryResult = (from m in output
                             where m.GetType().GetProperty("Code").GetValue(m).ToString().Equals(mVal)
                             select m.GetType().GetProperty("IntRate").GetValue(m).ToString());

            string QryResult1 = (QryResult.First());
            return QryResult1.ToString();
        }
        public string CalculateTax(string _Rate, long _Amount)
        {
            decimal mSTP;
            decimal mTxbl;
            // decimal mTxbl; 
            //double mTxbl;
            // Byte  gsCurrDec;
            var Query = (from a in ctx.ServiceTaxRates
                         where a.Code == "000001"
                         select new { a.STRate, a.STCess, a.STSheCess, a.Abatement }).ToList();
            string mVal = string.Empty;// string _TaxAmt =
            string _TaxAmt = string.Empty;
            _TaxAmt = "1";//nRound(_Amount, 1, 1, 1, 1);
            string _mTax = "2";
            string _mSerChrg = "3";
            string _mCess = "4";
            return mVal = _TaxAmt + "~" + _mTax + "~" + _mSerChrg + "~" + _mCess;
           // return mVal = CalAll(false,false).ToString();
        }

       //  Implementing VB code ----

        //private string CalAll(ref bool mCalTax, bool mCalExc)//,  void False void ='', void True,
        //{
        //    decimal mAmt;
        //    decimal mAddTax;
        //    //double mSTP;
        //    int _mTax;
        //    decimal mCessTax;
        //    string mRoundS;
        //    string mRoundSTo;
        //    decimal mExcAmt;
        //    decimal mSTaxable;
        //    decimal mExcCess;
        //    decimal mExcSheCess;
        //    decimal mExcADC;
        //    string mTaxStr;
        //    bool gpTaxS;
        //    bool gpSerTax;
        //    bool gpMulTaxS;
        //    int n;
        //    string gsCurrDec;
        //    // string mTaxStr;
        //    if (mTaxStr == "")
        //    {
        //        string _TaxAmt;
        //        //string _mTax;
        //        string _mSerChrg;
        //        string _mCess;
        //        _TaxAmt =( (double.Parse(_TaxAmt) + _mTax) + (double.Parse(_mCess) + double.Parse(_mSerChrg)).ToString());
        //    }
        //    //else {
        //    //    lblTaxString.Caption = GetTaxString(TempRs);
        //    //    // With...
        //    //    if ((TempRs.RecordCount > 0)) {
        //    //        TempRs.MoveFirst;
        //    //        while (!TempRs.EOF) {
        //    //            txtTAX.Text = (double.Parse(txtTAX.Text) 
        //    //                        + (TaxAmt 
        //    //                        + (AddTax 
        //    //                        + (Cess + SurCharge.MoveNext()))));
        //    //        }
        //    //    }
        //    //}

        //    //mTxbl = 0;
        //    //mAmt = 0;
        //    //mSTaxable = 0;
        //    //for (n = 0; (n <= UBound(Ar)); n++) {
        //    //    if ((AfterTax(n) == false)) {
        //    //        switch (txblSign(n)) {
        //    //            case "+":
        //    //                mTxbl = (mTxbl + Ar(n));
        //    //                break;
        //    //            case "-":
        //    //                mTxbl = (mTxbl - Ar(n));
        //    //                break;
        //    //        }
        //    //        switch (lblSign(n)) {
        //    //            case "+":
        //    //                mAmt = (mAmt + Ar(n));
        //    //                break;
        //    //            case "-":
        //    //                mAmt = (mAmt - Ar(n));
        //    //                break;
        //    //        }
        //    //        // 
        //    //        switch (mSTaxSign(n)) {
        //    //            case "+":
        //    //                mSTaxable = (mSTaxable + Ar(n));
        //    //                break;
        //    //            case "-":
        //    //                mSTaxable = (mSTaxable - Ar(n));
        //    //                break;
        //    //        }
        //    //    }
        //    //}
        //    if ((gpSerTax == true) && (gpMulTaxS == true))
        //    {
        //        if (mSTaxable > 0)
        //        {
        //            mSTaxable = (mSTaxable - _mTax);
        //        }
        //        //mAmt = nRound(mAmt, gsCurrDec, gsCurrDec, mVatDec);
        //        //mTxbl = nRound(mTxbl, gsCurrDec);
        //        //mSTaxable = nRound(mSTaxable, gsCurrDec);
        //        if (gpTaxS)
        //        {
        //           // FindTaxDetails();
        //          //  lblTaxable.Caption = nFormat(mTxbl, gsCurrDec, false);
        //        }
        //    }
        //    if (mCalTax)
        //    {
        //        // If gpSTRound = False Then
        //        _TaxAmt = nRound((mTxbl * (mSTP / 100)), mVatDec, gpRoundVAT);
        //        _mTax = nRound((mTxbl * (_mTax / 100)), mVatDec, gpRoundVAT);
        //        _mCess = nRound((_TaxAmt * (mCessTax / 100)), mVatDec, gpRoundVAT);
        //        _mSerChrg = nRound((_TaxAmt * (_mSerChrg / 100)), mVatDec, gpRoundVAT);
        //        mTxbl = nRound((mAmt + (_TaxAmt + (_TaxAmt + (_mCess + _mSerChrg)))), gsCurrDec);
        //        mAmt = mTxbl;
        //    }
        //    else
        //    {

        //        mTxbl = 0;
        //        _TaxAmt;
        //        mCessTax = 0;
        //        _mSerChrg = 0.21;
        //        //lblTaxable.Caption = "0.00";
        //    }




        //    //          else if ((gpSerTax && (cmbSTax.ListIndex != -1)))
        //    //         {
        //    //            lblSTaxable.Caption = nFormat(mSTaxable, gsCurrDec, false);
        //    //          }
        //    //  else if (mCalTax)
        //    //  {
        //    //      ADODB.Recordset mRs = new ADODB.Recordset();

        //    //      Open;
        //    //      (("Select Top 1 STRate,STCess,STSheCess,Abatement from ServiceTaxRates Where Code=\'" 
        //    //                  + (FieldOfTable("ServiceTaxMaster", "Code", ("Name = \'" 
        //    //                      + (cmbSTax.Text + "\'"))) + "\' And EffDate<=")) 
        //    //                  + (MmDdYy(txtDate.Text) + " Order by EffDate Desc"));
        //    //      gsDbDbf;
        //    //      adOpenStatic;
        //    //      adLockReadOnly;
        //    //      adCmdText;
        //    //      EOF = false;
        //    //      mSTRate = STRate;
        //    //      mSTCessRate = STCess;
        //    //      mStSheCessRate = STSheCess;
        //    //      mSTaxable = (mSTaxable  - (mSTaxable  * (Abatement / 100)));
        //    //      txtSTax.Text = nRound((mSTaxable * (STRate / 100)), mSTaxDec,gpRoundSTax);
        //    //      txtSTaxCess.Text = nRound((txtSTax.Text * (STCess / 100)), mSTaxDec, ,, gpRoundSTax);
        //    //      txtSTaxSHECess.Text = nRound((txtSTax.Text  * (STSheCess / 100)), mSTaxDec, ,, gpRoundSTax);

        //    //      Close;

        //    //  }

        //    // mSTaxable = nRound((mAmt  + (txtSTax.Text + (txtSTaxCess.Text + txtSTaxSHECess.Text))), gsCurrDec);
        //    //mAmt = mSTaxable;
        //    //ElsetxtSTaxCess.Text = 0;
        //    //txtSTaxSHECess.Text = 0;
        //    //txtSTax.Text = 0;
        //    //lblSTaxable.Caption = nFormat(mSTaxable, gsCurrDec, false);
        //    //mSTaxable = nRound(mAmt, gsCurrDec);

        //    //  }


        //    //       if(txtAmt.Text = mSTaxable)
        //    //       {
        //    //  // txtAmt.Text = mTxbl
        //    //  for (n = 0;(n<=UBound(Ar));n++) 
        //    //  {
        //    //      if ((AfterTax(n) == true)) 
        //    //      {
        //    //          Ar(n) = CalBreakUp(ChgsEqsn(n), this, frmExcisePerEntrySales, ,, ChgsRnd(n));
        //    //          lblCharges(n).Tag = Ar(n);
        //    //          lblCharges(n).ToolTipText = ("result: " + Ar(n));
        //    //          txtResult(n).Text = nFormat(Ar(n), gsCurrDec);
        //    //          switch (lblSign(n)) 
        //    //          {
        //    //              case "+":
        //    //                  mTxbl = (mTxbl + Ar(n));
        //    //                  mAmt = (mAmt + Ar(n));
        //    //                  break;
        //    //              case "-":
        //    //                  mTxbl = (mTxbl - Ar(n));
        //    //                  mAmt = (mAmt - Ar(n));
        //    //                  break;
        //    //          }
        //    //      }
        //    //  }



        //    mTxbl = mAmt;

        //    if (mRoundS == "")
        //    {
        //        //  txbl used to handle the rounded figure
        //        mAmt = nRound(mAmt, mRoundSTo, gsCurrDec, mRound);
        //    }
        //    else
        //    {
        //        mAmt = nRound(mAmt, gsCurrDec, gsCurrDec, mAddTax, mVatDec);
        //    }

        //    if (mRoundS == "")
        //    {
        //        txtRoundOff.Text = nRound((mAmt - mTxbl), gsCurrDec);
        //        //  sign should be reversed so txbl-mamt
        //    }
        //    else
        //    {
        //        txtRoundOff.Text = 0;
        //    }
        //    _TaxAmt = mAmt;
        //    decimal mBrok;
        //    bool gpBroker;
        //    string[] BroArr;
        //    if (gpBroker == true)
        //    {
        //        for (n = 0; n <= Ar.Length; n++)
        //        {

        //            switch (BroArr[n])
        //            {
        //                case "+":
        //                    mBrok = (mBrok + Ar[n]);
        //                    break;
        //                case "-":
        //                    mBrok = (mBrok - Ar[n]);
        //                    break;
        //            }
        //        }
        //        string txtBrokerOn = "";
        //        if ((mBrok != 0))
        //        {
        //            txtBrokerOn = nFormat(mBrok, gsCurrDec);
        //        }
        //        if ((double.Parse(txtBrokerage.Text) > 0))
        //        {
        //            txtBrokerAmt.Text = nFormat(((double.Parse(txtBrokerOn) * double.Parse(txtBrokerage.Text)) / 100), gsCurrDec);
        //        }
        //        // 
        //        decimal mComm;
        //        bool gpSalesman;
        //        string[] SaleArr;
        //        if (gpSalesman == true)
        //        {
        //            for (n = 0; (n <= Ar.Length); n++)
        //            {
        //                switch (SaleArr[n])
        //                {
        //                    case "+":
        //                        mComm = (mComm + Ar[n]);
        //                        break;
        //                    case "-":
        //                        mComm = (mComm - Ar[n]);
        //                        break;
        //                }
        //            }
        //        }
        //        string txtSManOn = "";

        //        if ((mComm != 0))
        //        {
        //            txtSManOn = nFormat(mComm, gsCurrDec, mInsert);
        //        }
        //        if ((double.Parse(txtSManPer.Text) > 0))
        //        {
        //            txtSManAmt.Text = nFormat(((Convert.ToDouble(txtSManOn) * Convert.ToDouble(txtSManPer.Text))
        //                            / 100), gsCurrDec);
        //        }
        //       // return;

        //    }
        //    //double mSTP;
           
        //    return mAmt + "~" + _mTax + "~" + mCessTax + "~" + _mTax;
        //}

        // Inner Functions.....................

        //public string PadR(string PadStr, int PadSize, string PadChar)
        //{
        //    string vbString = "";
        //    if (((PadStr) != vbString) && (PadStr != ""))
        //    {
        //        PadStr = PadStr.Trim();
        //    }
        //    if ((PadStr.Length >= PadSize))
        //    {
        //        // return PadStr.ToString();
        //        vbString = PadStr;

        //    }
        //    return (PadStr + ((PadSize - PadStr.Length) + PadChar));
        //}
        //public object CalBreakUp(ref string mEqsn, object mFrm, object mFrmX, bool OperationAllow, int RoundOff)
        //{
        //    object mV;
        //    long m;
        //    long n;
        //    long YesAlpha;
        //    object mVal;
        //    string mOpArr;
        //    int mLastOpen;
        //    int mLastClose;
        //    bool Ptg;
        //    decimal mVs;
        //    long mL = mEqsn.Length;
        //    string mmEqsn;
        //    string mFuncs;
        //    bool StrAdd;
        //    string ans;
        //    int CountSpace;
        //    object mCond;//string
        //    string mValue;
        //    bool mResult;
        //    string mOp;
        //    object mArg1;
        //    object mArg2;
        //    object mArg3;
        //    //string IsAlpha;
        //    //string IsAlphaNum;
        //    long X = 1;
        //    // ((void)(mArg2));
        //    // ((void)(mArg3));
        //    ///  X =1;
        //    //mL = mEqsn.Length;
        //    // while(true) 
        //    //{
        //    //      YesAlpha = 0;
        //    //      for (n = X; (n <= mEqsn.Length); n++) 
        //    //      {
        //    //          if (IsAlpha(mEqsn.Substring((n - 1),1))) 
        //    //           {
        //    //              YesAlpha = n;
        //    //              break;
        //    //          }
        //    //      }
        //    //}
        //    if (YesAlpha == 0)
        //    {
        //        //Warning!!! Review that break works as 'Exit Do' as it could be in a nested instruction like switch
        //    }
        //    mV = "";
        //    //for (n = YesAlpha; (n <= mEqsn.Length); n++)
        //    //{
        //    //    if (IsAlphaNum(mEqsn.Substring((n - 1), 1))) 
        //    //    {
        //    //        mV = (mV + mEqsn.Substring((n - 1), 1));
        //    //    }
        //    //    else
        //    //    {
        //    //        break;
        //    //    }
        //    //}
        //    if ((("~NAMECODE ~GETBALANCE ~ABS ~INT ~ROUND ~YEAR ~MONTH ~IIF ".IndexOf((mV.ToUpper() + " ")) + 1) == 0))
        //    {
        //        if ((mV.Substring(0, 1).ToUpper() == "V"))
        //        {
        //            if (OperationAllow)
        //            {
        //                mVal = double.Parse(mFrm.txtCharges((double.Parse(mV.Substring(1)) - 1)).Text);
        //            }
        //            else
        //            {
        //                mVal = double.Parse(mFrm.txtDeduction((double.Parse(mV.Substring(1)) - 1)).Text);
        //            }
        //        }
        //        else if ((mV.Substring(0, 1).ToUpper() == "X"))
        //        {
        //            if (OperationAllow)
        //            {
        //                mVal = Convert.ToDouble(mFrm.lblCharges((Convert.ToDouble(mV.Substring(1)) - 1)).Tag);
        //            }
        //            else
        //            {
        //                mVal = double.Parse(mFrm.lblDeduction((double.Parse(mV.Substring(1)) - 1)).Tag);
        //            }
        //        }
        //    }

        //    mEqsn = EqsnExecuteCMD(mFrm, mEqsn);
        //    string[] mFunc = { "~ABS", "~INT", "~ROUND", "~YEAR", "~MONTH", "~IIF" };
        //    while (true)
        //    {
        //        Ptg = false;
        //        for (m = 0; (m <= 5); m++)
        //        {
        //            mFuncs = mFunc[m].ToUpper();
        //            if (((mEqsn.ToUpper().IndexOf(mFuncs) + 1) != 0))
        //            {
        //                X = ((mEqsn.ToUpper().IndexOf(mFuncs) + 1) + (mFuncs.Length + 1));
        //                for (n = (int)X; n <= (mEqsn.Length); n++)
        //                {
        //                    if (mEqsn.Substring(1, 12) == "}")//(n - 1), 1
        //                    {
        //                        mV = mEqsn.Substring(1, 12);//(X - 1), (n - X)
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    mL = n;
        //    switch (mFuncs)
        //    {
        //        case "~ABS":
        //            if (((mV.IndexOf("+") + 1) || ((mV.IndexOf("-") + 1) || ((mV.IndexOf("*") + 1) || (mV.IndexOf("/") + 1)))))
        //            {
        //                mV = CalBreakUp(mV, mFrm, mFrmX, OperationAllow);
        //            }
        //            mVal = Convert.ToString(Math.Abs(mV));
        //            break;
        //        case "~INT":
        //            if (((mV.IndexOf("+") + 1) || ((mV.IndexOf("-") + 1) || ((mV.IndexOf("*") + 1) || (mV.IndexOf("/") + 1)))))
        //            {
        //                mV = CalBreakUp(mFrm, mFrmX, OperationAllow, RoundOff);
        //            }
        //            mVal = mV.ToString();
        //            break;
        //        case "~ROUND":
        //            mArg1 = mV.Substring(0, ((mV.IndexOf(",") + 1) - 1));
        //            if (((mArg1.IndexOf("+") + 1) || ((mArg1.IndexOf("-") + 1) || ((mArg1.IndexOf("*") + 1) || (mArg1.IndexOf("/") + 1)))))
        //            {
        //                mArg1 = CalBreakUp(mArg1, mFrm, mFrm, OperationAllow);
        //            }
        //            mArg2 = mV.Substring((mV.IndexOf(",") + 1));
        //            if (((mArg2.IndexOf("+") + 1) || ((mArg2.IndexOf("-") + 1) || ((mArg2.IndexOf("*") + 1) || (mArg2.IndexOf("/") + 1)))))
        //            {
        //                mArg2 = CalBreakUp(mArg2, mFrm, mFrm, OperationAllow);
        //            }
        //            mVal = Math.Round(Convert.ToDouble(mArg1), Convert.ToDouble(mArg2));
        //            break;
        //        case "~YEAR":
        //            if (((mV.IndexOf("+") + 1) || ((mV.IndexOf("-") + 1) || ((mV.IndexOf("*") + 1) || (mV.IndexOf("/") + 1)))))
        //            {
        //                mV = CalBreakUp(mV, mFrm, mFrm, OperationAllow);
        //            }
        //            mVal = mV.Year;
        //            break;
        //        case "~MONTH":
        //            if (((mV.IndexOf("+") + 1) || ((mV.IndexOf("-") + 1) || ((mV.IndexOf("*") + 1) || (mV.IndexOf("/") + 1)))))
        //            {
        //                mV = CalBreakUp(mFrm, mFrmX, OperationAllow, RoundOff, mCond);
        //            }
        //            mVal = (double)(mV);
        //            break;
        //        case "~IIF":
        //            mCond = mV.ToString(0, ((mV.IndexOf(",") + 1) - 1));
        //            mV = mV.ToString((mV.IndexOf(",") + 1));
        //            if (((mCond.ToString("+") + 1) || ((mCond.ToString("-") + 1) || ((mCond.IndexOf("*") + 1) || (mCond.IndexOf("/") + 1)))))
        //            {
        //                mCond = CalBreakUp(mCond, mFrm, mFrmX, OperationAllow, mV, RoundOff);
        //            }
        //            break;
        //    }
        //    //mCond = mCond.Replace("|", "");
        //    mV = mV.Replace("|", "");
        //    string[] myArray = { "=", "<", ">", "<>", "<=", ">=", "$" };

        //    mOp = "";
        //    //mVal = "";
        //    for (n = 0; (n <= 6); n++)
        //    {
        //        mOpArr = myArray[n];
        //    }
        //    if (mOp != "")
        //    {
        //        mResult = false;
        //        switch (mOp)
        //        {
        //            case "=":
        //                if (mCond == mVal)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            case "<":
        //                if (mCond < mVal)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            case ">":
        //                if (mCond > mVal)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            case "<>":
        //                if (mCond != mVal)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            case "<=":
        //                if (mCond <= mVal)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            case ">=":
        //                if (mCond >= mVal)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            case "$":
        //                if ((mCond.IndexOf(mVal) + 1) != 0)
        //                {
        //                    mResult = true;
        //                }
        //                break;
        //            default:
        //                mResult = ((mCond == "True") ? true : false);
        //                break;
        //        }
        //    }
        //    mVal = (mResult ? mV.Substring(0, ((mV.IndexOf(",") + 1) - 1)) : mV.Substring((mV.IndexOf(",") + 1)));
        //    if (((mVal.IndexOf("+") + 1) || ((mVal.IndexOf("-") + 1) || ((mVal.IndexOf("*") + 1) || (mVal.IndexOf("/") + 1)))))
        //    {
        //        mVal = CalBreakUp(mVal, mFrm, mEqsn, mFrmX, OperationAllow);
        //    }

        //    if (!Ptg)
        //    {
        //        break; //Warning!!! Review that break works as 'Exit Do' as it could be in a nested instruction like switch
        //    }
        //    YesAlpha = 0;
        //    for (n = 1; (n <= mEqsn.Length); n++)
        //    {
        //        if (IsAlpha(mEqsn.Substring((n - 1), 1)))
        //        {
        //            YesAlpha = n;
        //            break;
        //        }
        //    }
        //    if (YesAlpha != 0)
        //    {
        //        while (true)
        //        {
        //            if (((mEqsn.IndexOf("+") + 1) || (mEqsn.IndexOf("|") + 1)))
        //            {
        //                YesAlpha = (mEqsn.IndexOf("+") + 1);
        //                if ((YesAlpha != 0))
        //                {
        //                    mEqsn = (mEqsn.Substring(0, (YesAlpha - 1)) + mEqsn.Substring(YesAlpha));
        //                }
        //                YesAlpha = (mEqsn.IndexOf("|") + 1);
        //                if ((YesAlpha != 0))
        //                {
        //                    mEqsn = (mEqsn.Substring(0, (YesAlpha - 1)) + mEqsn.Substring(YesAlpha));
        //                }
        //            }
        //            else
        //            {
        //                break; //Warning!!! Review that break works as 'Exit Do' as it could be in a nested instruction like switch
        //            }
        //        }
        //    }
        //    else
        //    {
        //        while (true)
        //        {
        //            mLastOpen = 0;
        //            mLastClose = 0;
        //            for (n = 1; (n <= mEqsn.Length); n++)
        //            {
        //                if ((mEqsn.Substring((n - 1), 1) == "("))
        //                {
        //                    mLastOpen = n;
        //                }
        //                if ((mEqsn.Substring((n - 1), 1) == ")"))
        //                {
        //                    mLastClose = n;
        //                    break;
        //                }
        //            }
        //            if (((mLastOpen == 0) || (mLastClose == 0)))
        //            {
        //                mVal = CalExecute(mEqsn);
        //                mEqsn = mVal.ToString();
        //                break; //Warning!!! Review that break works as 'Exit Do' as it could be in a nested instruction like switch
        //            }
        //            else
        //            {
        //                mVal = CalExecute(mEqsn.Substring(mLastOpen, (mLastClose - (mLastOpen - 1))));
        //                mEqsn = (mEqsn.Substring(0, (mLastOpen - 1)) + (mVal + mEqsn.Substring(mLastClose)));
        //            }
        //        }
        //    }
        //    // return (vbCritical + vbOKOnly);
        //}
        //public bool IsAlpha(String strToCheck)
        //{
        //    Regex objAlphaPattern = new Regex("[^a-zA-Z]");
        //    return !objAlphaPattern.IsMatch(strToCheck);
        //}
        //public bool IsAlphaNum(String strToCheck)
        //{
        //    Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
        //    return !objAlphaNumericPattern.IsMatch(strToCheck);
        //}

        ////Calculation of Round   
        //public string nFormat(object mVal, ref  byte mDec, ref bool mInsert)
        //{
        //    mDec = 2;
        //    bool mInsert = false;
        //    string mStr;
        //    string mFrac;
        //    byte mLen;
        //    string mSign;
        //    if (mVal != null)
        //    {
        //        mVal = 0;
        //    }
        //    //if (System.Convert.ToString((char )160)  > 0)
        //    //{
        //    //    mVal = mVal.Replace(' ', "");
        //    //}
        //    mVal = Convert.ToDouble(mVal);
        //    if ((mInsert == false))
        //    {
        //        return string.Format("", mVal, mDec);

        //    }

        //    mVal = Math.Round(mVal, mDec);
        //    mSign = (((mVal) < 0) ? "-" : "");
        //    mStr = Math.Abs(mVal);
        //    mFrac = "";
        //    if ((mStr.IndexOf(".") + 1))
        //    {
        //        mFrac = mStr.Substring((mStr.IndexOf(".") + 1));
        //        mStr = mStr.Substring(0, ((mStr.IndexOf(".") + 1) - 1));
        //    }
        //    if (mStr == "")
        //    {
        //        mStr = "0";
        //    }
        //    mFrac = PadR(mFrac, mDec, "0");
        //    if (mInsert)
        //    {
        //        mLen = mStr.Length;
        //        if (gsNMillions)
        //        {
        //            switch (mLen)
        //            {
        //                case 1:
        //                    break;
        //                case 2:
        //                    break;
        //                case 3:
        //                    break;
        //                case 4:
        //                    mStr = (mStr.Substring(0, 1) + ("," + mStr.Substring(1)));
        //                    break;
        //                case 5:
        //                    mStr = (mStr.Substring(0, 2) + ("," + mStr.Substring(2)));
        //                    break;
        //                case 6:
        //                    mStr = (mStr.Substring(0, 3) + ("," + mStr.Substring(3)));
        //                    break;
        //                case 7:
        //                    mStr = (mStr.Substring(0, 1) + ("," + (mStr.Substring(1, 3) + ("," + mStr.Substring(4, 3)))));
        //                    break;
        //                case 8:
        //                    mStr = (mStr.Substring(0, 2) + ("," + (mStr.Substring(2, 3) + ("," + mStr.Substring(5, 3)))));
        //                    break;
        //                case 9:
        //                    mStr = (mStr.Substring(0, 3) + ("," + (mStr.Substring(3, 3) + ("," + mStr.Substring(6, 3)))));
        //                    break;
        //                case 10:
        //                    mStr = (mStr.Substring(0, 1) + ("," + (mStr.Substring(1, 3) + ("," + (mStr.Substring(4, 3) + ("," + mStr.Substring(7, 3)))))));
        //                    break;
        //                case 11:
        //                    mStr = (mStr.Substring(0, 2) + ("," + (mStr.Substring(2, 3) + ("," + (mStr.Substring(5, 3) + ("," + mStr.Substring(8, 3)))))));
        //                    break;

        //                case 12:
        //                    mStr = (mStr.Substring(0, 3) + ("," + (mStr.Substring(3, 3) + ("," + (mStr.Substring(6, 3) + ("," + mStr.Substring(9, 3)))))));
        //            }
        //        }
        //    }
        //    else
        //    {
        //        switch (mLen)
        //        {
        //            case 1:
        //                break;
        //            case 2:
        //                break;
        //            case 3:
        //                break;
        //            case 4:
        //                mStr = (mStr.Substring(0, 1) + ("," + mStr.Substring(1)));
        //                break;
        //            case 5:
        //                mStr = (mStr.Substring(0, 2) + ("," + mStr.Substring(2)));
        //                break;
        //            case 6:
        //                mStr = (mStr.Substring(0, 1) + ("," + (mStr.Substring(1, 2) + ("," + mStr.Substring(3, 3)))));
        //                break;
        //            case 7:
        //                mStr = (mStr.Substring(0, 2) + ("," + (mStr.Substring(2, 2) + ("," + mStr.Substring(4, 3)))));
        //                break;
        //            case 8:
        //                mStr = (mStr.Substring(0, 1) + ("," + (mStr.Substring(1, 2) + ("," + (mStr.Substring(3, 2) + ("," + mStr.Substring(5, 3)))))));
        //                break;
        //            case 9:
        //                mStr = (mStr.Substring(0, 2) + ("," + (mStr.Substring(2, 2) + ("," + (mStr.Substring(4, 2) + ("," + mStr.Substring(6, 3)))))));
        //                break;
        //            case 10:
        //                mStr = (mStr.Substring(0, 3) + ("," + (mStr.Substring(3, 2) + ("," + (mStr.Substring(5, 2) + ("," + mStr.Substring(7, 3)))))));
        //                break;
        //            case 11:
        //                mStr = (mStr.Substring(0, 4) + ("," + (mStr.Substring(4, 2) + ("," + (mStr.Substring(6, 2) + ("," + mStr.Substring(8, 3)))))));
        //                break;
        //            case 12:
        //                mStr = (mStr.Substring(0, 5) + ("," + (mStr.Substring(5, 2) + ("," + (mStr.Substring(7, 2) + ("," + mStr.Substring(9, 3)))))));
        //                break;
        //        }
        //    }
        //}

        //public string EqsnExecuteCMD(object mObject, string mEqsn)
        //{
        //    string[] mArr;
        //    // Warning!!! Optional parameters not supported
        //    int n;
        //    // TODO: On Error GoTo Warning!!!: The statement is not translatable 
        //    mArr = mEqsn.Split("::");
        //    for (n = 0; (n <= (mArr).GetUpperBound); n++)
        //    {
        //        if ((Missing.Value(mVar) == false))
        //        {
        //            EqsnExecuteCMD = GridEqsnExecute(mObject, mArr[n], ((mVar != 0) ? mVar : 0), 0, true);
        //        }
        //        else
        //        {
        //            EqsnExecuteCMD = GridEqsnExecute(mObject, mArr[n], 0, 0, true);
        //        }
        //    }
        //    // TODO: Exit Function: Warning!!! Need to return the value
        //    return "Error";
        //}

        //public string CalExecute(string mEq)
        //{
        //    int X = 1, n = 1;
        //    string[] mP;
        //    string[] mO;
        //    while (true)
        //    {
        //        if (String.InStr("*/+-", mID(mEq, n, 1) != 0))
        //        {
        //            int[] temp = new int[X - 1];
        //            int[] temp1 = new int[X - 1];
        //            if (temp != null)
        //            {
        //                Array.Copy(mP, temp, Math.Min(mP.Length, temp.Length));
        //                temp = mP;
        //            }
        //            if (temp1 != null)
        //            {
        //                Array.Copy(mO, temp1, Math.Min(mO.Length, temp1.Length));
        //                temp1 = mO;
        //            }
        //        }
        //        var xx = new List<string>();
        //        if (InSt("*/+-", mEq.Substring(n, 1)) != 0)
        //        {
        //            int[] temp = new int[X - 1];
        //            int[] temp1 = new int[X - 1];
        //            mP[X - 1] = mEq.Left(n, 1);
        //            mO[X - 1] = mEq.Substring(n, 1);
        //            mEq = mEq.Substring(n + 1);
        //            X = X + 1;
        //            n = 1;
        //        }
        //        n = n + 1;
        //        if (mEq = "" || n >= (mEq).Length)
        //        {
        //            break;
        //        }

        //    }
        //    if (mEq == "")
        //    {
        //        int[] temp = new int[X - 1];
        //        int[] temp1 = new int[X - 1];
        //        mP[X - 1] = mEq;
        //        mO[X - 1] = "";
        //    }
        //    foreach (var X in mP)
        //    {
        //        mP[X] = mP[X].ToString();
        //        CalExecute = mP[0].ToString();
        //    }
        //}
        //public string Round5(decimal mValue, int mRound)
        //{
        //    string mRoundVal = string.Empty;
        //    int mLastDigit;
        //    double DecShift;
        //    DecShift = 10 ^ mRound;
        //    int round5_1 = Convert.ToInt16(System.Math.Round(mValue, mRound));
        //    mLastDigit = ((round5_1 * 10) ^ mRound) % 10;
        //    if (mLastDigit > 5)
        //    {
        //        mRoundVal = (round5_1 + ((10 - mLastDigit) / DecShift)).ToString();
        //    }
        //    else
        //    {
        //        mRoundVal = round5_1 + ((5 - mLastDigit) / DecShift).ToString();
        //    }
        //    return mRoundVal;
        //}

        //string m5, 
        //public string nRound(decimal mAmt, int mRound, int gsCurrDec, decimal mValue, int mRoundMode)
        //{
        //    string nRoundVals = string.Empty;
        //    string strMval = string.Empty;
        //    string mDec = string.Empty;
        //    string mDecStr = string.Empty;
        //    decimal mDigit;
        //    //if (m5 != "")
        //    //{
        //    //    nRoundVals = Round5(mValue, mRound).ToString();
        //    //}
        //    //else
        //    //{
        //    mDec = (mValue - Convert.ToInt32(mValue)).ToString();
        //    mDecStr = PadR(Convert.ToString(mDec).TrimStart(), 3, "0");
        //    //}
        //    switch (mRoundMode)
        //    {
        //        case 0:
        //            if ((mRound == 0) && (mDec == ""))
        //            {
        //                mValue = (Convert.ToInt32(mValue) + 1);
        //            }
        //            else
        //            {
        //                if ((mRound == 2) && (mDec.Length > 4))
        //                {
        //                    if (mDec.Substring(4, 1) == "5")
        //                    {
        //                        strMval = (mValue + "0.001");
        //                    }
        //                    mValue = System.Math.Round(mValue, mRound);
        //                }
        //            }
        //            break;
        //        case 1:
        //            if (Convert.ToInt32(mValue) != mValue)
        //            {
        //                mValue = (Convert.ToInt32(mValue) + 1);
        //            }
        //            break;
        //        case 2:
        //            mValue = Convert.ToInt32(mValue);
        //            break;
        //        case 3:
        //            mValue = Math.Round(mValue, gsCurrDec);
        //            break;
        //        default:
        //            mDigit = Convert.ToDecimal(mDecStr.Substring(2, 1));
        //            switch (mRoundMode)
        //            {
        //                case 4:
        //                    // nearest 0.05
        //                    mDigit = (((mDigit <= 5) ? ((mDigit < 3) ? (mDigit * -1) : (5 - mDigit)) : ((mDigit < 8) ? ((mDigit - 5) * -1) : (10 - mDigit))) / 100);
        //                    break;
        //                case 5:
        //                    // nearest 0.1
        //                    mDigit = (((mDigit < 5) ? (mDigit * -1) : (10 - mDigit)) / 100);
        //                    break;
        //                case 6:
        //                    // upward 0.05
        //                    mDigit = (((mDigit <= 5) ? (5 - mDigit) : (10 - mDigit)) / 100);
        //                    break;
        //                case 7:
        //                    // upward 0.1
        //                    mDigit = ((mDigit != 0) ? ((10 - mDigit) / 100) : 0);
        //                    break;
        //                case 8:
        //                    // downward 0.05
        //                    mDigit = (((mDigit != 0) && (mDigit != 5)) ? (((mDigit <= 5) ? (mDigit * -1) : ((mDigit - 5) * -1)) / 100) : 0);
        //                    break;
        //                case 9:
        //                    // downward 0.1
        //                    mDigit = ((mDigit != 0) ? ((mDigit / 100) * -1) : 0);
        //                    break;
        //            }
        //            mValue = (mValue + mDigit);
        //            break;
        //    }
        //    return mValue.ToString();
        //    // Calculation of nFormate
        //    //nFormat = (mSign + (mStr + ((mDec != 0) ? ("." + mFrac) : "")));
        //}

        //public bool FindTaxDetails()
        //{

        //}

        //public string nRound()
        //{
        //    string mTest = string.Empty;
        //    return mTest;
        //}
        //public string nRound(string mmr)
        //{
        //    string mTest = string.Empty;
        //    return mTest;
        //}
        //public string nRound(ref bool mCalTax,int mTxbl, int mSTP, decimal mVatDec, decimal gpRoundVAT)
        //{
        //    decimal mSTP;
        //    decimal mTxbl;
        //    // decimal mTxbl; 
        //    //double mTxbl;
        //    // Byte  gsCurrDec;
        //    var Query = (from a in ctx.ServiceTaxRates
        //                 where a.Code == "000001"
        //                 select new { a.STRate, a.STCess, a.STSheCess, a.Abatement }).ToList();
        //    string mVal = string.Empty;// string _TaxAmt =
        //    string _TaxAmt = string.Empty;
        //    _TaxAmt = nRound(_Amount, 1, 1, 1, 1);
        //    decimal _mTax;
        //    string _mSerChrg = "3";
        //    string _mCess = "4";
        //    string  mAmt;
        //    //return mVal = _TaxAmt + "~" + _mTax + "~" + _mSerChrg + "~" + _mCess;
        //    return mVal = CalAll(false, false).ToString();
        //    string mTest = string.Empty;

        //    if (mCalTax)
        //    {
        //        // If gpSTRound = False Then
        //        _TaxAmt = nRound((mTxbl * (mSTP / 100)), mVatDec, gpRoundVAT);
        //        _mTax = nRound((mTxbl * (_mTax / 100)), mVatDec, gpRoundVAT);
        //        _mCess = nRound((_TaxAmt * (mCessTax / 100)), mVatDec, gpRoundVAT);
        //        _mSerChrg = nRound((_TaxAmt * (_mSerChrg / 100)), mVatDec, gpRoundVAT);
        //        mTxbl = nRound((mAmt + (_TaxAmt + (_TaxAmt + (_mCess + _mSerChrg)))), gsCurrDec);
        //        mAmt = mTxbl.ToString();
        //    }
        //    return mTest;
        //}

        //public string Right(string value, int length)
        //{
        //    return value.Substring(value.Length - length);
        //}
        //public string Left(string value, int length)
        //{
        //    return value.Substring(value.Length - length);
        //}
    }
}













