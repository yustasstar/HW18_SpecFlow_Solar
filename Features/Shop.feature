@ShopPageSetup

Feature: ShopPage

As a User, I want to group products into tabs,
I can filter products by values on those tabs,
I can add items to the cart, 
and remove added items from the cart.

Scenario: Verify every Tab <h1>:
	#Arrange:
	Given I am on 'shop' page
	#Act:
	When I click on '<Tab Name>' tab
	#Assert:
	Then I see '<h1>' heading is displayed
Examples:
	| Tab Name           | h1                |
	| Сонячні панелі     | Сонячні панелі    |
	| Інвертори          | Сонячні інвертори |
	| Акумулятори        | Акумулятори       |
	| Контролери заряду  | Контролери заряду |
	| Системи кріплення  | Системи кріплення |
	| Кабель і комутація | Сонячний кабель   |


#Verify that catalog filter works correctly

Scenario: Verify Filter:
	#Arrange:
	Given I am on 'shop/<Tab>' page
	#Act:
	When I click on Filter button
	And I click on '<FilterValue>' checkbox
	#Assert:
	Then I see '<FilterValue>' products
Examples:
	| Tab          | FilterValue    |
	| inverters    | Huawei         |
	| inverters    | Deye           |
	| inverters    | Fronius        |
	| inverters    | LuxPower       |
	| inverters    | Victron Energy |
	| solar-panels | SOLA           |
	| solar-panels | Abi-Solar      |
	| solar-panels | Ulica Solar    |
	| solar-panels | Yingli Solar   |
	| solar-panels | JA Solar       |
	| solar-panels | Jinko Solar    |
	#| solar-panels | C&T Solar                      | not all contain full Brand name
	| batteries    | AXIOMA         |
	| batteries    | BYD            |
	| batteries    | PYLONTECH      |
	#| batteries    | Victron Energy                 | different filter value and product name
	#| batteries    | АДС - Автономні Джерела Струму | different filter value and product name


#Verify that product can be added and removed from the Shopping Cart
Scenario Outline: Add products to Cart:
	#Arrange:
	Given I am on 'shop' page
	#Act:
	When I add '<First product>' to the Cart
	And I click 'Продовжити купувати' button
	And AddPopup is closed
	And I add '<Second product>' to the Cart
	And I click 'Оформити замовлення' button
	And AddPopup is closed
	#Assert:
	Then I am on the 'cart' page
	Then I see heading 'Товари у кошику'
Examples:
	| First product           | Second product          |
	| Huawei SUN2000-50KTL-M3 | PYLONTECH US5000        |
	| Deye SUN-12K-SG04LP3-EU | Huawei SUN2000-10KTL-M1 |

	
	#And I deleted '<Second product>' from the Cart
	#Then I see '<First proguct>' in the Cart
	#Then I don't see '<Second product>' in the Car



##Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid (for example when user clicks on some product like "Jinko Solar 455 Âò" on https://solartechnology.com.ua/shop/solar-panels then exactly this product details are shown but not some other product's details)


