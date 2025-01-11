<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmartInventory.Home.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Smart Inventory</title>
    <!-- Link to Bootstrap CSS -->  
    <link href="../Content/bootstrap4.5.2.min.css" rel="stylesheet" />
    <%: System.Web.Optimization.Scripts.Render("~/bundles/JQueryWithCommonJS") %>
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

        .login-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
        }

        .login-container h3 {
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

        .btn-login {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            border: none;
            color: white;
            border-radius: 4px;
        }

        .btn-login:hover {
            background-color: #0056b3;
        }

        .forgot-password {
            text-align: center;
            margin-top: 10px;
        }

        .forgot-password a {
            color: #007bff;
            text-decoration: none;
        }

        .forgot-password a:hover {
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
            display: none; 
            z-index: 1; 
        }

        .form-group {
            position: relative;
        }

        /* Show validation error when triggered */
        .validation-error.active {
            display: block;
        }

        /* Create the arrow pointing downwards */
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
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="login-container">
            <div class="brand-name">Smart Inventory</div>
            <h3>Login to Your Account</h3>
            
            <!-- Email Field -->
            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" 
                    ErrorMessage="Required" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
            </div>
            
            <!-- Password Field -->
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" 
                    Placeholder="Enter your password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" 
                    ErrorMessage="Required" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
            </div>

            <!-- Login Button -->
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-login" OnClick="btnLogin_Click" />

            <!-- Forgot Password Link -->
            <div class="forgot-password">
                <a href="./ForgotPassword.aspx">Forgot Password?</a>
            </div>
        </div>
    </form>

</body>
</html>
