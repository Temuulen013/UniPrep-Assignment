<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UniPreperation.Register" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px; font-family: Arial, sans-serif;">
        <h2>Join UniPrep</h2>
        
        <p>
            <label>Username:</label><br />
            <asp:TextBox ID="txtUsername" runat="server" required="true"></asp:TextBox>
        </p>
        
        <p>
            <label>Email Address:</label><br />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" required="true"></asp:TextBox>
        </p>

        <p>
            <label>Password:</label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="true"></asp:TextBox>
        </p>

        <p>
            <asp:Button ID="btnRegister" runat="server" Text="Sign Up" 
                OnClick="btnRegister_Click" BackColor="#333333" ForeColor="White" Height="40px" Width="100px" />
        </p>

        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
