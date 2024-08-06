@PageSetup

Feature: Shop

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

Scenario: Verify Filter on the tab:

	#Arrange:
	Given I am on 'shop/<Tab>' page
	#Act:
	When I click on Filter button
	And I click on '<FilterValue>' checkbox
	#Assert:
	Then I see '<FilterValue>' filtered products

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
	| batteries    | AXIOMA         |
	| batteries    | BYD            |
	| batteries    | PYLONTECH      |
	#| solar-panels | C&T Solar                      | not all contain full Brand name
	#| batteries    | Victron Energy                 | different filter value and product name
	#| batteries    | АДС - Автономні Джерела Струму | different filter value and product name


#Verify that product can be added and removed from the Shopping Cart

Scenario Outline: Add/Remove product in Cart:

	#Arrange:
	Given I am on 'shop' page

	#Act 1 - Add products to cart:
	When I add '<First product>' to the Cart
	And I click 'Продовжити купувати' button
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
	| First product           | Second product                            |
	| Huawei SUN2000-50KTL-M3 | PYLONTECH US5000                          |
	| Deye SUN-12K-SG04LP3-EU | Huawei SUN2000-10KTL-M1                   |
	| Huawei SUN2000-8KTL-M1  | Victron Energy MultiPlus II 48/5000/70-50 |
	| Huawei SUN2000-17KTL-M2 | AXIOMA energy AGM 12В 100Ач, AX-AGM-100   |


#Verify that when user clicks on the product then there is a same name/model is displayed on Product Details which was on the product grid

Scenario: Verify Product Details:

	#Arrange:
	Given I am on 'shop' page
	#Act:
	When I click on '<ProductName>' product holder
	#Assert:
	Then I see '<ProductName>' heading is displayed

Examples:
	| ProductName                               |
	| Huawei SUN2000-50KTL-M3                   |
	| Deye SUN-12K-SG04LP3-EU                   |
	| Huawei SUN2000-8KTL-M1                    |
	| Huawei SUN2000-17KTL-M2                   |
	| PYLONTECH US5000                          |
	| Huawei SUN2000-10KTL-M1                   |
	| Victron Energy MultiPlus II 48/5000/70-50 |
	| AXIOMA energy AGM 12В 100Ач, AX-AGM-100   |


