Feature: XpediaCheapestTicket
	In order to find the cheapest ticket
	I want to be able to populate fields and select a ticket

@mytag
Scenario: Choose the cheapest ticket.
	Given  I select flights  tab 
	And choose one way  trip
	And  enter city from  "Kiev
	And enter city to "Amsterdam
	And enter departing date "12/05/2016
	And enter adults quantity "1
	And press Search button
	And select the cheapest ticket
	When I press select button
	Then I should be redirected to the ticket details