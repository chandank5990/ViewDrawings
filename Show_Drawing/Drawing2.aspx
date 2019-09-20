<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Drawing2.aspx.cs" Inherits="Points_Pending_Supplier.Drawing2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" 
            style="z-index: 1; left: 213px; top: 0px; position: absolute; height: 22px;" 
            Text="PC" onclick="Button1_Click" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            style="z-index: 1; left: 276px; top: 1px; position: absolute; height: 21px" 
            Text="PDF" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
            style="z-index: 1; left: 245px; top: 0px; position: absolute; right: 830px; height: 22px" 
            Text="PT" />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" 
            style="z-index: 1; left: 0px; position: absolute; height: 523px; width: 482px; top: 22px;" 
            ImageAlign="Middle" 
            
            />
    
    </div>
    </form>
</body>
</html>
