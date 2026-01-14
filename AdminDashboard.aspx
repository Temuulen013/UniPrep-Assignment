<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="UniPreperation.AdminDashboard" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px;">
        <h2>Administrator Dashboard</h2>
        <p>Manage uploaded resources below.</p>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

        <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" 
            CssClass="table table-bordered" DataKeyNames="resource_id"
            OnRowCommand="gvAdmin_RowCommand">
            
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" />
                <asp:BoundField DataField="username" HeaderText="Uploaded By" />
                <asp:BoundField DataField="status" HeaderText="Current Status" />
                
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" 
                            CommandName="ApproveResource" 
                            CommandArgument='<%# Eval("resource_id") %>' 
                            CssClass="btn btn-success btn-sm" />
                        
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                            CommandName="DeleteResource" 
                            CommandArgument='<%# Eval("resource_id") %>' 
                            CssClass="btn btn-danger btn-sm" 
                            OnClientClick="return confirm('Are you sure you want to delete this?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>