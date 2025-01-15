<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SmartInventory.Home.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%: System.Web.Optimization.Scripts.Render("~/bundles/JQueryWithCommonJS") %>
    <h1>
        <asp:Literal ID="ltr1" Text="" runat="server" />
    </h1>
</asp:Content>
