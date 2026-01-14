<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewResources.aspx.cs" Inherits="UniPreperation.ViewResources" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 20px;">

        <h2>Learning Resources</h2>

        

        <div style="margin-bottom: 20px;">

            <asp:TextBox ID="txtSearch" runat="server" Placeholder="Search by Title or Subject..." Height="30px" Width="200px"></asp:TextBox>

            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Height="30px" />

        </div>



        <asp:GridView ID="gvResources" runat="server" AutoGenerateColumns="False" 

            CssClass="table table-striped" GridLines="None" Width="100%" 

            EmptyDataText="No resources found.">

            

            <Columns>

                <asp:BoundField DataField="title" HeaderText="Title" />

                <asp:BoundField DataField="subject_code" HeaderText="Subject" />

                <asp:BoundField DataField="type" HeaderText="Type" />

                <asp:BoundField DataField="username" HeaderText="Uploaded By" />

                <asp:BoundField DataField="status" HeaderText="Status" />

                

                <asp:TemplateField HeaderText="Action">

                    <ItemTemplate>

                        <a href='<%# "Uploads/" + Eval("file_link") %>' target="_blank">Download</a>

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

            

            <HeaderStyle BackColor="#333333" ForeColor="White" />

        </asp:GridView>

    </div>

</asp:Content> 

