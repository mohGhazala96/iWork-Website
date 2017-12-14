﻿<%@ Page Language="C#" Inherits="iWork.View_Emails" EnableEventValidation="false"%>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>View_Emails</title>
</head>
<body>
    <% if(Session["Username"] != null){ 
    Response.WriteFile("Pages/menu.inc");
    } else if(Session["Username"] == null){
    Response.WriteFile("Pages/unsigned-menu.inc");
    }
    %>
	<form id="View_Emails_Form" runat="server">
          <asp:Panel id="ViewEmails" runat="server">

          </asp:Panel>

          <asp:Panel id="ReadEmails" runat="server">
            <asp:Label id="lbl_sender" runat="server" Text="From: "></asp:Label>
            <asp:Label id="lbl_sender_name" runat="server" Text=""></asp:Label><br />
            <asp:Label id="lbl_subject" runat="server" Text="Subject: "></asp:Label>
            <asp:Label id="lbl_subject_text" runat="server" Text=""></asp:Label><br />
            <asp:Label id="lbl_body_text" runat="server" Text="" style="width:500px;"></asp:Label><br />
            <asp:Button id="btn_back" runat="server" Text="Back" OnClick="backToEmails"></asp:Button>
          </asp:Panel>
	</form>
        <!--#include file="Pages/footer.inc"-->
</body>
</html>
