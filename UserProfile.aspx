<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="UniPreperation.UserProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-card">
        <h2>My Profile</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br /><br />

        <label style="float: left; font-weight: bold;">Username</label>
        <asp:TextBox ID="txtUsername" runat="server" ReadOnly="true" BackColor="#eee"></asp:TextBox>

        <label style="float: left; font-weight: bold;">Email Address</label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>

        <label style="float: left; font-weight: bold;">New Password</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Leave blank to keep current"></asp:TextBox>

        <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" 
            OnClick="btnUpdate_Click" CssClass="btn-primary" />

        <hr style="margin: 20px 0;" />

        <p style="color: #666; font-size: 14px;">Danger Zone</p>
        <asp:Button ID="btnDelete" runat="server" Text="Delete My Account" 
            OnClick="btnDelete_Click" 
            CssClass="btn-primary" Style="background-color: #d9534f;"
            OnClientClick="return confirm('Are you sure? This cannot be undone.');" />
    </div>
</asp:Content>