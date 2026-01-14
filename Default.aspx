<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UniPreperation._Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="hero-section">
        <h1>Welcome to UniPrep</h1>
        <p>The easiest way to share notes, slides, and past year papers.</p>
        
        <% if (Session["user_id"] == null) { %>
            <a href="Register.aspx" style="color: white; font-weight: bold; text-decoration: underline; font-size: 18px;">Get Started for Free</a>
        <% } else { %>
             <h3>Welcome back, <%= Session["username"] %>!</h3>
             <a href="ViewResources.aspx" style="color: white; border: 1px solid white; padding: 10px 20px; text-decoration: none; border-radius: 5px;">Browse Resources</a>
        <% } %>
    </div>

    <div style="display: flex; justify-content: space-around; text-align: center; padding: 20px;">
        <div style="width: 30%;">
            <h3>📂 Upload Notes</h3>
            <p>Share your knowledge by uploading PDFs and slides.</p>
        </div>
        <div style="width: 30%;">
            <h3>⬇️ Download</h3>
            <p>Get access to hundreds of past year papers instantly.</p>
        </div>
        <div style="width: 30%;">
            <h3>🔒 Secure</h3>
            <p>Only verified students can access the material.</p>
        </div>
    </div>

</asp:Content>
