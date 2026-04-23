# Selenium C# Reqnroll Framework

A scalable UI automation framework built with **C#**, **Selenium WebDriver**, and **Reqnroll (BDD)**.

## Overview

This project demonstrates a maintainable UI automation framework using the **Page Object Model (POM)**, reusable utilities, hooks, and configuration-driven execution. It is designed to showcase enterprise-style test automation practices suitable for modern web applications.

## Tech Stack

- C#
- .NET 8
- Selenium WebDriver
- Reqnroll
- NUnit
- FluentAssertions
- Microsoft.Extensions.Configuration

## Framework Design

- Page Object Model (POM)
- Driver Factory for browser lifecycle management
- Hooks for setup and teardown
- Reusable element actions and waits
- Screenshot capture on failure
- Centralized configuration via `appsettings.json`

## Project Structure

- `Config/` → strongly typed settings
- `Drivers/` → browser initialization
- `Hooks/` → scenario setup and teardown
- `Pages/` → page objects
- `Utilities/` → reusable helpers
- `StepDefinitions/` → BDD step definitions
- `Features/` → feature files

## Current Test Coverage

- Successful login with valid credentials
- Unsuccessful login with invalid credentials

## Test Execution Screenshot

![Login Test](docs/login-test.png)

## How to Run

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Update `appsettings.json` if needed
5. Run tests using Test Explorer

## Key Features

- Configuration-driven test execution
- Reusable framework structure
- Clean separation of concerns
- Positive and negative login coverage
- Screenshot capture on failure

## Future Improvements

- Extent Reports integration
- Parallel execution
- CI/CD pipeline integration
- Cross-browser execution enhancements
- Additional feature coverage