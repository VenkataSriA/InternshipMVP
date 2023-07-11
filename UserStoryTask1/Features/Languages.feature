Feature: Languages

Use case:
As a user I would be able to show what languages and skills I know.
So that the people seeking for skills and languages can look at what details I hold.

@mytag1
Scenario Outline: [1] Add details to languages tab.
	Given User is logged into localhost
	When I navigate to Go To Profile page
	And I Add new '<Language>' and '<Level>'
	Then New '<Language>' and '<Level>' are added successfully.

	Examples: 
	| Language | Level                 |
	| English  | Basic                 |
	|          | Choose Language Level |
	| English  | Basic                 |
	| English  | Conversational        |
	| english  | Basic                 |
	| French   | Choose Language Level |
	|          | Basic                 |
	| !@34     | Fluent                |
	| " "      | Native/Bilingual      |
	| German   | Basic                 |
	
	@mytag2
	Scenario Outline: [2] Edit details of added languages tab.
	Given User is logged into localhost
	When I navigate to Language tab on Profile page
	And I Edit existing '<Language>' and '<Level>'
	Then New '<Language>' and '<Level>' are edited successfully.

	Examples: 
	| Language | Level            |
	| Spanish  | Conversational   |
	|          | Fluent           |
	| German   | Language Level   |
	| English  | Native/Bilingual |
	
	@mytag3
	Scenario Outline: [3] Delete details of added languages.
	Given User is logged into localhost
	When I navigate to Language tab on Profile page
	And I delete existing record.
	Then Existing record deleted successfully.
