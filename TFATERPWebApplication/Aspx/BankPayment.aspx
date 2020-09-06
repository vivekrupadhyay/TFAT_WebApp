<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankPayment.aspx.cs" Inherits="TFATERPWebApplication.Aspx.BankPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/comman/BankPayment.css" rel="stylesheet" />

    <link href="../Content/Site.css" rel="stylesheet" />

</head>
<body >
    <form id="form1" runat="server">

        <div align="center">

            <div style="width: 90%; border: solid 1px steelblue;font-family:Tahoma;font-size:11px;">
                <div class="gridheaderleft">Cash/Bank Data Entry</div>
                <div class="boxcontenttext" >
                    <table>
                        <tr>
                            <td width="40%" style="border-right: 1px solid #d4d2d2; padding-left: 5px;">
                                <table>
                                    <tr>
                                        <td class="lblheading">Vouchar Date</td>
                                        <td>
                                            <asp:TextBox ID="ValueDate" runat="server" Width="158px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="lblheading">Last Vouchar No</td>
                                        <td>
                                            <asp:TextBox ID="Prefix" runat="server" Width="50px"></asp:TextBox><asp:TextBox ID="Srl" runat="server" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="lblheading">Vouchar No</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox><asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>

                                </table>
                            </td>
                            <td width="20%" style="border-right: 1px solid #d4d2d2; padding-left: 5px;">
                                <table>
                                    <tr>

                                        <td class="lblheading">
                                            <asp:LinkButton Text="Cash Bank" runat="server"></asp:LinkButton></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Cheque" runat="server" Width="280px"></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="lblheading">
                                            <asp:Label Text="Amount INR:" runat="server"></asp:Label>&nbsp;</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>

                                </table>
                            </td>
                            <td width="20%" style="padding-left: 5px;">
                                <table>
                                    <tr>
                                        <td class="lblheading">
                                            <asp:Label Text="Balance" runat="server"></asp:Label></td>
                                        <td class="lblheading">
                                            <asp:Label Text="0.00 Dr." runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="lblheading">
                                            <asp:Label Text="OD Limit" runat="server"></asp:Label></td>
                                        <td class="lblheading">
                                            <asp:Label Text="0.00 Dr." runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="lblheading">Usable</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>
                   

                                <div>
                                    <asp:GridView ID="GvLedgerBranch" runat="server" AutoGenerateColumns="False" Width="99%" GridLines="Both" 
                                         AlternatingRowStyle-CssClass="alt"
                                        CssClass="gridview" CellPadding="5" CellSpacing="2" HorizontalAlign="Justify" >
                                        <AlternatingRowStyle CssClass="gridViewAltRow"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:BoundField DataField="Sno" HeaderText="SrNo." />
                                            <asp:BoundField DataField="Branch" HeaderText="Plan/BU" />
                                            <asp:BoundField DataField="Code" HeaderText="Code" />
                                            <asp:BoundField DataField="BankCode" HeaderText="Account Description" />
                                            <asp:BoundField DataField="SubType" HeaderText="Sub Ldgr" />
                                            <asp:BoundField DataField="Debit" HeaderText="Debit (INR)" />
                                            <asp:BoundField DataField="Debit" HeaderText="Credit (INR)" />
                                            <asp:BoundField DataField="CostCentre" HeaderText="Cost Center" />
                                            <asp:BoundField DataField="ChqCategory" HeaderText="Profit Center" />
                                            <asp:BoundField DataField="Cheque" HeaderText="Cheque" />
                                            <asp:BoundField DataField="Narr" HeaderText="Narration" />
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle CssClass="gridViewHeader"  />

                                        
                                        <RowStyle CssClass="gridViewRow" />
                                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </div>
                    <div>&nbsp;</div>
                    <div>
                        <table>
                            <tr><td><asp:b</td></tr>
                        </table>


                    </div>
                           
                </div>
            </div>


        </div>
    </form>
</body>
</html>
