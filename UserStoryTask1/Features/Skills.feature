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
	| Skills | Level              |
	| Tester | Intermediate       |
	|        | Choose Skill Level |
	|        | Beginner           |
	| QA     |                    |
	| Tester | Expert             |
	| tester | Intermediate       |
	| [!#$>? | Beginner           |
	| " "    | Expert             |
	
	@mytag2
	Scenario Outline: [2] Edit details of added languages tab.
	Given User is logged into localhost
	When I navigate to Profile page
	And I edit existing '<Skills>' and '<Level>'
	Then Verify new '<Skills>' and '<Level>' are edited successfully.

	Examples: 
	| Skills       | Level        |
	| Test Analyst | Intermediate |
	|              | Skill Level  |  
	|              | Beginner     |
	| Tester       | Expert       |
	| Tester       | Intermediate |
	| 1234         | Expert       |
	
	@mytag3
	Scenario Outline: [3] Delete details of added languages.
	Given User is logged into localhost
	When I navigate to Profile page
	And I delete existing '<Skills>' and '<Level>'
	Then Existing skill deleted successfully.

	Examples: 
	| Skills | Level        |
	| tester | Expert       |
	| [!#$>? | Beginner     |
	| tester | Intermediate |