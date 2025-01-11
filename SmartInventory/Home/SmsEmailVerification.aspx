<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmsEmailVerification.aspx.cs" Inherits="SmartInventory.Home.SmsEmailVerification" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Verification | Smart Inventory | Rahul Sharma</title>

    <%: System.Web.Optimization.Scripts.Render("~/bundles/JQueryWithCommonJS") %>
    <link href="../Content/bootstrap4.5.2.min.css" rel="stylesheet" />

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

        .brand-name {
            text-align: center;
            font-size: 40px;
            font-weight: bold;
            margin-bottom: 20px;
            color: #007bff;
        }

        .otp-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 550px;
        }

            .otp-container h3 {
                text-align: center;
                margin-bottom: 30px;
                color: #007bff;
            }

            .otp-container p {
                text-align: center;
                margin-bottom: 20px;
                font-size: 14px;
                color: #555;
            }

        .otp-input {
            width: 60px;
            text-align: center;
            margin: 0 5px;
            font-size: 18px;
            padding: 15px;
            border-radius: 4px;
            border: 1px solid #ccc;
        }

            .otp-input:focus {
                outline: none;
                border-color: #007bff;
            }

        .btn-verify, .btn-resend {
            width: 45%;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            border: none;
            color: white;
            border-radius: 4px;
        }

            .btn-verify:hover, .btn-resend.enabled:hover {
                background-color: #0056b3;
            }

        .btn-resend {
            width: 45%;
            padding: 10px;
            font-size: 16px;
            background-color: #6c757d;
            border: none;
            color: white;
            border-radius: 4px;
            cursor: not-allowed;
        }

            .btn-resend.enabled {
                background-color: #007bff;
                cursor: pointer;
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

        #errorMessage {
            display: none;
            text-align: center;
            color: #dc3545;
            margin-top: 15px;
        }

        .countdown {
            text-align: center;
            font-size: 14px;
            margin-top: 10px;
            color: #555;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">
        <div class="otp-container">
            <div class="brand-name text-center">
                Smart Inventory
            </div>
            <h3>Email OTP Verification</h3>
            <p>We have sent a One-Time Password (OTP) to your email. Please enter it below to verify your identity.</p>

            <!-- OTP Input Fields (Six fields for a 6-digit OTP) -->
            <div class="mb-3 text-center">
                <asp:TextBox ID="otp1" runat="server" CssClass="otp-input" MaxLength="1" />
                <asp:TextBox ID="otp2" runat="server" CssClass="otp-input" MaxLength="1" />
                <asp:TextBox ID="otp3" runat="server" CssClass="otp-input" MaxLength="1" />
                <asp:TextBox ID="otp4" runat="server" CssClass="otp-input" MaxLength="1" />
                <asp:TextBox ID="otp5" runat="server" CssClass="otp-input" MaxLength="1" />
                <asp:TextBox ID="otp6" runat="server" CssClass="otp-input" MaxLength="1" />
            </div>

            <!-- OTP Verification Button -->
            <div class="d-grid gap-2 text-center">
                <asp:Button ID="BtnVerfifyOTP" runat="server" Text="Verify" CssClass="btn btn-verify" OnClick="BtnVerfifyOTP_Click" />
                <asp:Button ID="BtnResendOTP" runat="server" Text="Resend" CssClass="btn btn-resend" OnClick="BtnResendOTP_Click" />
            </div>

            <div class="countdown" id="countdownTimer">
                Resend OTP in <span id="timeRemaining">02:00</span>
            </div>

            <!-- Error Message -->
            <div id="errorMessage" class="mt-3 text-danger">
                <p>Please enter a valid OTP.</p>
            </div>
        </div>
    </form>

    <script>
        // Countdown timer for Resend OTP
        var countdownTime = 120; // 2 minutes in seconds
        var countdownInterval;

        function updateCountdown() {
            var minutes = Math.floor(countdownTime / 60);
            var seconds = countdownTime % 60;
            document.getElementById('timeRemaining').textContent = (minutes < 10 ? '0' : '') + minutes + ':' + (seconds < 10 ? '0' : '') + seconds;
            countdownTime--;

            // When countdown reaches 0, enable the resend button
            if (countdownTime < 0) {
                clearInterval(countdownInterval);
                document.getElementById('BtnResendOTP').classList.add('enabled');
                document.getElementById('BtnResendOTP').disabled = false;
                document.getElementById('countdownTimer').style.display = 'none'; // Hide countdown
            } else {
                document.getElementById('BtnResendOTP').classList.remove('enabled');
                document.getElementById('BtnResendOTP').disabled = true;
            }
        }

        // Start countdown when page loads
        window.onload = function () {
            countdownInterval = setInterval(updateCountdown, 1000);
        };

        // Automatically move to the next input when a key is pressed
        $(document).on('input', '.otp-input', function () {
            if (this.value.length == this.maxLength) {
                $(this).next('.otp-input').focus();
            }
        });

        // Show error message if OTP is not valid
        function showErrorMessage() {
            $('#errorMessage').show();
        }

        // Hide error message
        function hideErrorMessage() {
            $('#errorMessage').hide();
        }
    </script>

</body>
</html>
