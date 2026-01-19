<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="UniPreperation.About" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .about-text {
        color: #555;
        line-height: 1.6;
    }
</style>

<div class="about-text">
    <h2>About UniPrep</h2>
    ...
</div>
    <div style="padding: 20px;">
        <h2>About UniPrep</h2>
        <p style="font-size: 18px; color: #555;">
            UniPrep is a student-led initiative designed to make sharing study resources easier.
        </p>
        
        <br />
        
        <h3>Our Mission</h3>
        <p>
            We believe that education should be accessible to everyone. By allowing students to upload
            notes, past year papers, and lecture slides, we create a community of shared knowledge.
        </p>

        <br />
        
        <h3>Contact Us</h3>
        <p>
            Have questions? Email us at: <strong>support@uniprep.com</strong>
        </p>
    </div>
</asp:Content>