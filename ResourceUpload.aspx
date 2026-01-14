<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceUpload.aspx.cs" Inherits="UniPreperation.Uploads.ResourceUpload" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px; font-family: Arial, sans-serif;">
        <h2>Upload Learning Resource</h2>
        <p>Share your notes or past years with the community.</p>

        <p>
            <label>Resource Title:</label><br />
            <asp:TextBox ID="txtTitle" runat="server" Width="300px" required="true"></asp:TextBox>
        </p>

        <p>
            <label>Subject Code (e.g., CT050):</label><br />
            <asp:TextBox ID="txtCode" runat="server" Width="100px" required="true"></asp:TextBox>
        </p>

        <p>
            <label>Resource Type:</label><br />
            <asp:DropDownList ID="ddlType" runat="server" Height="30px">
                <asp:ListItem>Past Year</asp:ListItem>
                <asp:ListItem>Lecture Slides</asp:ListItem>
                <asp:ListItem>Notes</asp:ListItem>
                <asp:ListItem>Tutorial</asp:ListItem>
            </asp:DropDownList>
        </p>

        <p>
            <label>Description:</label><br />
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="300px"></asp:TextBox>
        </p>

        <p>
            <label>Select File (PDF, IMG, DOC only):</label><br />
            <asp:FileUpload ID="fileUploadCtx" runat="server" />
        </p>

        <p>
            <asp:Button ID="btnUpload" runat="server" Text="Upload Now" 
                OnClick="btnUpload_Click" BackColor="#0066cc" ForeColor="White" Height="40px" />
        </p>

        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
