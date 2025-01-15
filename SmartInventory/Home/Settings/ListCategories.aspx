<%@ Page Title="List Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCategories.aspx.cs" Inherits="SmartInventory.Home.Settings.ListCategories" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Home/JS/ListCategories.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <!-- Header Row -->
        <div class="text-center mb-3 header-row">
            <h2 class="text-center">Category Management</h2>
            <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" CssClass="mybutton btn btn-primary" />
        </div>

        <!-- Kendo Grid for displaying categories -->
        <div id="categoryGrid" class="kendo-grid"></div>
    </div>

    
</asp:Content>
