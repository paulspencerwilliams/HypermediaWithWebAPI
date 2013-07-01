using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class Steps
    {
        [Given(@"I'm at the API entry point")]
        public void GivenIMAtTheAPIEntryPoint()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I specify ""(.*)"" on request headers")]
        public void GivenISpecifyOnRequestHeaders(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I follow the link to a list of blog posts")]
        public void WhenIFollowTheLinkToAListOfBlogPosts()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will receive a list of blog posts in JSON / HAL format including links to each blog post")]
        public void ThenIWillReceiveAListOfBlogPostsInJSONHALFormatIncludingLinksToEachBlogPost()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
