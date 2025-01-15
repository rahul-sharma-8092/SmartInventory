<%@ Page Title="Add Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUpdateCategories.aspx.cs" Inherits="SmartInventory.Home.Settings.AddUpdateCategories" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mb-2">Add / Update Categories</h2>
        <asp:Panel ID="pnlCategoryForm" runat="server" CssClass="card p-4">
            <div class="row mb-3">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblCategoryName" runat="server" AssociatedControlID="txtCategoryName" CssClass="form-label">Category Name:</asp:Label>
                        <div class="form-wrap">
                            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" Placeholder="Enter category name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqCategoryName" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="Required" CssClass="callout"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblParentCategory" runat="server" AssociatedControlID="ddlParentCategory" CssClass="form-label">Parent Category:</asp:Label>
                        <div class="form-wrap">
                            <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Select Parent Category" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription" CssClass="form-label">Description:</asp:Label>
                        <div class="form-wrap">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Placeholder="Enter category description"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group form-check">
                        <asp:CheckBox ID="chkIsActive" Text="Is Active" runat="server" CssClass="form-check-input" Checked="true" />
                    </div>
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary me-2" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false" />
            </div>
        </asp:Panel>
    </div>

    <asp:HiddenField ID="hdnCategoryId" runat="server" />
</asp:Content>
