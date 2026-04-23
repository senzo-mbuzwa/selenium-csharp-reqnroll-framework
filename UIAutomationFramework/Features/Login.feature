Feature: Login

  As a registered banking user
  I want to log into the application
  So that I can access my account information

  Scenario: Successful login with valid credentials
    Given the user navigates to the login page
    When the user logs in with valid credentials
    Then the accounts overview page should be displayed

  Scenario: Unsuccessful login with invalid credentials
    Given the user navigates to the login page
    When the user logs in with invalid credentials
    Then a login error message should be displayed

  Scenario: Unsuccessful login with blank credentials
    Given the user navigates to the login page
    When the user logs in with blank credentials
    Then a required field validation message should be displayed