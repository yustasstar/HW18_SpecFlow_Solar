Feature: Shop Page

@WebPage

Scenario: Verify Shop page Heading visability:
	#Arrange:
	Given GoTo Shop page
	#Act:
	When Shop page is loaded
	#Assert:
	Then "Магазин" Heading is displayed

	
#Verify that catalog filter works correctly
Scenario: Verify that catalog filter works correctly:
	#Arrange:
	Given I'm on Shop page
	#Act:
	When I move to Invertors page
	And I click on "Фільтр товарів" button
	And I click on "Huawei" checkbox
	#Assert:
	Then I see "Huawei" products 


#Verify that product can be added and removed from the Shopping Cart
Scenario: Verify that product can be added and removed from the Shopping Cart:
	#Arrange:
	Given I'm on Shop page
	#Act:
	When I add first proguct in cart
	And I close info popup
	And I add second proguct in cart
	And I move to the cart

	#Assert:
	Then I see "Huawei" products 


#Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid (for example when user clicks on some product like "Jinko Solar 455 Âò" on https://solartechnology.com.ua/shop/solar-panels then exactly this product details are shown but not some other product's details)