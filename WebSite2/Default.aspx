<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
.GridviewDiv {font-size: 100%; font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif; color: #303933;}
.headerstyle
{
color:#FFFFFF;border-right-color:#abb079;border-bottom-color:#abb079;background-color: #df5015;padding:0.5em 0.5em 0.5em 0.5em;text-align:center;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="gvImages" CssClass="Gridview" runat="server" AutoGenerateColumns="False">
<HeaderStyle CssClass="headerstyle" />
<Columns>
<asp:BoundField HeaderText = "Image Name" DataField="pid" />
<asp:TemplateField HeaderText="Image">
<ItemTemplate>
<asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID=" + Eval("pimg") %>' Height="150px" Width="150px"/>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
    
    
    
    </div>
    </form>
</body>
</html>
