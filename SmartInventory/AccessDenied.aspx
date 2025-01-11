<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="SmartInventory.AccessDenied" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Access Denied</title>
    <!-- Link to Bootstrap CSS (Ensure you have internet access or download the Bootstrap files) -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        .container {
            max-width: 600px;
            text-align: center;
        }
        .access-denied-icon {
            font-size: 100px;
            color: #dc3545;
        }
        .btn-back-home {
            margin-top: 20px;
        }
    </style>

    <%: System.Web.Optimization.Scripts.Render("~/bundles/JQueryWithCommonJS") %>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Icon and Message -->
            <div class="access-denied-icon">
                <i class="fas fa-ban"></i>
            </div>
            <h1 class="display-4 text-danger">Access Denied</h1>
            <p class="lead">You do not have permission to view this page.</p>
            
        </div>
    </form>

    <!-- Link to Font Awesome for the icon -->
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <!-- Link to Bootstrap JS (Optional, for modal, dropdown, etc.) -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
