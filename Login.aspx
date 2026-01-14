<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UniPreperation.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-card"> <h2>Login</h2>
        <p style="color: #666; margin-bottom: 20px;">Please enter your credentials</p>

        <label style="float: left; font-weight: bold;">Email Address</label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" required="true" placeholder="student@example.com"></asp:TextBox>

        <label style="float: left; font-weight: bold;">Password</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="true" placeholder="Enter password"></asp:TextBox>

        <asp:Button ID="btnLogin" runat="server" Text="Log In" 
            OnClick="btnLogin_Click" CssClass="btn-primary" /> <br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div> </asp:Content>