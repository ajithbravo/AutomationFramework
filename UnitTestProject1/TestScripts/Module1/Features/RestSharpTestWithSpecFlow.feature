Feature: RestSharpTestWithSpecFlow 
	Test Get Post operation with Restsharp.net


Scenario: Verify author of the Post 1
	Given I perform GET operation for "posts/{id}"
	And I perform operation for post "1"
	Then I should see the "author" name as "Batra"

	
Scenario: Verify author of the Post 4
	Given I perform GET operation for "posts/{id}"
	And I perform operation for post "4"
	Then I should see the "author" name as "Birbali"

	
Scenario: Verify author of the Post 9
	Given I perform GET operation for "posts/{id}"
	And I perform operation for post "9"
	Then I should see the "author" name as "Wilson"