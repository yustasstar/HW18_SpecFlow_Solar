@ShopPageSetup

Feature: InvertorsFilterTest

As a User, I want to group products into pages,
I can filter products by properties on those pages,
I can add items to the cart, 
and remove added items from the cart.

Scenario Outline: Verify Shop page Heading visability:
	#Arrange:
	Given I am on 'shop' page
	#Act:
	When 'shop' page is loaded
	#Assert:
	Then I see 'Магазин' Heading is displayed


Scenario Outline: Move to <TabName> tab and check h1 <Heading>:
	#Arrange:
	Given I am on 'shop' page
	#Act:
	When I click on '<TabName>' tab
	#Assert:
	Then I see '<Heading>' Heading is displayed
Examples:
	| TabName            | Heading           |
	| Сонячні панелі     | Сонячні панелі    |
	| Інвертори          | Сонячні інвертори |
	| Акумулятори        | Акумулятори       |
	| Контролери заряду  | Контролери заряду |
	| Системи кріплення  | Системи кріплення |
	| Кабель і комутація | Сонячний кабель   |


#Verify that catalog filter works correctly
Scenario Outline: Filter products by Brand:
	#Arrange:
	Given I am on 'shop/inverters' page
	#Act:
	When I click on Filter button
	And I check 'Huawei' filter
	#Assert:
	Then I see 'Huawei' products

#
##Verify that product can be added and removed from the Shopping Cart
#Scenario: Verify that product can be added and removed from the Shopping Cart:
#	#Arrange:
#	Given I'm on Shop page
#	#Act:
#	When I add first proguct in the Cart
#	And I continue buying
#	And I add second product in the Cart
#	And I move to the cart
#	And I deleted second product from the Cart 
#
#	#Assert:
#	Then I see first proguct in the Cart
#	Then I don't see second proguct in the Cart
#
##Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid (for example when user clicks on some product like "Jinko Solar 455 Âò" on https://solartechnology.com.ua/shop/solar-panels then exactly this product details are shown but not some other product's details)
#
#Scenario: Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid:
#	#Arrange:
#	Given I'm on Shop page
#	#Act:
#	When I click on the product
#	#Assert:
#	Then I see proguct details

