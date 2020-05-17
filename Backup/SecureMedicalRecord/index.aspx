<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SecureMedicalRecord.index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="myModalLogin" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Login</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>
                            UserType</label>
                        <asp:DropDownList ID="ddlUserType" runat="server" class="form-control" autofocus>
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">Receptionist</asp:ListItem>
                            <asp:ListItem Value="3">Doctor</asp:ListItem>
                            <asp:ListItem Value="4">Lab Staff</asp:ListItem>
                            <asp:ListItem Value="5">Patient</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlUserType"
                            ForeColor="#FF3300" ValidationGroup="B" InitialValue="0" runat="server" ErrorMessage="Please User Type"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>
                            User Id</label>
                        <asp:TextBox ID="txtUserId" class="form-control" runat="server" placeholder="Enter User Id"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter User Id"
                            ControlToValidate="txtUserId" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>
                            Password</label>
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Password"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Password"
                            ControlToValidate="txtPassword" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" OnClick="btnSubmit_Click"
                        Text="Submit" ValidationGroup="B" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
