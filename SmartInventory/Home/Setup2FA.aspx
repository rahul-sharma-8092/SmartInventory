<%@ Page Title="Setup 2FA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setup2FA.aspx.cs" Inherits="SmartInventory.Home.Setup2FA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .brand-name {
            text-align: center;
            font-size: 40px;
            font-weight: bold;
            margin-bottom: 20px;
            color: #007bff;
        }

        .setup-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 500px;
            margin: 0px auto;
        }

            .setup-container h3 {
                text-align: center;
                margin-bottom: 20px;
                color: #007bff;
            }

        .qr-code-section {
            text-align: center;
            margin-bottom: 20px;
        }

            .qr-code-section img {
                max-width: 200px;
                border: 2px solid #ddd;
                border-radius: 8px;
                padding: 5px;
            }

        .instructions {
            text-align: center;
            margin-bottom: 20px;
            font-size: 14px;
        }

        .form-control {
            border-radius: 4px;
            padding: 15px;
            font-size: 16px;
        }

        .btn-verify {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            border: none;
            color: white;
            border-radius: 4px;
            margin-top: 10px;
        }

            .btn-verify:hover {
                background-color: #0056b3;
            }

        .message-label {
            text-align: center;
            margin-top: 15px;
            font-weight: bold;
        }

        .validation-error {
            position: absolute;
            top: -1px;
            right: 0px;
            background-color: #dc3545;
            color: white;
            padding: 5px;
            font-size: 12px;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            display: none;
            z-index: 1;
        }

        .form-group {
            position: relative;
        }

        .validation-error.active {
            display: block;
        }

        .validation-error::after {
            content: "";
            position: absolute;
            top: 100%;
            left: 50%;
            margin-left: -5px;
            border-left: 5px solid transparent;
            border-right: 5px solid transparent;
            border-top: 5px solid #dc3545;
        }
        input{max-width: 100%;}
    </style>
    <div class="setup-container">
        <div class="brand-name text-center">
            Smart Inventory
        </div>
        <h3>Setup Two-Factor Authentication</h3>
        <p class="instructions">
            Scan the QR code below with a TOTP-compatible app like <b>Google Authenticator</b> or Microsoft Authenticator.
        </p>

        <!-- QR Code Section -->
        <div class="qr-code-section">
            <asp:Literal ID="LiteralQRCode" runat="server"></asp:Literal>
            <%--<p>
                Manual Key: 
                <strong><asp:Label ID="LabelSecretKey" runat="server"></asp:Label></strong>
            </p>--%>
            <div class="qr-image">
                <asp:Image ID="imgQrCode" AlternateText="QR-Code" runat="server" />
            </div>
        </div>

        <!-- Code Verification -->
        <div class="form-group">
            <label for="txtVerificationCode">Enter Verification Code</label>
            <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="form-control" Placeholder="Enter the code from your app"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqVerificationCode" runat="server" ControlToValidate="txtVerificationCode" ErrorMessage="Required" CssClass="validation-error" ValidationGroup="add"></asp:RequiredFieldValidator>
        </div>

        <!-- Verify Button -->
        <asp:Button ID="BtnVerify" runat="server" ValidationGroup="add" Text="Verify Code" CssClass="btn btn-verify" OnClick="BtnVerify_Click" />
    </div>
</asp:Content>