﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="iWork.Companies.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">    
             <Columns>    
                 <asp:BoundField DataField="name" HeaderText="Company Name" ItemStyle-Width="150" />
                 <asp:BoundField DataField="type" HeaderText="Company Type" ItemStyle-Width="150" />
                 <asp:HyperLinkField DataNavigateUrlFields="email" DataNavigateUrlFormatString="/Companies.aspx?email={0}" Text="View Company" />
             </Columns>    
            </asp:GridView>
        </div>
    </form>
</body>
</html>
