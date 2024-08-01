Feature: Shop Page

@ShopPage
Scenario: Verify Shop page Heading visability:
	#Arrange:
	Given I'm on Shop page
	#Act:
	When Shop page is loaded
	#Assert:
	Then I see "Магазин" Heading is displayed

@ShopPage
#Verify that catalog filter works correctly
Scenario: Move to Invertors page clicking to the link:
	#Arrange:
	Given I'm on Shop page
	#Act:
	When I click on "Інвертори" link
	#Assert:
	Then I see "Сонячні інвертори" Heading is displayed


#	And I click on "Фільтр товарів" button
#	And I click on "Huawei" checkbox
#	Then I see "Huawei" products 
#
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

