<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageNotFound.aspx.cs" Inherits="SmartInventory.PageNotFound" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>404 - Page Not Found</title>
    
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Arial', sans-serif;
        }
        .error-container {
            text-align: center;
            margin-top: 10%;
            pointer-events: none;
        }
        .error-code {
            font-size: 100px;
            font-weight: bold;
            color: #dc3545;
            user-select: none;
        }
        .error-message {
            font-size: 24px;
            color: #6c757d;
            margin-bottom: 20px;
            user-select: none;
        }
        .error-description {
            font-size: 18px;
            color: #868e96;
            margin-bottom: 40px;
            user-select: none;
        }
        .error-rahul{
            font-size: 40px;
            color: #dc3545;
            user-select: none;
        }
    </style>

    <%: System.Web.Optimization.Scripts.Render("~/bundles/JQueryWithCommonJS") %>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="error-container">
                <div class="error-code">404</div>
                <div class="error-message">Oops! Page Not Found</div>
                <div class="error-description">
                    The page you're looking for might have been removed, had its name changed, or is temporarily unavailable.
                </div>
                <div class="error-rahul">Rahul Sharma</div>
            </div>
        </div>
    </form>

   <script src="Scripts/jquery-3.7.0.min.js"></script>
</body>
</html>