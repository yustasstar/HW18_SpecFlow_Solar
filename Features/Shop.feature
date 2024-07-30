Feature: Shop Page

@WebPage

Scenario: Open Shop Page
	Given GoTo Shop Page
	When Shop Page is loaded
	Then "Магазин" Heading is displayed