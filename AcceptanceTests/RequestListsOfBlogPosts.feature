Feature: Request a list of blog posts
	In order to present a list of blog posts
	As an API consumer
	I want to be able to request a list of blog posts in JSON HAL & XML HAL formats

Scenario: Request a list of blog posts in JSON format
	Given I'm at the API entry point
	And I specify "application/hal+json" on request headers
	When I follow the link to a list of blog posts
	Then I will receive a list of blog posts in JSON / HAL format including links to each blog post
