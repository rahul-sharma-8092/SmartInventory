<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPassword.aspx.cs" Inherits="SmartInventory.Home.SetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Set Password - SmartInventory</title>

    <link href="../Content/bootstrap4.5.2.min.css" rel="stylesheet" />
    <%: System.Web.Optimization.Scripts.Render("~/bundles/JQueryWithCommonJS") %>

    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Arial', sans-serif;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
        }

        .forgot-password-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
        }

            .forgot-password-container h3 {
                text-align: center;
                margin-bottom: 30px;
                color: #007bff;
            }

        .form-group label {
            font-weight: bold;
        }

        .form-control {
            border-radius: 4px;
            padding: 15px;
            font-size: 16px;
        }

        .btn-submit {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            border: none;
            color: white;
            border-radius: 4px;
        }

            .btn-submit:hover {
                background-color: #0056b3;
            }

        .back-to-login {
            text-align: center;
            margin-top: 10px;
        }

            .back-to-login a {
                color: #007bff;
                text-decoration: none;
            }

                .back-to-login a:hover {
                    text-decoration: underline;
                }

        .brand-name {
            text-align: center;
            font-size: 40px;
            font-weight: bold;
            margin-bottom: 20px;
            color: #007bff;
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

        .error-message {
            text-align: center;
            color: #dc3545;
            font-size: 18px;
            margin-top: 10px;
            white-space: nowrap;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="forgot-password-container">
            <!-- Project Name -->
            <div class="brand-name">Smart Inventory</div>

            <div id="formDiv" runat="server">
                <!-- Set Password Form -->
                <h3>Set Password</h3>

                <!-- Password Field -->
                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TabIndex="1" Placeholder="Enter your password" />
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" CssClass="validation-error" Display="Dynamic" ValidationGroup="setPassword" />
                    <asp:RegularExpressionValidator ID="regexPassword" runat="server" ControlToValidate="txtPassword" CssClass="validation-error" Display="Dynamic" ValidationGroup="setPassword" />
                </div>

                <!-- Confirm Password Field -->
                <div class="form-group">
                    <label for="txtConfirmPassword">Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TabIndex="2" TextMode="Password" Placeholder="Confirm your password" />
                    <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="validation-error" Display="Dynamic" ValidationGroup="setPassword" />
                </div>

                <!-- Submit Button -->
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="3" CssClass="btn btn-submit" OnClick="btnSubmit_Click" ValidationGroup="setPassword" />

            </div>
            <!-- Invalid or Expired Link -->
            <div id="errorMessage" runat="server" class="error-message" visible="false">
                Invalid or Expired Link. Please try again.
            </div>

            <div class="back-to-login">
                <a tabindex="4" href="./Login.aspx">Back to Login</a>
            </div>
        </div>
    </form>
</body>
</html>
