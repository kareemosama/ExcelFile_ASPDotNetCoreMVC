# ExcelFile ASP.NET Core MVC

## Table of Contents

- [About](#about)
- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [References](#references)

## About

ExcelFile ASP.NET Core MVC is a versatile web application developed using ASP.NET Core MVC. This project facilitates the upload, processing, and display of Excel files in a user-friendly interface. It serves as a foundation for projects requiring Excel file handling within an ASP.NET Core MVC application.

## Features

- **Excel File Upload:** Easily upload Excel files for processing and analysis.
- **Data Visualization:** Visual representation of Excel data for easy interpretation.
- **User-Friendly Interface:** Intuitive user interface for seamless navigation.

## Technologies

The project utilizes the following technologies:

- **ASP.NET Core MVC:** The server-side framework for building the web application.
- **C#:** The primary language for server-side logic.
- **Entity Framework Core:** A powerful ORM for interacting with the database.
  1. Code-First model for database interaction.
  2. Migrations for database schema updates.
- **MVC (Model-View-Controller):** The architectural pattern for organizing and managing the application's structure.

## Getting Started

To start working with ExcelFile ASP.NET Core MVC, follow the [Getting Started](#getting-started) section below to set up your development environment and install the necessary dependencies.

### Prerequisites

Before you begin, ensure that you have the following software installed on your machine:

- [.NET Core SDK](https://dotnet.microsoft.com/download): The framework required to build and run the application.
- [Visual Studio](https://visualstudio.microsoft.com/): A popular integrated development environment (IDE) for .NET applications.

### Installation

Follow these steps to set up and run ExcelFile ASP.NET Core MVC locally:

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/kareemosama/ExcelFile_ASPDotNetCoreMVC-.git
   cd ExcelFile_ASPDotNetCoreMVC-
   ```

2. **Restore Packages:**

   ```bash
   dotnet restore
   ```

3. **Update Database:**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the Application:**

   ```bash
   dotnet run
   ```

# Refrence

- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0):Official documentation for ASP.NET Core.
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/):Official documentation for Entity Framework Core.
- [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio):Official documentation for ASP.NET Core Identity.
