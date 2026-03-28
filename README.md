# TestAutomationFrameworkTask

## Task Description

Site for testing: https://www.saucedemo.com


### UC-1: Test Login Form with Empty Credentials

* Enter any credentials into "Username" and "Password" fields
* Clear the inputs
* Click the "Login" button
* Check that an error message **"Username is required"** appears


### UC-2: Test Login Form with Only Username Provided

* Enter any username
* Enter password
* Clear the "Password" field
* Click the "Login" button
* Check that an error message **"Password is required"** appears


### UC-3: Test Login Form with Valid Credentials

* Enter username using any value from the section **"Accepted usernames are"**
* Enter a password from the section **"Password for all users"**
* Click "Login" button

**Validate that the main page contains the following elements:**

* Burger menu button
* Label **"Swag Labs"**
* Shopping cart icon
* Dropdown with sorting filters
* List of inventory items


## Additional Requirements

* Provide possibility to execute tests in **parallel**
* Add **logging** to track execution flow
* Use **data-driven testing** approach


## Technical Stack

* Test Automation Tool: **Selenium WebDriver**
* Browsers:

  * Chrome
  * Edge
* Locators: **CSS**
* Test Runner: **NUnit**
* Assertions: **Fluent Assertions**

## Optional

### Design Patterns

* Singleton
* Factory Method
* Abstract Factory

### Test Automation Approach

* BDD

### Logging

* NUnit Logger


## Notes

Make sure that all tasks are supported by these 3 conditions:

* UC-1
* UC-2
* UC-3


Task description
Site for testing: https://www.saucedemo.com
UC-1 Test Login form with empty credentials:
oEnter any credentials into "Username" and "Password" fields.
oClear the inputs.
oClick the "Login" button.
oCheck that an error message "Username is required" appears.
UC-2 Test Login form with only Username provided:
oEnter any username.
oEnter password.
oClear the "Password" field.
oClick the "Login" button.
oCheck that an error message "Password is required" appears.
UC-3 Test Login form with valid credentials:
oEnter username using any value from the section “Accepted usernames are”.
oEnter a password from the section “Password for all users”.
oClick “Login” button and validate that main page contains the following elements:
-burger menu button;
-label “Swag Labs”;
-shopping cart icon;
-dropdown with sorting filters;
-list of inventory items
Provide possibility to execute tests in parallel, add logging to track execution flow and use data-driven testing approach.
Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.
Please, add task description as README.md into your solution!
To perform the task use the various of additional options:
Test Automation tool: Selenium WebDriver;
Browsers: 1) Chrome; 2) Edge;
Locators: CSS;
Test Runner: NUnit;
Assertions: Fluent Assertion;
[Optional] Patterns: Singleton; 2) Factory method; 3) Abstract Factory;
[Optional] Test automation approach: BDD;
[Optional] Loggers: NUnit.
