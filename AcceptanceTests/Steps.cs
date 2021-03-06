﻿using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class Steps
    {


        [When(@"I follow the link to a list of blog posts")]
        public void WhenIFollowTheLinkToAListOfBlogPosts()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            apiProxy.FollowLink();
        }

        [Then(@"I will receive a list of blog posts")]
        public void ThenIWillReceiveAListOfBlogPosts()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPosts = (JArray)apiProxy.CurrentRepresentation.JsonValue["_embedded"]["blogposts"];
            Assert.That(blogPosts.Count, Is.EqualTo(2));
        }

        [Then(@"the list will include HAL links to itself")]
        public void ThenTheListWillIncludeHALLinksToItself()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPosts = apiProxy.CurrentRepresentation.JsonValue;
            var link = blogPosts["_links"]["self"].Value<String>("href");
            Assert.That(link, Is.EqualTo("/api/blogposts"));
        }

        [Then(@"the posts will bee in JSON / HAL format")]
        public void ThenThePostsWillBeeInJSONHALFormat()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            Assert.That(apiProxy.CurrentRepresentation.Format, Is.EqualTo(ApiProxy.ApiFormat.Json));
        }


        [Then(@"each post will include it's title and link to resource")]
        public void ThenEachPostWillIncludeItSTitleAndLinkToResource()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var firstBlogPost = apiProxy.CurrentRepresentation.JsonValue["_embedded"]["blogposts"].First;
            Assert.That(firstBlogPost.Value<string>("title"), Is.EqualTo("my first post"));
            Assert.That(firstBlogPost["_links"]["self"].Value<string>("href"), Is.EqualTo("/api/blogposts/1"));
        }


        [Given(@"I've requested a list of blog posts")]
        public void GivenIVeRequestedAListOfBlogPosts()
        {
            WhenIFollowTheLinkToAListOfBlogPosts();
        }

        [When(@"I follow the link to 'my first post'")]
        public void WhenIFollowTheLinkTo()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPost = apiProxy.CurrentRepresentation.FindBlogPostRepresentation("my first post");
            if (blogPost == null)
            {
                Assert.Fail(String.Format("Blog post with title '#{0}' was not found", "my first post"));
            }
            apiProxy.FollowLink((JObject)blogPost);
        }

        [Then(@"I will receive full details for 'my first post'")]
        public void ThenIWillReceiveFullDetailsFor()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPost = apiProxy.CurrentRepresentation.JsonValue;
            Assert.That(blogPost.Value<string>("id"), Is.EqualTo("1"));
            Assert.That(blogPost.Value<string>("title"), Is.EqualTo("my first post"));
        }


        [Then(@"the post will include HAL links to itself")]
        public void ThenThePostWillIncludeHALLinksToItself()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var link = apiProxy.CurrentRepresentation.JsonValue["_links"]["self"].Value<String>("href");
            Assert.That(link, Is.EqualTo("/api/blogposts/1"));
        }


        [When(@"I request a non existent blog post")]
        public void WhenIRequestANonExistentBlogPost()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            apiProxy.FollowLink("/api/blogposts/999");
        }

        [Then(@"I should receive a (.*) Not Found")]
        public void ThenIShouldReceiveANotFound(int p0)
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            Assert.That(apiProxy.CurrentRepresentation.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


    }
}
