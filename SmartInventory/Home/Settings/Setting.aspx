<%@ Page Title="Setting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="SmartInventory.Home.Settings.Setting" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mb-2">Settings</h2>
        <div class="list-group">
            <a runat="server" id="lnkCategories" class="list-group-item list-group-item-action">Categories</a>
            <a runat="server" id="lnkConfigurations" class="list-group-item list-group-item-action">Configurations</a>
        </div>
    </div>
</asp:Content>