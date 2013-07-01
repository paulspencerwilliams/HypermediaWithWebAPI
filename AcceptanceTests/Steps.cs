using NUnit.Framework;
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
            apiProxy.FollowLink("blogPosts");
        }

        [Then(@"I will receive a list of blog posts")]
        public void ThenIWillReceiveAListOfBlogPosts()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPosts = apiProxy.CurrentResource.JsonValue;
            Assert.That(blogPosts["_embedded"].Count, Is.EqualTo(3));
        }

        [Then(@"the list will include HAL links to itself")]
        public void ThenTheListWillIncludeHALLinksToItself()
        {
            var apiProxy = (ApiProxy)ScenarioContext.Current["apiProxy"];
            var blogPosts = apiProxy.CurrentResource.JsonValue;
            Assert.That(blogPosts["_links"]["self"], Is.EqualTo("/api/blogposts"));
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
            var firstBlogPost = apiProxy.CurrentResource.JsonValue["embedded"]["blogposts"][0];
            Assert.That(firstBlogPost["title"], Is.EqualTo("my first blog post"));
            Assert.That(firstBlogPost["_links"]["self"], Is.EqualTo("/api/blogposts/1"));
        }

    }
}
