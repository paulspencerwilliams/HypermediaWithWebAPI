using System;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class Steps
    {

        [Given(@"I'm at the API entry point using hal / json")]
        public void GivenIMAtTheAPIEntryPointUsingHalJson()
        {
            var apiProxy = new ApiProxy(ApiProxy.ApiFormat.Json);
            ScenarioContext.Current["apiProxy"] = apiProxy;
        }

        [When(@"I follow the link to a list of blog posts")]
        public void WhenIFollowTheLinkToAListOfBlogPosts()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            apiProxy.FollowLink("blogposts");
        }

        [Then(@"I will receive a list of blog posts")]
        public void ThenIWillReceiveAListOfBlogPosts()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPosts = (JArray)apiProxy.CurrentResource.JsonValue["_embedded"]["blogposts"];
            Assert.That(blogPosts.Count, Is.EqualTo(2));
        }

        [Then(@"the list will include HAL links to itself")]
        public void ThenTheListWillIncludeHALLinksToItself()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPosts = apiProxy.CurrentResource.JsonValue;
            var link = blogPosts["_links"]["self"].Value<String>("href");
            var expected = "/api/blogposts";
            Assert.That(link, Is.EqualTo(expected));
        }

        [Then(@"the posts will bee in JSON / HAL format")]
        public void ThenThePostsWillBeeInJSONHALFormat()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            Assert.That(apiProxy.CurrentResource.Format, Is.EqualTo(ApiProxy.ApiFormat.Json));
        }


        [Then(@"each post will include it's title and link to resource")]
        public void ThenEachPostWillIncludeItSTitleAndLinkToResource()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var firstBlogPost = apiProxy.CurrentResource.JsonValue["_embedded"]["blogposts"].First;
            Assert.That(firstBlogPost.Value<string>("title"), Is.EqualTo("my first post"));
            Assert.That(firstBlogPost["_links"]["self"].Value<string>("href"), Is.EqualTo("/api/blogposts/1"));
        }

    }
}
