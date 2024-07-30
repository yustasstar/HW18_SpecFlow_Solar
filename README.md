HW 18. Create new project and automate 3 UI tests
Created: 23.07.2024 22:34
Deadline:
12 August 00:00
Retakes:
3

Create new project (Atata or Playwright with SpecFlow or without).
Automate 3 scenarios for https://solartechnology.com.ua/shop:

1) Verify that catalog filter works correctly
2) Verify that product can be added and removed from the Shopping Cart
3) Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid (for example when user clicks on some product like "Jinko Solar 455 Âò" on https://solartechnology.com.ua/shop/solar-panels then exactly this product details are shown but not some other product's details)

Homework result should be sent as a link to Pull Request (PR).
If some comments are provided, you need to fix them, update PR and send a link to PR into Homework again
You can merge PR only after it is approved
You have 3 attempts to fix PR comments

Criteria which will be considered when homework is evaluated:
1) Project structure. How classes are organized (Pages, Steps, Helpers, Tests, etc.)
2) Test structure according to AAA - Arrange/Act/Assert
3) Assert quality. For example:
- no Assert inside "if"
- if Assert is inside "foreach" then there is additional Assert that checks that foreach collection is not empty
- if Assert checks that element is not visible then the same selector is used somewhere to check that element is visible
- correct Assert is used, e.g. Assert.That(expected, Is.EqualTo(actual)); but not Assert.That(expected == actual, Is.True);
4) Test reliability. For example:
- test should fail in case of some unexpected behavior. For example if page crashes or is redirected to unexpected URL?
- test shouldn't pass when it should fail. For example if some selector changes, element can't be found but test is still green.
5) Page Object model correctness, for example:
- all locators are inside Page classes
- pages are not mixed up, e.g. if element is located on the Home page, it should not be defined in the CartPage.cs or HelpPage.cs
- all Asserts are in one place - either in tests itself or in Page methods like VerifySomethingVisible / Added / Deleted, etc., not both
6) Correctness of the Pull Request:
- PR contains only relevant changes
- PR comments are answered, so reviewer can understand if comment was fixed or you think it should nod be fixed and why