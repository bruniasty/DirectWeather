Feature: Local weather in a given city
	As a delegated employee
	I want to check what the weather is like in a city and country of my choosing
	So that I know how to dress for the business trip over there.

@directWeatherInWarsaw
Scenario: Search weather in Poland, Warsaw
	Given a webpage with a form
	And I type 'Poland' in country form
	And I type 'Warsaw' in city form
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports
	
@directWeatherInGdansk
Scenario: Search weather in Poland, Gdansk
	Given a webpage with a form
	And I type 'Poland' in country form
	And I type 'Gdansk' in city form
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports

@directWeatherInBerlin
Scenario: Search weather in Germany, Berlin
	Given a webpage with a form
	And I type 'Germany' in country form
	And I type 'Berlin' in city form
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports
