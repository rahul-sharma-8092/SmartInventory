# Smart Inventory

Smart Inventory is a robust and intuitive inventory management system designed to simplify and streamline the management of inventory for businesses of all sizes. This system offers features like inventory tracking, user management, sales and purchase management, and reporting capabilities, all under one roof. 


## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Folder Structure](#folder-structure)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)


## Overview

Managing inventory is a critical task for businesses. Smart Inventory is built to offer seamless inventory management, ensuring businesses can:
- Track inventory levels in real-time.
- Manage suppliers, customers, sales, and purchases efficiently.
- Generate insightful reports to make data-driven decisions.

Smart Inventory is modular, scalable, and built to integrate seamlessly with existing workflows. Whether you're managing a small shop or an enterprise, Smart Inventory adapts to your needs.


## Features

### Key Features:
1. **Inventory Tracking**  
   Track product stocks and receive alerts when inventory levels are low.

2. **User Management**  
   Manage roles, permissions, and secure user authentication with two-factor authentication (2FA).

3. **Sales and Purchase Management**  
   Effortlessly manage sales and purchases while maintaining an audit trail.

4. **Supplier and Customer Management**  
   Keep records of suppliers and customers for seamless communication and transactions.

5. **Reporting and Analytics**  
   Generate detailed reports on inventory, sales, and purchases to gain actionable insights.

6. **Error Logging**  
   Maintain an error log for debugging and monitoring system issues.

7. **Email Notifications**  
   Automated email notifications for critical system updates, password resets, and OTP verification.


## Folder Structure

Here’s the project directory structure:  

```plaintext
rahul-sharma-8092-SmartInventory/
├── AdminDB/                # Database scripts for admin management
├── BAL/                    # Business logic layer
├── Common/                 # Shared utilities and common components
├── DAL/                    # Data access layer
├── Entity/                 # Entity classes for the project
├── SmartInventory/         # Web application files
├── SmartInventoryDB/       # Database scripts for the main application
├── README.md               # Documentation for the project
└── LICENSE.txt             # License details
```

## Technologies Used

- **Frontend:** ASP.NET Web Forms  
- **Backend:** C#  
- **Database:** Microsoft SQL Server  
- **Frameworks:** .NET Framework  
- **Utilities:** jQuery, Bootstrap  
- **Other Tools:** Git for version control, HTML email templates for notifications  


## Prerequisites

Before installing and running **Smart Inventory**, ensure you have the following installed on your system:

### Operating System:
- **Windows** (compatible with SQL Server and .NET Framework)

### Software:
- Microsoft Visual Studio (2019 or later)  
- Microsoft SQL Server  
- IIS (Internet Information Services)

### Languages & Frameworks:
- .NET Framework 4.7.2 or later  
- C#

### Dependencies:
- Required NuGet packages (listed in `packages.config`)

## Installation
Follow these steps to set up and run the Smart Inventory system:

### 1. Clone the Repository
- Clone the repository to your local machine:

```bash
git clone https://github.com/rahul-sharma-8092/SmartInventory.git
cd SmartInventory
```

### 2. Set Up the Database

- Open the `AdminDB` and `SmartInventoryDB` directories.
- Run the SQL scripts in the respective `Security`, `dbo/Stored Procedures`, and `dbo/Tables` directories to create the database schema.
- Update connection strings in `Web.config`.

### 3. Install Dependencies
- Open the solution file (`SmartInventory.sln`) in Visual Studio and restore NuGet packages:

## Usage Guide

1. **Login or Register:**
    - Use the Login page to sign in or register for a new account.
    - Admins can set up roles and permissions for users.

2. **Navigate the Dashboard:**
    - Use the main dashboard to view a summary of inventory, sales, purchases, and notifications.

3. **Add Inventory:**
    - Go to the **Products** section to add, edit, or remove items.

4. **Manage Sales and Purchases:**
    - Record sales and purchases in the respective sections.

5. **Generate Reports:**
    - Use the **Reports** feature to view analytics and export data.

## License
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE.txt) file for more details.
