@PageSetup

Feature: Shop

As a User, 
I want to filter products by values,
I should br able to add items to the cart, 
and remove added items from the cart.

#Verify that catalog filter works correctly

Scenario: Filter:

	#Arrange:
	Given I am on '<Tab>' page
	#Act:
	When I see '<Page Heading>'
	When I see products on the page
	When I select filter by '<Filter Value>'
	#Assert:
	Then I see filter works by '<Filter Value>'

Examples:
	| Tab                | Page Heading      | Filter Value     |
	| solar-panels       | Сонячні панелі    | Abi-Solar        |
	| solar-panels       | Сонячні панелі    | Полікристал      |
	| solar-panels       | Сонячні панелі    | 72               |
	| inverters          | Сонячні інвертори | Huawei           |
	| inverters          | Сонячні інвертори | Гібридний        |
	| batteries          | Акумулятори       | AXIOMA           |
	| batteries          | Акумулятори       | Літієвий         |
	| batteries          | Акумулятори       | 12В              |
	| charge-controllers | Контролери заряду | 150В             |
	| mounting-systems   | Системи кріплення | Покрівля         |
	| mounting-systems   | Системи кріплення | Бітумна черепиця |


#Verify that product can be added and removed from the Shopping Cart

Scenario Outline: Add/Remove to Cart:

	#Arrange:
	Given I am on '<Tab>' page

	#Act 1 - Add products to cart:
	When I add '<First product>' to the Cart
	And I click 'Продовжити купувати' button
	And I continue shoping
	And I add '<Second product>' to the Cart
	And I click 'Оформити замовлення' button

	#Assert 1 - Products added:
	Then I am on the 'cart' page
	And I see heading 'Товари у кошику'
	And I see '<First product>' in the Cart
	And I see '<Second product>' in the Cart

	#Act 2 - Remove product from cart:
	When I remove '<First product>' from the Cart

	#Assert 2 - Products removed:
	Then I do not see '<First product>' in the Cart
	And I see '<Second product>' in the Cart

Examples:
	| Tab       | First product           | Second product          |
	| batteries | PYLONTECH US5000        | PYLONTECH US3000        |
	| inverters | Deye SUN-12K-SG04LP3-EU | Deye SUN-10K-SG04LP3-EU |


#Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid

Scenario: Product Details:

	#Arrange:
	Given I am on '<Tab>' page
	#Act:
	When I click on '<ProductName>' product holder
	#Assert:
	Then I see '<ProductName>'

Examples:
	| Tab       | ProductName             |
	| inverters | Deye SUN-12K-SG04LP3-EU |
	| inverters | Deye SUN-10K-SG04LP3-EU |
	| batteries | PYLONTECH US3000        |
	| batteries | PYLONTECH US5000        |