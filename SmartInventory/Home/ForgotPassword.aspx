<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="SmartInventory.Home.ForgotPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password - SmartInventory</title>
    <!-- Link to Bootstrap CSS -->
    <link href="../Content/bootstrap4.5.2.min.css" rel="stylesheet" />
    <!-- Custom Styles -->
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
            max-width: 400px;
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

        .btn-reset {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            border: none;
            color: white;
            border-radius: 4px;
        }

            .btn-reset:hover {
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

        /* CSS for RequiredFieldValidator Callout */
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
            display: none; /* Hide by default */
            z-index: 1; /* Ensure it's on top of the input field */
        }

        .form-group {
            position: relative; /* To allow absolute positioning of validation error */
        }

        /* Show validation error when triggered */
        .validation-error.active {
            display: block;
        }

        /* Create the arrow pointing downwards */
        .validation-error::after {
            content: "";
            position: absolute;
            top: 100%; /* Position the arrow below the callout */
            left: 50%;
            margin-left: -5px; /* Adjust the arrow to center it */
            border-left: 5px solid transparent;
            border-right: 5px solid transparent;
            border-top: 5px solid #dc3545; /* Color of the arrow */
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="forgot-password-container">
            <!-- Project Name -->
            <div class="brand-name">Smart Inventory</div>

            <!-- Forgot Password Form -->
            <h3>Forgot Your Password?</h3>

            <!-- Email Field -->
            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email" />
                <!-- Custom RequiredFieldValidator for email -->
                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Required" CssClass="validation-error" Display="Dynamic"
                    ValidationGroup="forgotPassword" />
            </div>

            <!-- Reset Button -->
            <asp:Button ID="btnReset" runat="server" Text="Reset Password" CssClass="btn btn-reset" OnClick="btnReset_Click" ValidationGroup="forgotPassword" />

            <!-- Back to Login Link -->
            <div class="back-to-login">
                <a href="./Login.aspx">Back to Login</a>
            </div>
        </div>
    </form>

    <%: System.Web.Optimization.Scripts.Render("~/bundles/JqueryPopperBootStrap") %>
</body>
</html>
