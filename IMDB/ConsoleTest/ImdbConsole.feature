Feature: ImdbConsole
	Simple console to store movie stats

@listmovies
Scenario: To list movies present in repository
	Given I have movie repository
	When I fetch the repository
	Then I get result
	| Id | Title          | Year | Description |
	| 1  | Ford v Ferrari | 2019 | xyz         |
	And Actor list is
	| Id | Name              | Dob       |
	| 1  | Matt Damon        | 8/10/1970 |
	| 2  | Christian Bale    | 30/1/1974 |
	And Producer is
	| Id | Name          | Dob        |
	| 1  | James Mangold | 16/12/1963 |

@addmovie
Scenario: To add movie in repository
	Given I have title "Shershaah"
	And I have release year "2021"
	And I have description "Emotional Movie"
	And Actors are "3 4"
	And Producer is "2"
	When I add the movie
	Then I get result
	| Id | Title          | Year | Description     |
	| 1  | Ford v Ferrari | 2019 | xyz             |
	| 2  | Shershaah      | 2021 | Emotional Movie |
	And Actor list is
	| Id | Name              | Dob       |
	| 1  | Matt Damon        | 8/10/1970 |
	| 2  | Christian Bale    | 30/1/1974 |
	| 3  | Siddhart Malhotra | 17/1/1985 |
	| 4  | Kiara Advani      | 31/7/1992 |
	And Producer is
	| Id | Name          | Dob        |
	| 1  | James Mangold | 16/12/1963 |
	| 2  | Apoorva Mehta | 22/5/1978  |
