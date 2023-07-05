Feature: Skills

Use case:
As a user I would be able to show what languages and skills I know.
So that the people seeking for skills and languages can look at what details I hold.

@mytag1
Scenario Outline: [1] Add details to skills tab.
	Given User is logged into localhost
	When I navigate to Profile page
	And I add new '<Skills>' and '<Level>'
	Then Verify new '<Skills>' and '<Level>' are added successfully.

	Examples: 
	| Skills | Level                 |
	|          | Choose Language Level |
	| English  | Basic                 |
	| English  | Conversational        |
	| english  | Basic                 |
	| !@34     | Fluent                |
	|          | Basic                 |
	| French   | Choose Language Level |
	| 123      | Native/Bilingual      |
	| German   | Basic                 |