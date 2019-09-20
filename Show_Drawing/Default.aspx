<%@ Page Title="VIEW DRAWINGS" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Show_Drawing._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="TextBox1" runat="server" CssClass="style1" 
            style="font-weight: 700; font-style: italic; text-align: center"></asp:TextBox>
&nbsp;
    
        <asp:Button ID="Button1" runat="server" 
            style="z-index: 1; left: 213px; top: 0px;height: 22px; font-weight: 700; font-style: italic;" 
            Text="PC" onclick="Button1_Click" CssClass="style1" />
        &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
            style="z-index: 1; left: 245px; top: 0px;right: 830px; height: 22px; font-weight: 700; font-style: italic;" 
            Text="PT" CssClass="style1" />
        &nbsp;<asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            style="z-index: 1; left: 276px; top: 1px;height: 21px; font-weight: 700; font-style: italic;" 
            Text="Download" CssClass="style1" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" 
            style="font-weight: 700; text-decoration: underline; font-style: italic; font-size: large; color: #FFFF00; font-family: 'Baskerville Old Face'; background-color: #999999" 
            Text="DRAWINGS"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" 
            style="z-index: 1; left: 0px;top: 22px;" 
            ImageAlign="Middle" Width="920px" 
            
            />
    
    </div>
</asp:Content>
