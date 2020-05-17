<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorViewRatings.aspx.cs"
    Inherits="SecureMedicalRecord.VisitorViewRatings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Secure Medical Record</title>
    <style type="text/css">
        .Star
        {
            background-image: url(Photos/Star.gif);
            height: 17px;
            width: 17px;
        }
        .WaitingStar
        {
            background-image: url(Photos/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }
        .FilledStar
        {
            background-image: url(Photos/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
    <!-- Meta-Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <meta name="keywords" content="Elite login Form a Responsive Web Template, Bootstrap Web Templates, Flat Web Templates, Android Compatible Web Template, Smartphone Compatible Web Template, Free Webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design">
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta-Tags -->
    <!-- Stylesheets -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="css/style_css.css" rel='stylesheet' type='text/css' />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!--// Stylesheets -->
    <!--fonts-->
    <link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,200i,300,300i,400,400i,600,600i,700,700i,900,900i"
        rel="stylesheet">
    <!--//fonts-->
</head>
<body>
    <h1>
        Doctor Rating's</h1>
    <div class="w3ls-login">
        <!-- form starts here -->
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="agile-field-txt">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="agile-field-txt">
                        <label>
                            <i class="fa fa-user" aria-hidden="true"></i>Select Department:</label>
                        <asp:DropDownList ID="ddlDept" runat="server" 
                            onselectedindexchanged="ddlDept_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <asp:GridView ID="GridView1" class="table table-striped table-bordered table-hover"
                        runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="HospitalName" HeaderText="Hospital Name" />
                            <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
                            <asp:TemplateField HeaderText="Ratings">
                                <ItemTemplate>
                                    <asp:Rating ID="Rating2" AutoPostBack="true" runat="server" StarCssClass="Star" WaitingStarCssClass="WaitingStar"
                                        EmptyStarCssClass="Star" FilledStarCssClass="FilledStar" CurrentRating='<%# Eval("Ratings") %>'>
                                    </asp:Rating>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="w3ls-login  w3l-sub">
				<asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                            
                            <asp:Button ID="btnHome" runat="server" Text="Home" onclick="btnHome_Click" />
			</div>
        </div>
        <!-- //script for show password -->
        </form>
    </div>
    <!-- //form ends here -->
    <!--copyright-->
    <div class="copy-wthree">
        <p>
            © 2020 Secure Medical Record . All Rights Reserved | Design by Secure Medical Record
        </p>
    </div>
    <!--//copyright-->
</body>
</html>
