Feature: Request a list of blog posts
	In order to present a list of blog posts
	As an API consumer
	I want to be able to request a list of blog posts in JSON HAL & XML HAL formats

@json
Scenario: Request a list of blog posts in JSON format
	When I follow the link to a list of blog posts
	Then I will receive a list of blog posts 
	And the list will include HAL links to itself
	And the posts will bee in JSON / HAL format
	And each post will include it's title and link to resource
