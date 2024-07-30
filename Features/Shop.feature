Feature: Shop Page

@WebPageLogin

Scenario: Open Shop Page
	Given GoTo Shop Page
	When Shop Page is loaded
	Then "Магазин" Heading is displayed