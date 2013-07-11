Feature: Request A Blog Post
	In order to present a blog post
	As an API consumer
	I want to be able to request a blog post in JSON HAL & XML HAL formats

@json
Scenario: Request a list of blog posts in JSON format
	Given I've requested a list of blog posts
	When I follow the link to 'my first post'
	Then I will receive full details for 'my first post'
	And the post will include HAL links to itself


@json
Scenario: Request a non existent blog post
	When I request a non existent blog post
	Then I should receive a 404 Not Found
